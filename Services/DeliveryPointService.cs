using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PAFRepository.Interfaces;
using ServiceInterfaces;

namespace Services
{
    public class DeliveryPointService : IDeliveryPointService
    {
        private readonly IDeliveryPointRepository _deliveryPointRepository;
        private readonly IWelshDeliveryPointRepository _welshDeliveryPointRepository;

        public DeliveryPointService(IDeliveryPointRepository deliveryPointRepository, IWelshDeliveryPointRepository welshDeliveryPointRepository)
        {
            _deliveryPointRepository = deliveryPointRepository;
            _welshDeliveryPointRepository = welshDeliveryPointRepository;
        }

        public IList<DeliveryPoint> GetDeliveryPoints(string outCode, string inCode)
        {
            try
            {
                return _deliveryPointRepository.GetDeliveryPoints(outCode, inCode);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<WelshDeliveryPoint> GetWelshDeliveryPoints(string outCode, string inCode)
        {
            try
            {
                return _welshDeliveryPointRepository.GetWelshDeliveryPoints(outCode, inCode);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<DeliveryPoint> GetDeliveryPoints(Locality locality)
        {
            try
            {
                IList<DeliveryPoint> deliveryPoints = null;
                if (!locality.IsWelsh)
                {
                    deliveryPoints = GetDeliveryPoints(locality.Outcode, locality.Incode);

                }
                else
                {
                    IList<WelshDeliveryPoint> welshDeliveryPoints = GetWelshDeliveryPoints(locality.Outcode, locality.Incode);

                    if (welshDeliveryPoints != null)
                    {
                        deliveryPoints = DeliveryPointList(welshDeliveryPoints);
                    }
                }

                return deliveryPoints;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static IList<DeliveryPoint> DeliveryPointList(IEnumerable<WelshDeliveryPoint> welshDeliveryPoints)
        {
            IList<DeliveryPoint> deliveryPoints = new List<DeliveryPoint>();
            if (welshDeliveryPoints != null)
                welshDeliveryPoints.ToList().ForEach(x => deliveryPoints.Add(new DeliveryPoint()
                {
                    DeliveryPointID = x.WelshDeliveryPointID,
                    Outcode = x.Outcode,
                    Incode = x.Incode,
                    PostCodeType = x.PostCodeType,
                    Sequence = x.Sequence,
                    DPS = x.DPS,
                    BuildingNumber = x.BuildingNumber,
                    BuildingName = x.BuildingName,
                    SubBuildingName = x.SubBuildingName,
                    OrganisationName = x.OrganisationName,
                    DepartmentName = x.DepartmentName,
                    POBoxNumber = x.POBoxNumber,
                    NoOfHouseholds = x.NoOfHouseholds,
                    SmallUserOrganisation = x.SmallUserOrganisation,
                    AddressKey = x.AddressKey,
                    OrganisationKey = x.OrganisationKey
                }));
            return deliveryPoints;
        }

        public IList<DeliveryPoint> GetDeliveryPointsByBuildingNameAndNumber(Locality locality, string buildingName,
            int buildingNumber)
        {
            IList<DeliveryPoint> deliveryPoints = null;
            if (!locality.IsWelsh)
            {
                deliveryPoints = _deliveryPointRepository.GetDeliveryPointsByBuildingNameAndNumber(locality.Outcode,
                    locality.Incode,
                    buildingName, buildingNumber);
            }
            else
            {
                IList<WelshDeliveryPoint> welshDeliveryPoints =
                    _welshDeliveryPointRepository.GetWelshDeliveryPointsByBuildingNameAndNumber(locality.Outcode,
                        locality.Incode, buildingName, buildingNumber);

                if (welshDeliveryPoints != null)
                {
                    deliveryPoints = DeliveryPointList(welshDeliveryPoints);
                }
            }

            return deliveryPoints;
        }

    }
}
