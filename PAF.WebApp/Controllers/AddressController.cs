using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Serialization;
using PAF.Common;
using PAF.Contracts;


namespace PAF.WebApp.Controllers
{
    public class AddressController : ApiController
    {
        private readonly IAddressService _addressService;
        private readonly List<string> _errors = new List<string>();

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        /// <summary>
        /// Find addresses by postcode
        /// </summary>
        /// <param name="postcode">postcode</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>List of addresses</returns>
        [ActionName("GetAddressByPostcode")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<PAFAddress>))]
        public HttpResponseMessage GetAddressByPostcode(string postcode)
        {
            HttpRequestMessage request = Request;
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                
                IEnumerable<PAFAddress> addresses = GetAddresses(postcode, string.Empty, string.Empty);

                response = _errors.Count == 0 ? 
                    request.CreateResponse<IEnumerable<PAFAddress>>(HttpStatusCode.OK, addresses) : 
                    request.CreateResponse<string[]>(HttpStatusCode.BadRequest, _errors.ToArray());

                return response;
            });

        }

        private IEnumerable<PAFAddress> GetAddresses(string postcode, string buildingName, string buildingNumber)
        {
            postcode = (Regex.Replace(postcode, @"\s+", ""));
            IEnumerable<PAFAddress> addressList = null;

            if (EvaluateAddress.ValidatePostcode(postcode))
            {
                if (string.IsNullOrWhiteSpace(buildingName) && string.IsNullOrWhiteSpace(buildingNumber))
                {
                    addressList = _addressService.GetAddressesByPostcode(postcode); 
                }
                else
                {
                    addressList = _addressService.GetAddress(buildingName, buildingNumber, postcode);
                }
                
                if (addressList == null)
                    _errors.Add("Address not found");
            }
            else
            {
                _errors.Add("Postcode is invalid");
            }
            return addressList;
        }

        /// <summary>
        /// Find addresses by building name or number and postcode.
        /// </summary>
        /// <param name="postcode">postcode</param>
        /// <param name="buildingName">optional: building name</param>
        /// <param name="buildingNumber">optional: building/house number</param>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>List of addresses</returns>
        [ActionName("GetAddressByBuilding")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<PAFAddress>))]
        public HttpResponseMessage GetAddressByBuilding(string postcode, string buildingName="",
            string buildingNumber="")
        {
            HttpRequestMessage request = Request;
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<PAFAddress> addresses = GetAddresses(postcode, buildingName.Trim(), buildingNumber);

                response = _errors.Count == 0 ?
                    request.CreateResponse<IEnumerable<PAFAddress>>(HttpStatusCode.OK, addresses) :
                    request.CreateResponse<string[]>(HttpStatusCode.BadRequest, _errors.ToArray());

                return response;
            });
        }

        protected HttpResponseMessage GetHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> codeToExecute)
        {
            HttpResponseMessage response = null;

            try
            {
                response = codeToExecute.Invoke();
            }
            catch (SecurityException ex)
            {
                response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
                _errors.Add(ex.Message);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
                _errors.Add(ex.Message);
            }
            catch (FaultException ex)
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                _errors.Add(ex.Message);
            }
            catch (Exception ex)
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                _errors.Add(ex.Message);
            }

            return response;
        }

    }
}
