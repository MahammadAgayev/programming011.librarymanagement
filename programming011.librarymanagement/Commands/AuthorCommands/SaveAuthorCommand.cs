using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.UI.ViewModels;

using System.Security.AccessControl;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.AuthorCommands
{
    public class SaveAuthorCommand : ICommand
    {
        private readonly SaveAuthorViewModel _viewModel;

        public SaveAuthorCommand(SaveAuthorViewModel viewModel)
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
            Author author = new Author
            {
                Firstname = _viewModel.AuthorModel.Firstname,
                Lastname = _viewModel.AuthorModel.Lastname,
                Email = _viewModel.AuthorModel.Email,
                Id = _viewModel.AuthorModel.Id,
            };

            if (author.Id > 0)
            {
                ApplicationContext.UnitOfWork.AuthorRepository.Update(author);
                _viewModel.Window.Close();
                return;
            }

            ApplicationContext.UnitOfWork.AuthorRepository.Add(author);

            _viewModel.AuthorModel.Id = author.Id;
            _viewModel.BaseViewModel.AuthorModels.Add(_viewModel.AuthorModel);
            _viewModel.Window.Close();
        }
    }
}
