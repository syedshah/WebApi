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
    public class ThoroughFareService: IThoroughFareService
    {
        private readonly IThoroughFareRepository _thoroughFareRepository;
        private readonly IWelshThoroughFareRepository _welshThoroughFareRepository;

        public ThoroughFareService(IThoroughFareRepository thoroughFareRepository, IWelshThoroughFareRepository welshThoroughFareRepository)
        {
            _thoroughFareRepository = thoroughFareRepository;
            _welshThoroughFareRepository = welshThoroughFareRepository;
        }

        public ThoroughFare GetThoroughFare(string outCode, string inCode)
        {
            try
            {
                return _thoroughFareRepository.GetThoroughFare(outCode, inCode);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public WelshThoroughFare GetWelshThoroughFare(string outCode, string inCode)
        {
            try
            {
                return _welshThoroughFareRepository.GetWelshThoroughFare(outCode, inCode);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public ThoroughFare GeThoroughFare(Locality locality)
        {
            try
            {
                ThoroughFare thoroughFare = null;
                if (!locality.IsWelsh)
                {
                    thoroughFare = GetThoroughFare(locality.Outcode, locality.Incode);
                    
                }
                else
                {
                    var welshThoroughFare = GetWelshThoroughFare(locality.Outcode, locality.Incode);

                    if (welshThoroughFare != null)
                    {
                        thoroughFare = new ThoroughFare
                        {
                            ThoroughFareID = welshThoroughFare.WelshThoroughFareID,
                            Outcode = welshThoroughFare.Outcode,
                            Incode = welshThoroughFare.Incode,
                            PostCodeType = welshThoroughFare.PostCodeType,
                            Sequence = welshThoroughFare.Sequence,
                            ThoroughFareName = welshThoroughFare.ThoroughFareName,
                            ThoroughFareDescriptor = welshThoroughFare.ThoroughFareDescriptor,
                            DepThoroughFareName = welshThoroughFare.DepThoroughFareName,
                            DepThoroughFareDescriptor = welshThoroughFare.ThoroughFareDescriptor,
                            ThoroughFareNameTidy = welshThoroughFare.ThoroughFareNameTidy,
                            DepThoroughFareNameTidy = welshThoroughFare.DepThoroughFareNameTidy
                        };    
                    }
                    
                }

                return thoroughFare;
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
