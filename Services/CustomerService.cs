using CustomerModules.Models;
using CustomerModules.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
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
        
        public void AddEditCustomer(string name, int? id, int cityId, string url, string portalUrl)
        {
            var customer = new Customer()
            {
                Name = name,
                CityId = cityId,
                Url = url,
                PortalUrl = portalUrl
            };
            if (id != null)
            {
                customer.CustomerId = (int)id;
                _context.Update(customer);
            }
            else
            {
                _context.Add(customer);
            }
            _context.SaveChanges();
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
