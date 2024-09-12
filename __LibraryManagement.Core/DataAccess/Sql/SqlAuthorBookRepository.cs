using LibraryManagement.Core.Domain.Abstract;
using LibraryManagement.Core.Domain.Entities;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.DataAccess.Sql
{
    public class SqlAuthorBookRepository : IAuthorBookRepository
    {
        private readonly string _connectionString;

        public SqlAuthorBookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(AuthorBook authorBook)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "insert into authorbooks(authorid,bookid) values(@authorId, @bookId)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("authorId", authorBook.Author.Id);
            cmd.Parameters.AddWithValue("bookId", authorBook.Book.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from authorbooks where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public List<AuthorBook> GetByAuthorId(int authorId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"

select ab.Id, 
      ab.BookId,
	  b.Name as BookName,
	  b.PublishedYear,
	  b.PageCount,
	  b.Genre as BookGenre,
	  ab.AuthorId,
	  a.Firstname as AuthorFirstname,
	  a.Lastname as AuthorLastname,
	  a.Email as AuthorEmail
from AuthorBooks ab
join Books b on b.Id = ab.BookId
join Authors a on a.Id = ab.AuthorId
where ab.authorid = @id
";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", authorId);

            SqlDataReader reader = cmd.ExecuteReader();

            List<AuthorBook> list = new List<AuthorBook>();
            while (reader.Read())
            {
                AuthorBook book = SqlMapper.MapAuthorBook(reader);

                list.Add(book);
            }

            return list;
        }

        public List<AuthorBook> GetByBookId(int bookId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"

select ab.Id, 
      ab.BookId,
	  b.Name as BookName,
	  b.PublishedYear,
	  b.PageCount,
	  b.Genre as BookGenre,
	  ab.AuthorId,
	  a.Firstname as AuthorFirstname,
	  a.Lastname as AuthorLastname,
	  a.Email as AuthorEmail
from AuthorBooks ab
join Books b on b.Id = ab.BookId
join Authors a on a.Id = ab.AuthorId
where ab.bookid = @id
";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", bookId);

            SqlDataReader reader = cmd.ExecuteReader();

            List<AuthorBook> list = new List<AuthorBook>();
            while (reader.Read())
            {
                AuthorBook book = SqlMapper.MapAuthorBook(reader);

                list.Add(book);
            }

            return list;
        }
    }
}
