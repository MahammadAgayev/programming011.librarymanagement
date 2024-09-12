using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.Core.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.DataAccess.Sql
{
    internal static class SqlMapper
    {
        internal static Book MapBook(IDataReader reader)
        {
            return new Book
            {
                Id = (int)reader[nameof(Book.Id)],
                Name = (string)reader[nameof(Book.Name)],
                PublishedYear = (int)reader[nameof(Book.PublishedYear)],
                PageCount = (int)reader[nameof(Book.PageCount)],
                Genre = (Genre)reader[nameof(Book.Genre)],
            };
        }

        internal static Author MapAuthor(IDataReader reader)
        {
            return new Author 
            {
                Id = (int)reader[nameof(Author.Id)],
                Firstname = (string)reader[nameof(Author.Firstname)],
                Lastname = (string)reader[nameof(Author.Lastname)],
                Email = (string)reader[nameof(Author.Email)]
            };
        }

        internal static AuthorBook MapAuthorBook(IDataReader reader)
        {
            return new AuthorBook
            {
                Id = (int)reader[nameof(AuthorBook.Id)],
                Book = new Book
                {
                    Id = (int)reader["bookId"],
                    Name = (string)reader["bookName"],
                    PublishedYear  = (int)reader["publishedYear"],
                    PageCount = (int)reader["pageCount"],
                    Genre = (Genre)reader["bookGenre"]
                },
                Author = new Author
                {
                    Id = (int)reader["authorId"],
                    Firstname = (string)reader["AuthorFirstname"],
                    Lastname = (string)reader["AuthorLastname"],
                    Email = (string)reader["AuthorEmail"],
                }
            };
        }
    }
}
