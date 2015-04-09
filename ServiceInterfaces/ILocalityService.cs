using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ServiceInterfaces
{
    public interface ILocalityService
    {
        Locality GetLocality(string outCode, string inCode);

        Locality GetLocality(string postCode, bool isWelsh);

        WelshLocality GetWelshLocality(string outCode, string inCode);
    }
}
