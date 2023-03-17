using CustomerModules.Models.Entities;
using System.Collections.Generic;

namespace CustomerModules.Services
{
    public interface ICustomerService
    {
        void AddEditCustomer(string name, int? id, int cityId, string url, string portalUrl,
                                List<CustomerModule> modules);
        void DeleteCustomer(Customer customer);




    }

}
