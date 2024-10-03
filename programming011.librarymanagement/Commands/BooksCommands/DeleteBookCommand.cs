using LibraryManagement.UI.Models;
using LibraryManagement.UI.ViewModels;

using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.BooksCommands
{
    internal class DeleteBookCommand : ICommand
    {
        private readonly BooksViewModel _viewModel;

        public DeleteBookCommand(BooksViewModel viewModel)
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
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Delete book", MessageBoxButton.YesNoCancel, MessageBoxImage
                 .Question, MessageBoxResult.No);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            BookModel model = _viewModel.BookModels[_viewModel.SelectedBookIndex];

            if (model == null)
            {
                throw new InvalidOperationException("Books should not be null");
            }

            ApplicationContext.UnitOfWork.BookRepository.Delete(model.Id);

            _viewModel.BookModels.Remove(model);
        }
    }
}
