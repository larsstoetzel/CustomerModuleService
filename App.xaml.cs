using CustomerModules.Commands;
using CustomerModules.Models;
using CustomerModules.Providers;
using CustomerModules.Services;
using CustomerModules.ViewModels;
using CustomerModuleService.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace CustomerModuleService
{ /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }
        public new static App Current => (App)Application.Current;
        public App()
        {
            Services = ConfigureServices();
            var dbContext = Services.GetRequiredService<CustomerContext>();
            dbContext.Database.EnsureCreated();
            this.InitializeComponent();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<CustomerContext>();
            services.AddTransient<AddModuleViewModel>();
            services.AddTransient<CreateEditCustomerViewModel>();
            services.AddTransient<CustomerListViewModel>();
            services.AddTransient<DeleteYoNViewModel>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICityProvider, CityProvider>();
            services.AddSingleton<IModuleProvider, ModuleProvider>();
            services.AddSingleton<ICustomerProvider, CustomerProvider>();
            services.AddSingleton<ICustomerCommands, CustomerCommands>();
            return services.BuildServiceProvider();
        }
    }
}
