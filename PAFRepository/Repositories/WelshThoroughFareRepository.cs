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
    public class WelshThoroughFareRepository: BaseEfRepository<ThoroughFare>, IWelshThoroughFareRepository
    {
        public WelshThoroughFareRepository(String connectionString):base(new PAFDb(connectionString))
        {
            
        }

        public WelshThoroughFare GetWelshThoroughFare(string outCode, string inCode)
        {
            return this.SelectStoredProcedure<WelshThoroughFare>(String.Format("exec stGetThoroughFareWelsh '{0}', '{1}'", outCode, inCode));
        }
    }
}
