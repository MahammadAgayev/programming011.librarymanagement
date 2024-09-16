using LibraryManagement.Core.Domain.Enums;
using LibraryManagement.UI.Commands.ConfigurationCommands;
using LibraryManagement.UI.Models;

using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.UI.ViewModels
{
    public class ConfigurationViewModel : BaseWindowViewModel
    {
        public ConfigurationViewModel(Window window) : base(window)
        {
            Configuration = new ConfigurationModel();

            //TODO: add save cancel 
            Cancel = new CancelCommand(this);
            Save = new SaveCommand(this);

            SupportedDbTypes = Enum.GetValues(typeof(DatabaseType))
                .Cast<DatabaseType>().ToList();
        }

        public ConfigurationModel Configuration { get; set; }
        public List<DatabaseType> SupportedDbTypes { get; set; }


        public ICommand  Save { get; set; }
        public ICommand Cancel { get; set; }

    }
}
