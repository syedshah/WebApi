using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ServiceInterfaces
{
    public interface IThoroughFareService
    {
        ThoroughFare GetThoroughFare(string outCode, string inCode);

        WelshThoroughFare GetWelshThoroughFare(string outCode, string inCode);

        ThoroughFare GeThoroughFare(Locality locality);
    }
}
