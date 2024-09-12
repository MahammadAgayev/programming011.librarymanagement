using LibraryManagement.Core.Domain.Abstract;
using LibraryManagement.Core.Domain.Entities;

using Microsoft.Data.SqlClient;

namespace LibraryManagement.Core.DataAccess.SqlServer
{
    internal class SqlAuthorBookRepository : IAuthorBookRepository
    {
        private readonly string _connectionString;

        public SqlAuthorBookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(AuthorBook authorBook)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = "insert into authorbooks(bookid, authorid) values(@bookid,@authorid)";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("bookId", authorBook.Book.Id);
            cmd.Parameters.AddWithValue("authorId", authorBook.Author.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = "delete from authorbooks where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public List<AuthorBook> GetByAuthorId(int authorId)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"
select 
ab.Id, 
BookId,
Title,
PageCount,
PublishedDate, 
Genre,
AuthorId,
Firstname AuthorFirstname,
Lastname AuthorLastname,
Email AuthorEmail
from AuthorBooks ab
join Books b on b.Id = ab.BookId
join Authors a on a.Id = ab.AuthorId
where ab.authorid=@authorid
";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("authorId", authorId);

            SqlDataReader reader = cmd.ExecuteReader();

            List<AuthorBook> authorBooks = new List<AuthorBook>();

            while (reader.Read())
            {
                AuthorBook ab = SqlMapper.MapAuthorBook(reader);
                authorBooks.Add(ab);
            }

            return authorBooks;
        }

        public List<AuthorBook> GetByBookId(int bookId)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"
select 
ab.Id, 
BookId,
Title,
PageCount,
PublishedDate, 
Genre,
AuthorId,
Firstname AuthorFirstname,
Lastname AuthorLastname,
Email AuthorEmail
from AuthorBooks ab
join Books b on b.Id = ab.BookId
join Authors a on a.Id = ab.AuthorId
where ab.bookid=@bookId
";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("bookId", bookId);

            SqlDataReader reader = cmd.ExecuteReader();
            List<AuthorBook> authorBooks = new List<AuthorBook>();

            while (reader.Read())
            {
                AuthorBook ab = SqlMapper.MapAuthorBook(reader);
                authorBooks.Add(ab);
            }

            return authorBooks;
        }
    }
}
