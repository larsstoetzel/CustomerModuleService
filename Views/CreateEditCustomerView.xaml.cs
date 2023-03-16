using CustomerModules.ViewModels;
using CustomerModuleService;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace CustomerModules.Views
{
    /// <summary>
    /// Interaktionslogik für CreateEditCustomerView.xaml
    /// </summary>
    public partial class CreateEditCustomerView : Window
    {
        public CreateEditCustomerView(int? id = null)
        {
            InitializeComponent();
            var viewModel = App.Current.Services.GetService<CreateEditCustomerViewModel>();
            DataContext = viewModel;
            if (id.HasValue)
            {
                viewModel.LoadCustomer(id.Value);
            }
        }

        private void lbx_ModuleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tbx_Url_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
