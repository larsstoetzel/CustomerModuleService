using CustomerModules.Models;
using CustomerModules.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CustomerModules.Providers
{
    public class ModuleProvider : IModuleProvider
    {
        private readonly CustomerContext _context;
        public ModuleProvider(CustomerContext context)
        {
            _context = context;
        }
        public List<Module> GetAllModules()
        {
            return _context.Modules.AsNoTracking().OrderBy(m => m.Name).ToList();

        }
        public Module GetModuleById(int id)
        {
            return _context.Modules.AsNoTracking()
                .Include(x => x.CustomerModules)
                .Include(x => x.Customers)
                .Single(x => x.ModuleId == id);
        }

    }
}
