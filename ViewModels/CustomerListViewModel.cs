using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomerModules.Models.Customers;
using CustomerModules.Views;
using CustomerModuleService.Providers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace CustomerModules.ViewModels
{
    public class CustomerListViewModel : ObservableObject
    {
        private readonly ICustomerProvider _customerProvider;
        public ICommand OpenCreate { get; }
        public RelayCommand OpenEdit { get; }
        public ICommand Search { get; }
        public CustomerListViewModel(ICustomerProvider customerProvider)
        {
            _customerProvider = customerProvider;
            OpenCreate = new RelayCommand(ExeOpenCreate);
            OpenEdit = new RelayCommand(ExeOpenEdit, CanExeEdit);
            Search = new RelayCommand(ExeSearch);
        }
        private ObservableCollection<CustomerItem> _customers = new ObservableCollection<CustomerItem>();
        public ObservableCollection<CustomerItem> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }
        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set { SetProperty(ref _searchString, value); }
        }
        private CustomerItem? _selectedCustomer;
        public CustomerItem? SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                SetProperty(ref _selectedCustomer, value);
                OpenEdit.NotifyCanExecuteChanged();
            }

        }
        private bool CanExeEdit()
        {
            return (SelectedCustomer != null);
        }

        private void ExeSearch()
        {
            var data = _customerProvider.GetCustomerByNameOrAll(_searchString)
                .Select(x => new CustomerItem(x.CustomerId, x.Name, x.City.Name, x.Url, x.PortalUrl));
            Customers = new ObservableCollection<CustomerItem>(data);
        }

        private void ExeOpenEdit()
        {
            if (_selectedCustomer == null)
            {
                return;
            }
            var createEditView = new CreateEditCustomerView(_selectedCustomer.Id);

            createEditView.ShowDialog();
            ExeSearch();

        }
        private void ExeOpenCreate()
        {
            var createEditView = new CreateEditCustomerView();
            createEditView.ShowDialog();
            ExeSearch();
        }
    }
}
