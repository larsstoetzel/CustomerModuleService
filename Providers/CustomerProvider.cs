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
