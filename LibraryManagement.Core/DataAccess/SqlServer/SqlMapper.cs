using LibraryManagement.Core.Domain.Entities;
using LibraryManagement.Core.Domain.Enums;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.DataAccess.SqlServer
{
    internal static class SqlMapper
    {
        internal static Book MapBook(SqlDataReader reader)
        {
            return new Book
            {
                Id = (int)reader["id"],
                PageCount = (int)reader["pageCount"],
                PublishedDate = (DateTime)reader["publishedDate"],
                Genre = (Genre)reader["genre"],
                Title = (string)reader["title"]
            };
        }

        internal static Author MapAuthor(SqlDataReader reader)
        {
            return new Author
            {
                Id = (int)reader["id"],
                Firstname = (string)reader["firstname"],
                Lastname = (string)reader["lastname"],
                Email = (string)reader["email"],
            };
        }

        internal static User MapUser(SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["id"],
                Username = (string)reader["username"],
                PasswordHash = (string)reader["passwordhash"],
                Created = (DateTime)reader["created"]
            };
        }

        internal static AuthorBook MapAuthorBook(SqlDataReader reader)
        {
            return new AuthorBook
            {
                Id = (int)reader["Id"],
                Book = new Book
                {
                    Id = (int)reader["bookId"],
                    Genre = (Genre)reader["genre"],
                    PageCount = (int)reader["pageCount"],
                    Title = (string)reader["title"],
                    PublishedDate = (DateTime)reader["publishedDate"]
                },
                Author = new Author
                {
                    Id = (int)reader["authorId"],
                    Email = (string)reader["authorEmail"],
                    Firstname = (string)reader["authorFirstname"],
                    Lastname = (string)reader["authorLastname"],
                }
            };
        }
    }
}
