using LibraryManagement.Core.Domain.Enums;

namespace LibraryManagement.Core.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public Genre Genre { get; set; }
    }
}
