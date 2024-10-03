using LibraryManagement.Core.Domain.Abstract;
using LibraryManagement.Core.Domain.Entities;

using Microsoft.Data.SqlClient;

namespace LibraryManagement.Core.DataAccess.SqlServer
{
    internal class SqlBookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public SqlBookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Book book)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"insert into books(Title, PageCount, PublishedDate, Genre)
                         output inserted.id
                         values(@title, @pageCount, @publishedDate, @genre)";
              
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("title", book.Title);
            cmd.Parameters.AddWithValue("pageCount", book.PageCount);
            cmd.Parameters.AddWithValue("publishedDate", book.PublishedDate);
            cmd.Parameters.AddWithValue("genre", book.Genre);

            //cmd.ExecuteNonQuery();

            book.Id = (int)cmd.ExecuteScalar();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = "delete from books where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public Book Get(int id)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = "select * from books where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return SqlMapper.MapBook(reader);
            }

            return null;
        }

        public List<Book> GetAll()
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = "select * from books";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Book> books = new List<Book>();
            while (reader.Read())
            {
                Book book = SqlMapper.MapBook(reader);

                books.Add(book);
            }

            return books;
        }

        public void Update(Book book)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"update books set title=@title, pageCount=@pageCount, publishedDate=@publishedDate, genre=@genre where id=@id";
              
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", book.Id);
            cmd.Parameters.AddWithValue("title", book.Title);
            cmd.Parameters.AddWithValue("pageCount", book.PageCount);
            cmd.Parameters.AddWithValue("publishedDate", book.PublishedDate);
            cmd.Parameters.AddWithValue("genre", book.Genre);

            cmd.ExecuteNonQuery();
        }
    }
}
