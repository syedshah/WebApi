using System;
using Entities;
using Repository;

namespace PAFRepository.Interfaces
{
    public interface ILocalityRepository
    {
        Locality GetLocality(String outCode, String inCode);
    }
}