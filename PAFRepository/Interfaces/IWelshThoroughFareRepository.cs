using System;
using Entities;

namespace PAFRepository.Interfaces
{
    public interface IThoroughFareRepository
    {
        ThoroughFare GetThoroughFare(String outCode, String inCode);
    }
}