using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PAF.Contracts;

namespace PAF.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // GET: Address
        public ActionResult Index(string searchTerm = null)
        {
            IEnumerable<PAFAddress> addressList = null;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                addressList = _addressService.GetAddressesByPostcode(searchTerm);
            }
            return View(addressList);
        }

        public ActionResult SearchAddress(string postcode, string buildingName, string buildingNumber)
        {
            List<PAFAddress> addressData = null;
            if (!string.IsNullOrEmpty(postcode))
            {
                addressData = _addressService.GetAddress(buildingName.Trim(), buildingNumber.Trim(), postcode.Trim());    
            }
            

            return View(addressData);
        }
       
    }
}
