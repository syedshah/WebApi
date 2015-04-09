using System;
using Entities;

namespace PAFRepository.Interfaces
{
    public interface IWelshThoroughFareRepository
    {
        WelshThoroughFare GetWelshThoroughFare(String outCode, String inCode);
    }
}