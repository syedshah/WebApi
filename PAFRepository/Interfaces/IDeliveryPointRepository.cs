using System;
using System.Collections.Generic;
using Entities;

namespace PAFRepository.Interfaces
{
    public interface IDeliveryPointRepository
    {
        IList<DeliveryPoint> GetDeliveryPoints(String outCode, String inCode);

        IList<DeliveryPoint> GetDeliveryPointsByBuildingNameAndNumber(String outCode, String inCode, String buildingName, int buildingNumber);
    }
}