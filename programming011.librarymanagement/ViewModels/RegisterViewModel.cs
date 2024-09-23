using LibraryManagement.UI.Commands.RegisterCommands;
using LibraryManagement.UI.Models;

using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.UI.ViewModels
{
    public class RegisterViewModel : BaseWindowViewModel
    {
        public RegisterViewModel(Window window) : base(window)
        {
            this.RegisterModel = new RegisterModel();
            this.Register = new RegisterCommand(this);
        }

        public RegisterModel RegisterModel { get; set; }
        public ICommand Register { get; set; }
    }
}
