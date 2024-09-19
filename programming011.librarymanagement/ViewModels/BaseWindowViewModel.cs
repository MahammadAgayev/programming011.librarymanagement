using System.ComponentModel;
using System.Windows;

namespace LibraryManagement.UI.ViewModels
{
    public abstract class BaseWindowViewModel : INotifyPropertyChanged
    {
        public Window Window { get; private set; }

        public BaseWindowViewModel(Window window)
        {
            Window = window;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
