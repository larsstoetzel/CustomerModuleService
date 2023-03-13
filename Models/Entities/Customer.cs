using System.Collections.Generic;

namespace CustomerModules.Models.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string PortalUrl { get; set; } = string.Empty;
        public ICollection<Module> Modules { get; set; } = new List<Module>();
        public List<CustomerModule> CustomerModules { get; set; } = new List<CustomerModule>();
        public City City { get; set; } = null!;
    }
}
