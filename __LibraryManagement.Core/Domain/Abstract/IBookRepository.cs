using LibraryManagement.Core.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Domain.Abstract
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Delete(int id);

        void Update(Book book);

        Book Get(int id);
        List<Book> GetAll();
    }
}
