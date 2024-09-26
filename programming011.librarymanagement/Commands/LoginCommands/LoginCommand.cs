using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.UI.Helpers;
using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.LoginCommands
{
    internal class LoginCommand : ICommand
    {
        private readonly LoginWindowViewModel _viewModel;

        public LoginCommand(LoginWindowViewModel viewModel)
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
            string username = _viewModel.LoginModel.Username;
            User user = ApplicationContext.UnitOfWork.UserRepository.GetByUsername(username);

            if(user == null)
            {
                _viewModel.ErrorVisibility = Visibility.Visible;
                return;
            }

            string password = ((PasswordBox)parameter).Password;

            string passwordHash = HashHelper.Hash(password);
            if(passwordHash == user.PasswordHash)
            {
                AdminWindow adminWindow = new AdminWindow();
                AdminWindowViewModel viewModel = new AdminWindowViewModel(adminWindow);
                adminWindow.DataContext = viewModel;
                //Something different from all pages
                viewModel.CenterGrid = adminWindow.grdCenter;
                adminWindow.Show();
                _viewModel.Window.Close();
                return;
            }

            _viewModel.ErrorVisibility = Visibility.Visible;
        }
    }
}
