using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.AuthorCommands
{
    internal class OpenSaveAuthorCommand : ICommand
    {
        private readonly AuthorsViewModel _viewModel;

        public OpenSaveAuthorCommand(AuthorsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Window saveWindow = new SaveAuthorWindow();
            SaveAuthorViewModel viewModel = new SaveAuthorViewModel(saveWindow, _viewModel);

            saveWindow.DataContext = viewModel;

            saveWindow.ShowDialog();
        }
    }
}
