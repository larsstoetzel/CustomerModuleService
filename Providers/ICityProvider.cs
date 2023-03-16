using CustomerModules.Models.Entities;
using System.Collections.Generic;

namespace CustomerModules.Providers
{
    public interface ICityProvider
    {
        List<City> GetAllCities();

    }
}
