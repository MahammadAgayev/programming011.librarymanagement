using System.Windows;

namespace LibraryManagement.UI.ViewModels
{
    public abstract class BaseWindowViewModel
    {
        public Window Window { get; private set; }

        public BaseWindowViewModel(Window window)
        {
            Window = window;
        }
    }
}
