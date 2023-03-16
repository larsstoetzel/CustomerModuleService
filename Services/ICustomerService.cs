using CustomerModules.Models.Entities;
using System.Collections.Generic;

namespace CustomerModules.Services
{
    public interface ICustomerService
    {
        void AddEditCustomer(string name, int? customerId, int cityId, string url, string portalUrl);
        void DeleteCustomer(Customer customer);


    }

}
