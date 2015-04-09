using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ServiceInterfaces
{
    public interface IDeliveryPointService
    {
        IList<DeliveryPoint> GetDeliveryPoints(string outCode, string inCode);

        IList<WelshDeliveryPoint> GetWelshDeliveryPoints(string outCode, string inCode);

        IList<DeliveryPoint> GetDeliveryPoints(Locality locality);

        IList<DeliveryPoint> GetDeliveryPointsByBuildingNameAndNumber(Locality locality, String buildingName, int buildingNumber);

    }
}
