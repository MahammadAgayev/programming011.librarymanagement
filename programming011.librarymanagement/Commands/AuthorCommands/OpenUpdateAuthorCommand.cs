using LibraryManagement.UI.Models;
using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using System.Windows.Input;

namespace LibraryManagement.UI.Commands.AuthorCommands
{
    public class OpenUpdateAuthorCommand : ICommand
    {
        private readonly AuthorsViewModel _viewModel;

        public OpenUpdateAuthorCommand(AuthorsViewModel viewModel)
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
            SaveAuthorWindow saveAuthor = new SaveAuthorWindow();
            SaveAuthorViewModel viewModel = new SaveAuthorViewModel(saveAuthor, _viewModel);
            saveAuthor.DataContext = viewModel;

            //the difference in update
            viewModel.AuthorModel = _viewModel.AuthorModels[_viewModel.SelectedAuthorIndex];

            saveAuthor.ShowDialog();
        }
    }
}
