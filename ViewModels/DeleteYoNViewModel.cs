using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomerModules.Commands;
using CustomerModules.Models.Entities;
using CustomerModules.Services;
using CustomerModuleService.Providers;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CustomerModules.ViewModels
{
    public class DeleteYoNViewModel : ObservableObject
    {
        private readonly ICustomerCommands _commands;
        private readonly ICustomerService _service;
        private readonly ICustomerProvider _provider;
        public ICommand CloseDeleteViewCommand { get; }
        public ICommand DeleteCustomerCommand { get; set; }
        public DeleteYoNViewModel(ICustomerCommands commands, ICustomerService service, ICustomerProvider provider)
        {
            _commands = commands;
            _provider = provider;
            _service = service;
            CloseDeleteViewCommand = new RelayCommand(ExecuteCloseDeleteDialog);
            DeleteCustomerCommand = new RelayCommand(ExecuteAcceeptDeleteCustomer);

        }
        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set { SetProperty(ref _customer, value); }
        }

        private void ExecuteCloseDeleteDialog()
        {
            var view = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            view.DialogResult = true;
            view.Close();
        }
        public void LoadCustomer(int id)
        {
            Customer = _provider.GetCustomerById(id);
        }
        private void ExecuteAcceeptDeleteCustomer()
        {
            _service.DeleteCustomer(_customer);
            ExecuteCloseDeleteDialog();
            _commands.ExeCloseCreateEdit();
        }
    }
}
