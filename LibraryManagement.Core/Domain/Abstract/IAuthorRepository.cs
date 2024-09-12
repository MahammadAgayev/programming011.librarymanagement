using LibraryManagement.Core.Domain.Entities;

namespace LibraryManagement.Core.Domain.Abstract
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        void Update(Author author);
        void Delete(int id);

        Author Get(int id);
        List<Author> GetAll();
    }
}
