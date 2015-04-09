using System;
using Entities;
using Repository;

namespace PAFRepository.Interfaces
{
    public interface IWelshLocalityRepository
    {
        WelshLocality GetWelshLocality(String outCode, String inCode);
    }
}