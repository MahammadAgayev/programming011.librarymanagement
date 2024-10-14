using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using System.Windows.Input;

namespace LibraryManagement.UI.Commands.AuthorBookCommands
{
    public class OpenAuthorBookCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenAuthorBookCommand(AdminWindowViewModel viewModel)
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
            BookAuthorsUserControl userControl = new BookAuthorsUserControl();
            BookAuthorViewModel viewModel = new BookAuthorViewModel();
            userControl.DataContext = viewModel;

            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(userControl);
        }
    }
}
