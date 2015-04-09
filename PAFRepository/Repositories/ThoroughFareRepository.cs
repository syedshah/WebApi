using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFRepository;
using Entities;
using PAFRepository.Context;
using PAFRepository.Interfaces;

namespace PAFRepository.Repositories
{
    public class ThoroughFareRepository: BaseEfRepository<ThoroughFare>, IThoroughFareRepository
    {
        public ThoroughFareRepository(String connectionString):base(new PAFDb(connectionString))
        {
            
        }

        public ThoroughFare GetThoroughFare(string outCode, string inCode)
        {
            return this.SelectStoredProcedure<ThoroughFare>(String.Format("exec stGetThoroughFare '{0}', '{1}'", outCode, inCode));
        }
    }
}
