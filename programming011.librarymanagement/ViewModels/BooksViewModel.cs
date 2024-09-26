using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.UI.Commands.BooksCommands;
using LibraryManagement.UI.Models;

using System.Windows.Input;

namespace LibraryManagement.UI.ViewModels
{
    public class BooksViewModel 
    {
        public BooksViewModel()
        {
            List<Book> books = ApplicationContext.UnitOfWork.BookRepository.GetAll();
            BookModels = new List<BookModel>();

            foreach(Book book in books)
            {
                BookModel model = new BookModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Genre = book.Genre,
                    PageCount = book.PageCount,
                    PublishedDate = book.PublishedDate
                };

                BookModels.Add(model);
            }

            OpenSaveBook = new OpenSaveBooksCommand(this);
        }

        public List<BookModel> BookModels { get; set; }
        public ICommand OpenSaveBook { get; set; }
    }
}
