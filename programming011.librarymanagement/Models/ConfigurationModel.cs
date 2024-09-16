using LibraryManagement.Core.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UI.Models
{
    public class ConfigurationModel
    {
        public DatabaseType DatabaseType { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public bool WindowsAuthentication { get; set; }
        public string Username { get; set; }
    }
}
