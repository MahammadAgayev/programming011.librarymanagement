using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.AdminCommands
{
    public class OpenBooksCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;

        public OpenBooksCommand(AdminWindowViewModel viewModel)
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
            UserControl booksUserControl = new BooksUserControl();
            BooksViewModel booksViewModel = new BooksViewModel();
            booksUserControl.DataContext = booksViewModel;


            _viewModel.CenterGrid.Children.Add(booksUserControl);
        }
    }
}
