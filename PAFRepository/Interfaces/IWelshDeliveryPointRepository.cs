using System;
using System.Collections.Generic;
using Entities;

namespace PAFRepository.Interfaces
{
    public interface IWelshDeliveryPointRepository
    {
        IList<WelshDeliveryPoint> GetWelshDeliveryPoints(String outCode, String inCode);

        IList<WelshDeliveryPoint> GetWelshDeliveryPointsByBuildingNameAndNumber(String outCode, String inCode, String buildingName, int buildingNumber);
    }
}