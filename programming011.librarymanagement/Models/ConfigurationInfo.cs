using LibraryManagement.Core.Domain.Enums;

namespace LibraryManagement.UI.Models
{
    public class ConfigurationInfo
    {
        public DatabaseType DatabaseType { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
