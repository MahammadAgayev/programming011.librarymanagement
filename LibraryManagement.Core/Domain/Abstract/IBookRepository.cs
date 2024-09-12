using LibraryManagement.Core.Domain.Entities;

using System.ComponentModel;

namespace LibraryManagement.Core.Domain.Abstract
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Update(Book book);

        void Delete(int id);

        Book Get(int id);
        List<Book> GetAll();
    }
}
