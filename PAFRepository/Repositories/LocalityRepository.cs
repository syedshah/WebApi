using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFRepository;
using Entities;
using PAFRepository.Context;
using PAFRepository.Interfaces;

namespace PAFRepository.Repositories
{
    public class LocalityRepository : BaseEfRepository<Locality>, ILocalityRepository
    {
        public LocalityRepository(String connectionString) 
            : base(new PAFDb(connectionString))
        {
        }

        public Locality GetLocality(String outCode, String inCode)
        {
            return this.SelectStoredProcedure<Locality>(String.Format("exec stGetLocality '{0}', '{1}'", outCode,
                inCode));
        }
        
    }
}
