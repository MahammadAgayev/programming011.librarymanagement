using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.UI.Models;
using LibraryManagement.UI.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.AuthorBookCommands
{
    public class SaveAuthorBookCommand : ICommand
    {
        private readonly SaveAuthorBookViewModel _viewModel;

        public SaveAuthorBookCommand(SaveAuthorBookViewModel viewModel)
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
            AuthorModel author = _viewModel.Authors[_viewModel.SelectedAuthorId];
            BookModel book = _viewModel.Books[_viewModel.SelectedBookId];

            AuthorBook authorBook = new AuthorBook
            {
                Author = new Author
                {
                    Id = author.Id ,
                    Email = author.Email,
                    Firstname = author.Firstname,
                    Lastname = author.Lastname,
                },
                Book = new Book
                {
                    Id = book.Id,
                    Genre = book.Genre,
                    PageCount = book.PageCount,
                    PublishedDate = book.PublishedDate,
                    Title = book.Title,
                },
            };

            ApplicationContext.UnitOfWork.AuthorBookRepository.Add(authorBook);

            _viewModel.BaseViewModel.BookAuthorModels
                .Add(new BookAuthorModel
                {
                    Id = authorBook.Id,
                    AuthorName = author.Firstname + " " + author.Lastname,
                    BookName = book.Title,
                });

            _viewModel.Window.Close();
        }
    }
}
