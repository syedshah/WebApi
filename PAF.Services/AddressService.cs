using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel.Web;
using System.Text.RegularExpressions;
using System.Web;
using Entities;
using PAF.Common;
using PAF.Contracts;
using ServiceInterfaces;

namespace PAF.Services
{
    public class AddressService : IAddressService
    {
        private readonly ILocalityService _localityService;
        private readonly IThoroughFareService _thoroughFareService;
        private readonly IDeliveryPointService _deliveryPointService;

        public AddressService(ILocalityService localityService, IThoroughFareService thoroughFareService, IDeliveryPointService deliveryPointService)
        {
            _localityService = localityService;
            _thoroughFareService = thoroughFareService;
            _deliveryPointService = deliveryPointService;
        }

        public List<PAFAddress> GetAddress(string buildingName, string buildingNumber, string postcode)
        {
            List<PAFAddress> addressList = null;
            var locality = _localityService.GetLocality(postcode, false);

            if (locality != null)
            {
                var thoroughFare = _thoroughFareService.GeThoroughFare(locality);
                int houseNumber;
                if(!int.TryParse(buildingNumber, out houseNumber))
                    houseNumber = 0;

                var deliveryPoints = _deliveryPointService.GetDeliveryPointsByBuildingNameAndNumber(locality, buildingName,
                    houseNumber);

                if (deliveryPoints.Count <= 0) return null;
                addressList = EvaluateAddress.GetAddressList(locality, thoroughFare, deliveryPoints);
            }

            return addressList;
        }

        public IEnumerable<PAFAddress> GetAddressesByPostcode(string postcode)
        {
            IEnumerable<PAFAddress> addressList = null;
            var locality = _localityService.GetLocality(postcode, false);

            if (locality != null)
            {
                var thoroughFare = _thoroughFareService.GeThoroughFare(locality);
                var deliveryPoints = _deliveryPointService.GetDeliveryPoints(locality);

                if (deliveryPoints.Count > 0)
                {
                    addressList = EvaluateAddress.GetAddressList(locality, thoroughFare, deliveryPoints);
                }
            }

            return addressList;
        }

        
    }
}