using LibraryManagement.Core.DataAccess.SqlServer;
using LibraryManagement.Core.Domain.Abstract;
using LibraryManagement.UI.Models;
using LibraryManagement.UI.Utils;

using Microsoft.Data.SqlClient;

namespace LibraryManagement.UI
{
    internal class ApplicationContext
    {
        public static IUnitOfWork UnitOfWork { get; private set; }

        public static void Initialize()
        {
            ConfigurationInfo configurationInfo = ConfigurationHelper.Read();

            if (configurationInfo == null)
            {
                UnitOfWork = new SqlUnitOfWork("");
                return;
            }

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.TrustServerCertificate = true;
            builder.DataSource = configurationInfo.ServerName;
            builder.InitialCatalog = configurationInfo.DatabaseName;
            builder.IntegratedSecurity = configurationInfo.WindowsAuthentication;

            if (configurationInfo.WindowsAuthentication == false)
            {
                builder.UserID = configurationInfo.Username;
                builder.Password = configurationInfo.Password;
            }

            UnitOfWork = new SqlUnitOfWork(builder.ConnectionString);
        }
    }
}
