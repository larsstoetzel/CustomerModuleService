using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomerModules.Models.Entities;
using CustomerModules.Providers;
using CustomerModules.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CustomerModules.ViewModels
{
    public class AddModuleViewModel : ObservableObject
    {
        public ICommand AddModule { get; }
        public ICommand CloseAddModule { get; }
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
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        public void ExeCloseAdd(Window window)
        {
            window.Close();
        }
    }
}
