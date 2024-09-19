using LibraryManagement.Core.Domain.Abstract;

using Microsoft.Data.SqlClient;

namespace LibraryManagement.Core.DataAccess.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IBookRepository BookRepository => new SqlBookRepository(_connectionString);

        public IAuthorRepository AuthorRepository => new SqlAuthorRepository(_connectionString);

        public IAuthorBookRepository AuthorBookRepository => throw new NotImplementedException();
        public IUserRepository UserRepository => new SqlUserRepository(_connectionString);

        public bool CheckConnection()
        {
            try
            {
                using SqlConnection sqlConnection = new SqlConnection(_connectionString);
                sqlConnection.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
