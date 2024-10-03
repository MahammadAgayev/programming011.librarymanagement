using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.UI.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.BooksCommands
{
    internal class SaveBookCommand : ICommand
    {
        private readonly SaveBookViewModel _viewModel;

        public SaveBookCommand(SaveBookViewModel viewModel)
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
            Book b = new Book
            {
                Title = _viewModel.BookModel.Title,
                Genre = _viewModel.BookModel.Genre,
                PageCount = _viewModel.BookModel.PageCount,
                PublishedDate = _viewModel.BookModel.PublishedDate,
                Id = _viewModel.BookModel.Id,
            };

            //the book only needs to be updated
            if (b.Id > 0)
            {
                ApplicationContext.UnitOfWork.BookRepository.Update(b);
                _viewModel.Window.Close();
                return;
            }

            ApplicationContext.UnitOfWork.BookRepository.Add(b);

            _viewModel.BookModel.Id = b.Id;
            _viewModel.BooksViewModel.BookModels.Add(_viewModel.BookModel);
            _viewModel.Window.Close();
        }
    }
}
