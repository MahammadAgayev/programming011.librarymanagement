using LibraryManagement.Core.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Domain.Abstract
{
    public interface IAuthorBookRepository
    {
        void Add(AuthorBook authorBook);
        void Delete(int id);


        List<AuthorBook> GetByAuthorId(int authorId);  
        List<AuthorBook> GetByBookId(int bookId);  
    }
}
