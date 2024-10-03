using LibraryManagement.UI.Models;
using LibraryManagement.UI.ViewModels;

using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.AuthorCommands
{
    public class DeleteAuthorCommand : ICommand
    {
        private readonly AuthorsViewModel _viewModel;
        public DeleteAuthorCommand(AuthorsViewModel viewModel)
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
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Delete author", MessageBoxButton.YesNoCancel, MessageBoxImage
                 .Question, MessageBoxResult.No);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            AuthorModel model = _viewModel.AuthorModels[_viewModel.SelectedAuthorIndex];

            if (model == null)
            {
                return;
            }

            ApplicationContext.UnitOfWork.AuthorRepository.Delete(model.Id);
            _viewModel.AuthorModels.Remove(model);
        }
    }
}
