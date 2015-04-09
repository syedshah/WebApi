using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Entities;
using PAF.Contracts;

namespace PAF.Common
{
    public static class EvaluateAddress
    {

        public static List<PAFAddress> GetAddressList(Locality locality, ThoroughFare thoroughFare, IEnumerable<DeliveryPoint> deliveryPoints)
        {
            var addressList = new List<PAFAddress>();

            foreach (var item in deliveryPoints)
            {
                string addresses = FormatAddress1(item) + FormatAddress2(thoroughFare, item) + FormatAddress3(locality);
                PAFAddress addressData = GetAddress(addresses);
                
                addressData.Town = locality.PostTown;
                addressData.PostCode = locality.Outcode.Trim().PadRight(locality.Outcode.Trim().Length + 1) + locality.Incode.Trim();

                addressList.Add(addressData);
            }

            var alphanum = new AlphanumComparator();
            addressList.Sort(alphanum);

            return addressList;
        }

        private static PAFAddress GetAddress(string addresses)
        {
            var address = new PAFAddress();
            var addressParts = addresses.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            for (int index = 0; index < addressParts.Length; index++)
            {
                switch (index)
                {
                    case 0:
                        address.Address1 = addressParts[index];
                        break;
                    case 1:
                        address.Address2 = addressParts[index];
                        break;
                    case 2:
                        address.Address3 = addressParts[index];
                        break;
                    case 3:
                        address.Address4 = addressParts[index];
                        break;
                    case 4:
                        address.Address5 = addressParts[index];
                        break;
                    default:
                         string.Format("{0}\n{1}", address.Address5, addressParts[index]);
                        break;
                }
            }

            return address;
        }

        private static string FormatAddress3(Locality locality)
        {
            return string.Format("{0}{1}",
                !string.IsNullOrWhiteSpace(locality.DoubleDepLocality)
                    ? locality.DoubleDepLocality + "|"
                    : string.Empty,
                !string.IsNullOrWhiteSpace(locality.DepLocality)
                    ? locality.DepLocality + "|"
                    : string.Empty
                );
        }

        private static string FormatAddress2(ThoroughFare thoroughFare, DeliveryPoint deliveryPoint)
        {
            return string.Format("{0}{1}{2}{3}{4}",
                ValidateNumeric(deliveryPoint.BuildingName)
                    ? deliveryPoint.BuildingName.Trim().PadRight(deliveryPoint.BuildingName.Trim().Length + 1, ' ')
                    : string.Empty,
                deliveryPoint.BuildingNumber > 0
                    ? deliveryPoint.BuildingNumber.ToString().Trim().PadRight(deliveryPoint.BuildingNumber.ToString().Trim().Length + 1, ' ')
                    : string.Empty,
                !string.IsNullOrWhiteSpace(thoroughFare.DepThoroughFareName)
                    ? thoroughFare.DepThoroughFareName.Trim().PadRight(thoroughFare.DepThoroughFareName.Trim().Length + 1, ' ')
                    : string.Empty,
                !string.IsNullOrWhiteSpace(thoroughFare.DepThoroughFareDescriptor)
                    ? thoroughFare.DepThoroughFareDescriptor + "|"
                    : string.Empty,
                !string.IsNullOrWhiteSpace(thoroughFare.ThoroughFareDescriptor)
                    ? thoroughFare.ThoroughFareName.Trim().PadRight(thoroughFare.ThoroughFareName.Trim().Length + 1, ' ') + 
                    thoroughFare.ThoroughFareDescriptor + "|"
                    : !string.IsNullOrWhiteSpace(thoroughFare.ThoroughFareName)
                    ? thoroughFare.ThoroughFareName.Trim().PadRight(thoroughFare.ThoroughFareName.Trim().Length + 1, ' ')  + "|"
                    : string.Empty
                );
        }

        private static string FormatAddress1(DeliveryPoint deliveryPoint)
        {
            return string.Format("{0}{1}{2}{3}{4}",
                !string.IsNullOrWhiteSpace(deliveryPoint.OrganisationName)
                    ? deliveryPoint.OrganisationName + "|"
                    : string.Empty,
                !string.IsNullOrWhiteSpace(deliveryPoint.DepartmentName)
                    ? deliveryPoint.DepartmentName + "|"
                    : string.Empty,
                !string.IsNullOrWhiteSpace(deliveryPoint.POBoxNumber) ? deliveryPoint.POBoxNumber + "|" : string.Empty,
                !string.IsNullOrWhiteSpace(deliveryPoint.SubBuildingName)
                    ? deliveryPoint.SubBuildingName + "|"
                    : string.Empty,
                (!string.IsNullOrWhiteSpace(deliveryPoint.BuildingName) && !(ValidateNumeric(deliveryPoint.BuildingName)))
                    ? deliveryPoint.BuildingName + "|"
                    : string.Empty
                );
        }

       public static bool ValidateNumeric(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            if (input.Length > 1 && !(char.IsNumber(Convert.ToChar(input.Substring(input.Length - 1)))))
            {
                return Regex.IsMatch(input.Substring(0, input.Length - 1), @"^[0-9-]*$");
            }
            else
            {
                return Regex.IsMatch(input, @"^[0-9-]*$");
            }
        }

       public static bool ValidatePostcode(string postcode)
       {
           return Regex.Match(postcode,
               "^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][‌​0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z])))) {0,1}[0-9][A-Za-z]{2})$",
               RegexOptions.IgnoreCase).Success;
       }

    }
}