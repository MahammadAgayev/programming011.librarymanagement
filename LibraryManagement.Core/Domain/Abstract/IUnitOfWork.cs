namespace LibraryManagement.Core.Domain.Abstract
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IAuthorBookRepository AuthorBookRepository { get; }

        bool CheckConnection();
    }
}
