using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.UI.Commands.AuthorBookCommands;
using LibraryManagement.UI.Models;

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LibraryManagement.UI.ViewModels
{
    public class BookAuthorViewModel
    {
        public BookAuthorViewModel()
        {
            BookAuthorModels = new ObservableCollection<BookAuthorModel>();
            List<AuthorBook> authorBooks = ApplicationContext.UnitOfWork.AuthorBookRepository.GetAll();

            foreach (AuthorBook authorBook in authorBooks)
            {
                BookAuthorModel bookAuthorModel = new BookAuthorModel
                {
                    AuthorName = authorBook.Author.Firstname + " " + authorBook.Author.Lastname,
                    BookName = authorBook.Book.Title,
                    Id = authorBook.Id
                };

                this.BookAuthorModels.Add(bookAuthorModel);
            }

            this.OpenAddBookAuthors = new OpenAddBookAuthorCommand(this);
            this.DeleteBookAuthor = new DeleteAuthorBookCommand(this);
        }

        public ObservableCollection<BookAuthorModel> BookAuthorModels { get; set; }
        public int SelectedAuthorBookId { get; set; }
        public ICommand OpenAddBookAuthors { get; set; }
        public ICommand DeleteBookAuthor { get; set; }
    }
}
