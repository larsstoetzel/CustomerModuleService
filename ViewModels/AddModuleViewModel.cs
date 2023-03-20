using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomerModules.Models.Entities;
using CustomerModules.Providers;
using CustomerModules.Services;
using CustomerModules.Validators;
using FluentValidation;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CustomerModules.ViewModels
{
    public class AddModuleViewModel : ObservableObject, IDataErrorInfo
    {
        public ICommand AddModule { get; }
        public ICommand CloseAddModule { get; }
        private readonly ModuleValidation _validator = new();

        public AddModuleViewModel(IModuleProvider moduleProvider, ICustomerService customerService)
        {
            AddModule = new RelayCommand<Window>(ExeAddModule);
            CloseAddModule = new RelayCommand<Window>(ExeCloseAdd);
            Modules = new ObservableCollection<Module>(moduleProvider.GetAllModules());
            _customerService = customerService;
            _moduleProvider = moduleProvider;
        }
        private IModuleProvider _moduleProvider;
        private ICustomerService _customerService;

        private ObservableCollection<Module> _modules;
        public ObservableCollection<Module> Modules
        {
            get { return _modules; }
            set { SetProperty(ref _modules, value); }
        }
        private Module _module;
        public Module Module
        {
            get { return _module; }
            set { SetProperty(ref _module, value); }
        }
        private DateTime _activationDate;
        public DateTime ActivationDate
        {
            get => _activationDate;
            set => SetProperty(ref _activationDate, value);
        }

        public void ExeAddModule(Window window)
        {
            if (HasErrors())
            {
                return;
            }

            window.DialogResult = true;
           window.Close();
            
        }

        public void ExeCloseAdd(Window window)
        {
            window.Close();
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
    }
}
