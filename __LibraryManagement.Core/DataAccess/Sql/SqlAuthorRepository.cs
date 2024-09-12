using LibraryManagement.Core.Domain.Abstract;
using LibraryManagement.Core.Domain.Entities;

using Microsoft.Data.SqlClient;

namespace LibraryManagement.Core.DataAccess.Sql
{
    public class SqlAuthorRepository : IAuthorRepository
    {
        private readonly string _connectionString;

        public SqlAuthorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Author author)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"Insert into authors(firstname, lastname,email)
                             values(@firstname,@lastname, @email)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("firstname", author.Firstname);
            cmd.Parameters.AddWithValue("lastname", author.Lastname);
            cmd.Parameters.AddWithValue("email", author.Email);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from authors where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public Author Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from authors where id = @id";

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
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from authors";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Author> list = new List<Author>();
            while (reader.Read())
            {
                Author a = SqlMapper.MapAuthor(reader);
                list.Add(a);
            }

            return list;
        }

        public void Update(Author author)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = @"update authors set firstname=@firstname, lastname=@lastname, email=@email
                                 where id=@id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", author.Id);
            cmd.Parameters.AddWithValue("firstname", author.Firstname);
            cmd.Parameters.AddWithValue("lastname", author.Lastname);
            cmd.Parameters.AddWithValue("email", author.Email);

            cmd.ExecuteNonQuery();
        }
    }
}
