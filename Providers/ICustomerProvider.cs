using CustomerModules.Models.Entities;
using System.Collections.Generic;

namespace CustomerModuleService.Providers
{
    public interface ICustomerProvider
    {
        List<Customer> GetCustomerByNameOrAll(string searchstring);
        Customer GetCustomerById(int id);
    }
}
