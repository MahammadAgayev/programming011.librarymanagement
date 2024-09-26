using LibraryManagement.Core.Domain.Enums;

namespace LibraryManagement.UI.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
