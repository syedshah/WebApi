using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml.Serialization;

namespace PAF.Contracts
{
    [ServiceContract]
    public interface IAddressService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<PAFAddress> GetAddress(String buildingName, String buildingNumber, String postcode);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped)]
        IEnumerable<PAFAddress> GetAddressesByPostcode(String postcode);
    }
}
