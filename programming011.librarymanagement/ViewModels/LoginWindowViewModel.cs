using LibraryManagement.UI.Commands.LoginCommands;
using LibraryManagement.UI.Models;

using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace LibraryManagement.UI.ViewModels
{
    internal class LoginWindowViewModel : BaseWindowViewModel
    {
        public LoginWindowViewModel(Window window) : base(window)
        {
            LoginModel = new LoginModel();
            ErrorVisibility = Visibility.Hidden;


            Login = new LoginCommand(this);
        }

        public LoginModel LoginModel { get; set; }

        private Visibility errorVisibility;
        public Visibility ErrorVisibility
        {
            get { return errorVisibility; }
            set
            {
                errorVisibility = value;
                this.OnPropertyChanged(nameof(ErrorVisibility));
            }
        }

        public ICommand Login { get; set; }
    }
}
