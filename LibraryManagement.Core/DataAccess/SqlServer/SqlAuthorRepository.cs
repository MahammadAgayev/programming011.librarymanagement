using LibraryManagement.Core.Domain.Abstract;
using LibraryManagement.Core.Domain.Entities;

using Microsoft.Data.SqlClient;

namespace LibraryManagement.Core.DataAccess.SqlServer
{
    internal class SqlAuthorRepository : IAuthorRepository
    {
        private readonly string _connectionString;

        public SqlAuthorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Author author)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"insert into authors(firstname, lastname,email)
                               output inserted.id
                               values(@firstname, @lastname, @email)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("firstname", author.Firstname);
            cmd.Parameters.AddWithValue("lastname", author.Lastname);
            cmd.Parameters.AddWithValue("email", author.Email);

            author.Id = (int)cmd.ExecuteScalar();

        }

        public void Delete(int id)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = "delete from authors where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public Author Get(int id)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = "select * from authors where id=@id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return SqlMapper.MapAuthor(reader);
            }

            return null;
        }

        public List<Author> GetAll()
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = "select * from authors";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Author> list = new List<Author>();
            while (reader.Read())
            {
                Author author = SqlMapper.MapAuthor(reader);
                list.Add(author);
            }

            return list;
        }

        public void Update(Author author)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"update authors set firstname=@firstname,lastname=@lastname, email=@email where id=@id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("firstname", author.Firstname);
            cmd.Parameters.AddWithValue("lastname", author.Lastname);
            cmd.Parameters.AddWithValue("email", author.Email);
            cmd.Parameters.AddWithValue("id", author.Id);

            cmd.ExecuteNonQuery();
        }
    }
}
