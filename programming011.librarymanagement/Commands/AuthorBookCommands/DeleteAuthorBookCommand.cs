using LibraryManagement.UI.Models;
using LibraryManagement.UI.ViewModels;

using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.AuthorBookCommands
{
    public class DeleteAuthorBookCommand : ICommand
    {
        private readonly BookAuthorViewModel _viewModel;
        public DeleteAuthorBookCommand(BookAuthorViewModel viewModel)
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
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Delete author book relation", MessageBoxButton.YesNoCancel, MessageBoxImage
                 .Question, MessageBoxResult.No);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            BookAuthorModel model = _viewModel.BookAuthorModels[_viewModel.SelectedAuthorBookId];

            ApplicationContext.UnitOfWork.AuthorBookRepository.Delete(model.Id);
            _viewModel.BookAuthorModels.Remove(model);
        }
    }
}
