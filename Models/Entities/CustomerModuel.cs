using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerModules.Models.Entities
{
    public class CustomerModule
    {
        public DateTime ActivationDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
        public int ModuleId { get; set; }
        public Module Module { get; set; } = new Module();
        [NotMapped]
        public bool Delete { get; set; }= false;
    }
}
