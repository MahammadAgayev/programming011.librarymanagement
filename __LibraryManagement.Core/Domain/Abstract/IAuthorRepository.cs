using LibraryManagement.Core.Domain.Entities;

namespace LibraryManagement.Core.Domain.Abstract
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        void Delete(int id);
        void Update(Author author);

        Author Get(int id);
        List<Author> GetAll();
    }
}
