using System.Collections.Generic;

namespace CustomerModules.Models.Entities
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public List<CustomerModule> CustomerModules { get; set; } = new List<CustomerModule>();
    }
}
