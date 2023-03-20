using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomerModules.Commands;
using CustomerModules.Models;
using CustomerModules.Models.Entities;
using CustomerModules.Providers;
using CustomerModules.Services;
using CustomerModules.Validators;
using CustomerModules.Views;
using CustomerModules.Views.Dialogs;
using CustomerModuleService.Providers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace CustomerModules.ViewModels
{
    public class CreateEditCustomerViewModel : ObservableObject, IDataErrorInfo
    {
        public ICommand OpenAddModule { get; }
        public ICommand OpenDelete { get; }
        public ICommand CloseCreateEdit { get; }
        public ICommand SaveCommand { get; }
        private readonly ICustomerService customerService;
        private readonly ICustomerCommands _commands;
        private readonly IModuleProvider _moduleProvider;
        private readonly CustomerValidation _validator;
        private readonly CustomerContext _context;
        public CreateEditCustomerViewModel(ICustomerCommands commands, ICustomerService customerService,
        ICityProvider cityProvider, ICustomerProvider customerProvider,
        IModuleProvider moduleProvider, CustomerContext context)
        {
            _context = context;
            _validator = new CustomerValidation(_context);
            OpenAddModule = new RelayCommand(ExeOpenAddModule);
            OpenDelete = new RelayCommand(ExeOpenDelete, CanExeDelete);
            SaveCommand = new RelayCommand(ExeCreate);
            Cities = new ObservableCollection<City>(cityProvider.GetAllCities());
            Modules = new ObservableCollection<CustomerModule>();
            _customerService = customerService;
            _cityProvider = cityProvider;
            _customerProvider = customerProvider;
            _commands = commands;
            _moduleProvider = moduleProvider;
        }
        private ICustomerService _customerService;
        private ICityProvider _cityProvider;
        private ICustomerProvider _customerProvider;

        private ObservableCollection<City> _cities;
        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set { SetProperty(ref _cities, value); }
        }
        private City _selectedCity;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set { SetProperty(ref _selectedCity, value); }
        }
        private string city;
        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }
        private int? customerId;
        public int? CustomerId
        {
            get => customerId;
            set => SetProperty(ref customerId, value);
        }
        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string url;
        public string Url
        {
            get => url;
            set => SetProperty(ref url, value);
        }
        private string portalUrl;
        public string PortalUrl
        {
            get => portalUrl;
            set => SetProperty(ref portalUrl, value);
        }
        private bool deleteModule;
        public bool DeleteModule
        {
            get => deleteModule;
            set => SetProperty(ref deleteModule, value);
        }
        private ObservableCollection<CustomerModule> modules;
        public ObservableCollection<CustomerModule> Modules
        {
            get { return modules; }
            set { SetProperty(ref modules, value); }
        }

        public string Error

        {
            get
            {
                if (_validator != null)
                {
                    var results = _validator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string
                            .Join(Environment.NewLine, results.Errors
                            .Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        private bool HasErrors()
        {
            var results = _validator.Validate(this);
            return results.Errors.Any();
        }
        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _validator.Validate(this).Errors
                    .FirstOrDefault(x => x.PropertyName == columnName);
                if (firstOrDefault != null)
                {
                    return firstOrDefault.ErrorMessage;
                }
                return string.Empty;
            }
        }

        public void LoadCustomer(int id)
        {
            var customer = _customerProvider.GetCustomerById(id);

            Name = customer.Name;
            City = customer.City.Name;
            Url = customer.Url;
            PortalUrl = customer.PortalUrl;
            SelectedCity = customer.City;
            CustomerId = customer.CustomerId;
            Modules = new ObservableCollection<CustomerModule>(customer.CustomerModules);
        }
        private bool CanExeDelete()
        {
            return (CustomerId != null);
        }

        public void ExeCreate()
        {
            if (HasErrors())
            {
                return;
            }
            _customerService.AddEditCustomer(Name, CustomerId, SelectedCity.CityId, Url, PortalUrl, Modules.ToList());
            _commands.ExeCloseCreateEdit();
        }

        private void ExeOpenAddModule()
        {
            var addModuleView = new AddModuleView();
            addModuleView.ShowDialog();
            if (addModuleView.DialogResult == true)
            {
                var data = addModuleView.DataContext as AddModuleViewModel;
                var newModule = new CustomerModule
                {
                    Module = data.Module,
                    ActivationDate = data.ActivationDate,
                };
                Modules.Add(newModule);
            }
        }

        private void ExeOpenDelete()
        {
            var deleteCustView = new DeleteYoNView(CustomerId);

            deleteCustView.ShowDialog();
        }
    }
}

