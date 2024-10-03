using LibraryManagement.UI.Commands.AuthorCommands;
using LibraryManagement.UI.Models;

using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.UI.ViewModels
{
    public class SaveAuthorViewModel : BaseWindowViewModel
    {
        public SaveAuthorViewModel(Window window, AuthorsViewModel authorsViewModel) : base(window)
        {
            this.AuthorModel = new AuthorModel();
            this.BaseViewModel = authorsViewModel;

            this.SaveAuthor = new SaveAuthorCommand(this);
        }

        public AuthorModel AuthorModel { get; set; }
        public ICommand SaveAuthor { get; set; }

        public AuthorsViewModel BaseViewModel { get; set; }
    }
}
