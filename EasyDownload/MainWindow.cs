using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace EasyDownload
{
    class MainWindow : Window
    {
        private Button _exitButton = new Button();
        public MainWindow(string windowTittle, int height, int width)
        {
            _exitButton.Click += new RoutedEventHandler(ExitButtonClicked);
            _exitButton.Content = "Exit";
            _exitButton.Height = 100;
            _exitButton.Width = 100;

            this.Content = _exitButton;

            this.Title = windowTittle;
            this.Height = height;
            this.Width = width;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.Closing += MainWindowClosing;
            this.Closed += MainWindowClosed;

            this.MouseMove += MainWindowMouseMove;
            this.KeyDown += MainWindowKeyDown;
        }

        private void ExitButtonClicked(object sender, RoutedEventArgs e)
        {
            if((bool)Application.Current.Properties["GodMode"])
            {
                MessageBox.Show("Cheater!");
            }
            this.Close();
        }

        private void MainWindowClosing(object sebder, System.ComponentModel.CancelEventArgs e)
        {
            string msg = "Yes or No ?!";
            MessageBoxResult messageBoxResult = MessageBox.Show(msg, "MyApp", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(messageBoxResult == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void MainWindowClosed(object sender, EventArgs e)
        {
            MessageBox.Show("See ya!");
        }

        private void MainWindowMouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Title = e.GetPosition(this).ToString();
        }

        private void MainWindowKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _exitButton.Content = e.Key.ToString();
        }
    }
}
