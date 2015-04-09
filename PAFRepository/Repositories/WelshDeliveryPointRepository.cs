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
    public class WelshDeliveryPointRepository : BaseEfRepository<DeliveryPoint>, IWelshDeliveryPointRepository
    {
        public WelshDeliveryPointRepository(String connectionString):base(new PAFDb(connectionString))
        {
            
        }

        public IList<WelshDeliveryPoint> GetWelshDeliveryPoints(string outCode, string inCode)
        {
            IList<WelshDeliveryPoint> deliveryPoints =
                this.GetEntityListByStoreProcedure<WelshDeliveryPoint>(
                    String.Format("exec stGetDeliveryPointsWelsh '{0}', '{1}'", outCode, inCode));
            return deliveryPoints;
        }

        public IList<WelshDeliveryPoint> GetWelshDeliveryPointsByBuildingNameAndNumber(string outCode, string inCode, string buildingName,
            int buildingNumber)
        {
            IList<WelshDeliveryPoint> deliveryPoints =
                this.GetEntityListByStoreProcedure<WelshDeliveryPoint>(
                    String.Format("exec stGetDeliveryPointsWelshByBuildingNameAndBuildingNumber '{0}', '{1}', {2}', {3}", outCode, inCode, buildingName, buildingNumber));
            return deliveryPoints;
        }
    }
}
