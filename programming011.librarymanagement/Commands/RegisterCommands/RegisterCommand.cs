using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.UI.Helpers;
using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.RegisterCommands
{
    public class RegisterCommand : ICommand
    {
        private readonly RegisterViewModel _viewModel;

        public RegisterCommand(RegisterViewModel viewModel)
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
            string password = ((PasswordBox)parameter).Password;
            string username = _viewModel.RegisterModel.Username;

            User user = new User
            {
                Username = username,
                PasswordHash = HashHelper.Hash(password),
                Created = DateTime.Now,
            };

            ApplicationContext.UnitOfWork.UserRepository.Add(user);

            LoginWindow loginWindow = new LoginWindow();
            LoginWindowViewModel loginWindowViewModel = new LoginWindowViewModel(loginWindow);

            loginWindow.DataContext = loginWindowViewModel;
            loginWindow.Show();
            _viewModel.Window.Close();
        }
    }
}
