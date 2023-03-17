using CustomerModules.ViewModels;
using CustomerModuleService;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomerModules.Views
{
    /// <summary>
    /// Interaktionslogik für AddModuleView.xaml
    /// </summary>
    public partial class AddModuleView : Window
    {       
        public AddModuleView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<AddModuleViewModel>();
        }
       
    }
}
