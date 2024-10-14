using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using System.Windows.Input;

namespace LibraryManagement.UI.Commands.AuthorBookCommands
{
    public class OpenAddBookAuthorCommand : ICommand
    {
        private readonly BookAuthorViewModel _viewModel;

        public OpenAddBookAuthorCommand(BookAuthorViewModel viewModel)
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
            SaveAuthorBookWindow window = new SaveAuthorBookWindow();
            SaveAuthorBookViewModel viewModel = new SaveAuthorBookViewModel(window, _viewModel);

            window.DataContext = viewModel;

            window.ShowDialog();
        }
    }
}
