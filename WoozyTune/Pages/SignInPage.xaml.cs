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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WoozyTune.Pages
{
    public partial class SignInPage : Page
    {
        MainWindow mainWindow;
        public SignInPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

        }

        private void SignUp_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Navigate(new SignUpPage());
        }

        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow.WindowState != WindowState.Maximized)
            {
                mainWindow.Hide();
                mainWindow.Width = SystemParameters.PrimaryScreenWidth * 0.8;
                mainWindow.Height = SystemParameters.PrimaryScreenHeight * 0.8;
                mainWindow.Top = (SystemParameters.PrimaryScreenHeight - ActualHeight) / 2;
                mainWindow.Left = (SystemParameters.PrimaryScreenWidth - ActualWidth) / 2;
                mainWindow.Show();

                mainWindow.WindowState_Label.Opacity = 0.8;
                mainWindow.Header_Grid.Visibility = Visibility.Visible;
                mainWindow.frame.Navigate(new HomePage());
            }
        }
    }
}
