using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.UI.Commands.BooksCommands
{
    public class OpenSaveBooksCommand : ICommand
    {
        private readonly BooksViewModel _viewModel;
        public OpenSaveBooksCommand(BooksViewModel viewModel)
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
            SaveBookWindow window = new SaveBookWindow();
            SaveBookViewModel viewModel = new SaveBookViewModel(window);
            window.DataContext = viewModel;

            window.ShowDialog();
        }
    }
}
