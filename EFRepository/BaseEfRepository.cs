using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Repository;

namespace EFRepository
{
    public abstract class BaseEfRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dataDbContext;
        private readonly IDbSet<T> _dbSet;

        protected BaseEfRepository(DbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
            _dbSet = dataDbContext.Set<T>();
        }

        public IQueryable<T> Entities
        {
            get { return _dbSet; }
        }

        public T New()
        {
            return _dbSet.Create();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataDbContext.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public T Create(T entity)
        {
            var added = _dbSet.Add(entity);
            Save();
            return added;
        }

        public void Create(List<T> collection)
        {
            _dataDbContext.Configuration.AutoDetectChangesEnabled = false;

            int count = 0;

            foreach (var entity in collection)
            {
                ++count;

                _dbSet.Add(entity);

                if (count % 100 == 0 || (collection.Count - count) < 100)
                {
                    Save();
                }
            }
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public void Dispose()
        {
            if (_dataDbContext != null)
            {
                _dataDbContext.Dispose();
            }
        }

        protected internal IList<TProcedureModel> GetEntityListByStoreProcedure<TProcedureModel>(String execProcedure)
        {
            return this._dataDbContext.Database.SqlQuery<TProcedureModel>(execProcedure).ToList<TProcedureModel>();
        }

        protected internal IList<TProcedureModel> GetEntityListByStoreProcedure<TProcedureModel>(String execProcedure, params Object[] parameters)
        {
            return this._dataDbContext.Database.SqlQuery<TProcedureModel>(execProcedure, parameters).ToList<TProcedureModel>();
        }

        protected internal void ExecuteStoredProcedure(String execProcedure)
        {
            this._dataDbContext.Database.ExecuteSqlCommand(execProcedure);
        }

        protected internal void ExecuteStoredProcedure(String execProcedure, params Object[] parameters)
        {
            this._dataDbContext.Database.ExecuteSqlCommand(execProcedure, parameters);
        }

        protected internal Int32 InsertStoredProcedureOut(String execProcedure, String outputParam)
        {
            var parm = new SqlParameter(outputParam, SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            this._dataDbContext.Database.ExecuteSqlCommand(String.Format("{0}", execProcedure), parm);

            return (int)parm.Value;
        }

        protected internal TModel SelectStoredProcedure<TModel>(String execProcedure)
        {
            return this._dataDbContext.Database.SqlQuery<TModel>(execProcedure).SingleOrDefault();
        }

        protected internal void Save()
        {
            _dataDbContext.SaveChanges();
        }
    }
}
