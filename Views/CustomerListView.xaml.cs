using CustomerModules.ViewModels;
using CustomerModuleService;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace CustomerModules.Views
{
    /// <summary>
    /// Interaction logic for CustomerListView.xaml
    /// </summary>
    public partial class CustomerListView : Window
    {

        public CustomerListView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<CustomerListViewModel>();

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri)
            { UseShellExecute = true });
        }

        private void lv_CustomerList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void tbx_SearchCustomer_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void tbx_SearchCustomer_TouchEnter(object sender, System.Windows.Input.TouchEventArgs e)
        {

        }
    }
}
