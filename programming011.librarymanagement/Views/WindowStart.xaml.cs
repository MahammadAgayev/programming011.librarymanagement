using LibraryManagement.UI.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryManagement.UI.Views
{
    /// <summary>
    /// Interaction logic for WindowStart.xaml
    /// </summary>
    public partial class WindowStart : Window
    {
        public WindowStart()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ApplicationContext.Initialize();

            Task.Run(() =>
            {
                this.CheckServer();
            });
        }

        private void CheckServer()
        {
            if (ApplicationContext.UnitOfWork.CheckConnection())
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    LoginWindow window = new LoginWindow();
                    LoginWindowViewModel loginWindowViewModel = new LoginWindowViewModel(window);
                    window.DataContext = loginWindowViewModel;

                    window.Show();
                    this.Close();
                });

                return;
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                ConfigurationWindow window = new ConfigurationWindow();
                ConfigurationViewModel viewModel = new ConfigurationViewModel();
                viewModel.Window = window;
                window.DataContext = viewModel;
                window.Show();

                this.Close();
            });
        }
    }
}
