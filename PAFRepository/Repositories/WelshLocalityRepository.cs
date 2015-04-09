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
    public class WelshLocalityRepository : BaseEfRepository<Locality>, IWelshLocalityRepository
    {
        public WelshLocalityRepository(String connectionString) 
            : base(new PAFDb(connectionString))
        {
        }

        public WelshLocality GetWelshLocality(String outCode, String inCode)
        {
            return this.SelectStoredProcedure<WelshLocality>(String.Format("exec stGetLocalityWelsh '{0}', '{1}'", outCode,
                    inCode));
        }
    }
}
