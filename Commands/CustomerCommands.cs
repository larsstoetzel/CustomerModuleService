using CommunityToolkit.Mvvm.Input;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CustomerModules.Commands
{
    public class CustomerCommands : ICustomerCommands
    {
        public ICommand CloseCreateEdit { get; }
        public ICommand CloseDeleteViewCommand { get; }

        public CustomerCommands()
        {
            CloseDeleteViewCommand = new RelayCommand(ExecuteCloseDeleteDialog);
            CloseCreateEdit = new RelayCommand(ExeCloseCreateEdit);
        }
        public void ExeCloseCreateEdit()
        {
            var view = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            view.DialogResult = true;
            view.Close();
        }
        public void ExecuteCloseDeleteDialog()
        {
            var view = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            view.DialogResult = true;
            view.Close();
        }

    }
}
