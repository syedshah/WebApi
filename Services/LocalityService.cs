using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PAFRepository.Interfaces;
using ServiceInterfaces;

namespace Services
{
    public class LocalityService : ILocalityService
    {
        private ILocalityRepository _localityRepository;
        private IWelshLocalityRepository _welshLocalityRepository;

        public LocalityService(ILocalityRepository localityRepository, IWelshLocalityRepository welshLocalityRepository)
        {
            this._localityRepository = localityRepository;
            this._welshLocalityRepository = welshLocalityRepository;
        }

        public Locality GetLocality(string outCode, string inCode)
        {
            try
            {
                Locality locality = _localityRepository.GetLocality(outCode, inCode);
                return locality;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public WelshLocality GetWelshLocality(string outCode, string inCode)
        {
            try
            {
                WelshLocality welshLocality = _welshLocalityRepository.GetWelshLocality(outCode, inCode);
                return welshLocality;
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public Locality GetLocality(string postCode, bool isWelsh)
        {
            postCode = postCode.Trim();
            var locality = new Locality();

            if (postCode.Length >= 3)
            {
                string outCode = postCode.Substring(0, postCode.Length - 3).TrimEnd(new char[0]);
                string inCode = postCode.Substring(postCode.Length - 3);

                locality = GetLocality(outCode, inCode);

                if (locality == null)
                {
                    WelshLocality welshLocality = GetWelshLocality(outCode, inCode);

                    if (welshLocality != null)
                    {
                        locality = new Locality
                        {
                            LocalityID = welshLocality.WelshLocalityID,
                            IsWelsh = true,
                            Outcode = welshLocality.Outcode,
                            Incode = welshLocality.Incode,
                            PostCodeType = welshLocality.PostCodeType,
                            PostTown = welshLocality.PostTown,
                            DepLocality = welshLocality.DepLocality,
                            DoubleDepLocality = welshLocality.DoubleDepLocality,
                            PostTownTidy = welshLocality.PostTownTidy,
                            DepLocalityTidy = welshLocality.DepLocalityTidy
                        };
                    }
                }
                else
                {
                    locality.IsWelsh = false;
                }
            }
            return locality;
        }
    }
}
