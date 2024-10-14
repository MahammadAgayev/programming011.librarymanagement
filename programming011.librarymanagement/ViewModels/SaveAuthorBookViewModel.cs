using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.UI.Commands.AuthorBookCommands;
using LibraryManagement.UI.Models;

using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.UI.ViewModels
{
    public class SaveAuthorBookViewModel : BaseWindowViewModel
    {
        public SaveAuthorBookViewModel(Window window, BookAuthorViewModel baseViewModel) : base(window)
        {
            List<Author> authors = ApplicationContext.UnitOfWork.AuthorRepository.GetAll();
            List<Book> books = ApplicationContext.UnitOfWork.BookRepository.GetAll();

            this.Authors = authors.Select(x => new AuthorModel
            {
                Email = x.Email,
                Firstname = x.Firstname,
                Id = x.Id,
                Lastname = x.Lastname,
            }).ToList();

            this.Books = books.Select(b => new BookModel
            {
                Id = b.Id,
                Genre = b.Genre,
                PageCount = b.PageCount,
                PublishedDate = b.PublishedDate,
                Title = b.Title,
            }).ToList();

            BaseViewModel = baseViewModel;

            this.SaveAuthorBook = new SaveAuthorBookCommand(this);
        }

        public ICommand SaveAuthorBook { get; set; }

        public List<AuthorModel> Authors { get; set; }
        public int SelectedAuthorId { get; set; }

        public List<BookModel> Books { get; set; }
        public int SelectedBookId { get; set; }


        public BookAuthorViewModel BaseViewModel { get; set; }
    }
}
