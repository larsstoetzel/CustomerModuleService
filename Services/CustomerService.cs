using CustomerModules.Models;
using CustomerModules.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CustomerModules.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _context;
        public CustomerService(CustomerContext context)
        {
            _context = context;
        }

        public void AddEditCustomer(string name, int? id, int cityId, string url, string portalUrl,
                                List<CustomerModule> modules)
        {
            var customermodules = modules.Where(x => x.Delete == false).ToList();
            customermodules.ForEach(x =>
            {
                x.Customer = null;
                x.ModuleId = x.Module.ModuleId;
                x.Module = null;
            });

            var customer = new Customer()
            {
                Name = name,
                CityId = cityId,
                Url = url,
                PortalUrl = portalUrl,
                CustomerModules = customermodules
            };
            if (id != null)
            {
                var moduleToDelete = modules.Where(x => x.Delete).Select(x => x.ModuleId).ToList();
                var currentCustomer = _context.Customers.Include(x => x.Modules)
                     .Single(x => x.CustomerId == id);
                currentCustomer.PortalUrl = portalUrl;
                currentCustomer.Url = url;
                currentCustomer.CityId = cityId;
                currentCustomer.Name = name;
                currentCustomer.CustomerModules = new List<CustomerModule>();
                customermodules.ForEach(x =>
                {
                    if (currentCustomer.CustomerModules.Any(y => y.ModuleId == x.ModuleId))
                    {
                        return;
                    }
                    currentCustomer.CustomerModules.Add(x);
                });
            }
            else
            {
                _context.Add(customer);
            }
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers
            .AsNoTracking()
            .Where(c => c.CustomerId == customer.CustomerId)
            .ExecuteDelete();
            _context.SaveChanges();
        }
    }
}
