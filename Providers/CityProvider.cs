using CustomerModules.Models;
using CustomerModules.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CustomerModules.Providers
{
    public class CityProvider : ICityProvider
    {
        private readonly CustomerContext _context;
        public CityProvider(CustomerContext context)
        {
            _context = context;
        }
        public List<City> GetAllCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();

        }
    }
}
