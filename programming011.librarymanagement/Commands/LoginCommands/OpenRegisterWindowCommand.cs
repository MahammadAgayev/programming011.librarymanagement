using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.LoginCommands
{
    public class OpenRegisterWindowCommand : ICommand
    {
        private readonly LoginWindowViewModel _viewModel;

        public OpenRegisterWindowCommand(LoginWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RegisterWindow window = new RegisterWindow();
            RegisterViewModel viewModel = new RegisterViewModel(window);
            window.DataContext = viewModel;

            window.Show();
            _viewModel.Window.Close();
        }
    }
}
