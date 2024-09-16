using LibraryManagement.UI.Models;
using LibraryManagement.UI.Utils;
using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using Newtonsoft.Json;

using System.Configuration;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.ConfigurationCommands
{
    public class SaveCommand : ICommand
    {
        private readonly ConfigurationViewModel _viewModel;

        public SaveCommand(ConfigurationViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string password = ((PasswordBox)parameter).Password;

            ConfigurationInfo configuration = new ConfigurationInfo
            {
                ServerName = _viewModel.Configuration.ServerName,
                DatabaseName = _viewModel.Configuration.DatabaseName,
                DatabaseType = _viewModel.Configuration.DatabaseType,
                Password = password,
                Username = _viewModel.Configuration.Username,
                WindowsAuthentication = _viewModel.Configuration.WindowsAuthentication,
            };

            /*
             *  JSON, binary, protobuf
             *  JSON -> javasript object notation
             *  
             *  {
             *       "DatabaseName" : "programming009"
             *  }
             * 
             */

            //string text = JsonConvert.SerializeObject(configuration);
            //string path = "programming011.settings";

            //File.WriteAllText(path, text);

            //string writtenText = File.ReadAllText(path);

            ConfigurationHelper.Write(configuration);


            WindowStart windowStart = new WindowStart();
            windowStart.Show();

            _viewModel.Window.Close();
            /*
             * User should enter configuration data only once
             * 
             * File.Write()
             * File.ReadAllText()
             * 
             * serialization
             * deserialization
             * 
             */
        }
    }
}
