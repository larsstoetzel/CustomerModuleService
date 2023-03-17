using CustomerModules.Models.Entities;
using System.Collections.Generic;

namespace CustomerModules.Providers
{
    public interface IModuleProvider
    {
        List<Module> GetAllModules();
        Module GetModuleById(int id);
    }
}
