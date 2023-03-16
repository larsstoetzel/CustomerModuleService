using CustomerModules.ViewModels;
using CustomerModuleService;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CustomerModules.Views.Dialogs
{
    /// <summary>
    /// Interaktionslogik für DeleteYoN.xaml
    /// </summary>
    public partial class DeleteYoNView : Window
    {
        private object id;

        public DeleteYoNView(int? id = null)
        {
            InitializeComponent();
            var viewModel = App.Current.Services.GetService<DeleteYoNViewModel>();
            DataContext = viewModel;
            if (id.HasValue)
            {
                viewModel.LoadCustomer(id.Value);
            }
        }

    }
}
