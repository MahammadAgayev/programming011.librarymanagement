using LibraryManagement.UI.ViewModels;
using LibraryManagement.UI.Views;

using System.Windows.Input;

namespace LibraryManagement.UI.Commands.AdminCommands
{
    public class OpenAuthorsCommand : ICommand
    {
        private readonly AdminWindowViewModel _viewModel;
        public OpenAuthorsCommand(AdminWindowViewModel viewModel)
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
            _viewModel.CenterGrid.Children.Clear();

            AuthorsUserControl userControl = new AuthorsUserControl();
            AuthorsViewModel authorsViewModel = new AuthorsViewModel();
            userControl.DataContext = authorsViewModel;

            _viewModel.CenterGrid.Children.Add(userControl);
        }
    }
}
