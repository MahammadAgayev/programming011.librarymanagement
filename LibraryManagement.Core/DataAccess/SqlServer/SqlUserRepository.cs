using LibraryManagement.Core.Domain.Abstract;
using LibraryManagement.Core.Domain.Entities;

using Microsoft.Data.SqlClient;

namespace LibraryManagement.Core.DataAccess.SqlServer
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public SqlUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(User user)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = @"insert into Users(username, passwordhash, created)
                                    values(@username, @passwordhash, @created)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("passwordhash", user.PasswordHash);
            cmd.Parameters.AddWithValue("created", user.Created);

            cmd.ExecuteNonQuery();
        }

        public User GetByUsername(string username)
        {
            using SqlConnection connection = ConnectionHelper.GetConnection(_connectionString);

            const string query = "select * from users where username=@username";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("username", username);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return SqlMapper.MapUser(reader);
            }

            return null;
        }
    }
}
