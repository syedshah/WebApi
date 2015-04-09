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
    public class DeliveryPointRepository : BaseEfRepository<DeliveryPoint>, IDeliveryPointRepository
    {
        public DeliveryPointRepository(String connectionString):base(new PAFDb(connectionString))
        {
            
        }

        public IList<DeliveryPoint> GetDeliveryPoints(string outCode, string inCode)
        {
            IList<DeliveryPoint> deliveryPoints =
                this.GetEntityListByStoreProcedure<DeliveryPoint>(String.Format(
                    "exec stGetDeliveryPoints '{0}', '{1}'", outCode, inCode));
            return deliveryPoints;
        }

        public IList<DeliveryPoint> GetDeliveryPointsByBuildingNameAndNumber(string outCode, string inCode, string buildingName, int buildingNumber)
        {
            IList<DeliveryPoint> deliveryPoints =
               this.GetEntityListByStoreProcedure<DeliveryPoint>(String.Format(
               "exec stGetDeliveryPointsByBuildingNameAndBuildingNumber '{0}', '{1}', '{2}', {3}", outCode, inCode, !string.IsNullOrEmpty(buildingName) ? buildingName : null, buildingNumber));
            return deliveryPoints;
        }
    }
}
