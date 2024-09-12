using LibraryManagement.Core.Domain.Abstract;
using LibraryManagement.Core.Domain.Entities;

using Microsoft.Data.SqlClient;

namespace LibraryManagement.Core.DataAccess.Sql
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public SqlBookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Book book)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"insert into Books(Name, PublishedYear, PageCount, Genre) 
                       values(@name, @publishedYear,@pageCount, @genre)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", book.Name);
            cmd.Parameters.AddWithValue("publishedYear", book.PublishedYear);
            cmd.Parameters.AddWithValue("pageCount", book.PageCount);
            cmd.Parameters.AddWithValue("genre", book.Genre);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from books where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public Book Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

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
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from books";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Book> list = new List<Book>();
            while (reader.Read())
            {
                Book book = SqlMapper.MapBook(reader);

                list.Add(book);
            }

            return list; 
        }

        public void Update(Book book)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"update book set  
                               name = @name,
                               publishedYear = @publishedYear
                               pageCount = @pageCount
                               genre = @genre where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("name", book.Name);
            cmd.Parameters.AddWithValue("publishedYear", book.PublishedYear);
            cmd.Parameters.AddWithValue("pageCount", book.PageCount);
            cmd.Parameters.AddWithValue("genre", book.Genre);
            cmd.Parameters.AddWithValue("id", book.Id);

            cmd.ExecuteNonQuery();
        }
    }
}
