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
        }


        private void lbx_ModuleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tbx_Url_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
