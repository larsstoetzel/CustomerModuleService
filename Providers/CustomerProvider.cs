using CustomerModules.Models;
using CustomerModules.Models.Entities;
using CustomerModuleService.Providers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CustomerModules.Providers
{
    public class CustomerProvider : ICustomerProvider
    {
        private readonly CustomerContext _context;
        public CustomerProvider(CustomerContext context)
        {
            _context = context;
        }
       public Customer GetCustomerById(int id)
        {
            return _context.Customers
                .AsNoTracking()
                .Include(x => x.CustomerModules)
                .ThenInclude(x => x.Module)
                .Include(x => x.City)
                .Single(x => x.CustomerId == id);
        }
        public List<Customer> GetCustomerByNameOrAll(string searchString)
        {
            if (searchString != null)
            {
                return _context.Customers
                    .AsNoTracking()
                    .Include(x => x.City)
                    .Where(x => x.Name.ToUpper()
                    .Contains(searchString.ToUpper()))
                    .ToList();
            }
            else
            {
                return _context.Customers
                .AsNoTracking()
                .Include(x => x.City)
                .OrderBy(cu => cu.Name)
                .ToList();
            }

        }
    }
}
