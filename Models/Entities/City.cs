using System.Collections.Generic;

namespace CustomerModules.Models.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
