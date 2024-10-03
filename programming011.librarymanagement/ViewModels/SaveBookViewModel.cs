using LibraryManagement.Core.Domain.Enums;
using LibraryManagement.UI.Commands.BooksCommands;
using LibraryManagement.UI.Models;

using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.UI.ViewModels
{
    internal class SaveBookViewModel : BaseWindowViewModel
    {
        public SaveBookViewModel(Window window, BooksViewModel booksViewModel) : base(window)
        {
            this.BookModel = new BookModel
            {
                PublishedDate = DateTime.Now
            };

            this.Genres = Enum.GetValues(typeof(Genre))
                .Cast<Genre>().ToList();

            this.SaveBook = new SaveBookCommand(this);
            BooksViewModel = booksViewModel;
        }

        public BookModel BookModel { get; set; }
        public List<Genre> Genres { get; set; }
        public ICommand SaveBook { get; set; }
        public BooksViewModel BooksViewModel { get; set; }
    }
}
