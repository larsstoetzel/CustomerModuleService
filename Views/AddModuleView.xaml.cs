using CustomerModules.ViewModels;
using CustomerModuleService;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

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
