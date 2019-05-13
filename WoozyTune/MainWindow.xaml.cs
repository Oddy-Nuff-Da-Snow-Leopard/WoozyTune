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
using WoozyTune.Pages;

namespace WoozyTune
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            Header_Grid.Visibility = Visibility.Hidden;
            Width = SystemParameters.PrimaryScreenWidth * 0.57;
            Height = SystemParameters.PrimaryScreenHeight * 0.57;
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            frame.Navigate(new SignInPage(this));
        }
            
        private void Minimize_Button_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private bool flag = true;
        private void Maximize_Button_Click(object sender, RoutedEventArgs e)
        {
            if (flag)
            {
                WindowState = WindowState.Maximized;
                flag = false;
            }
            else
            {
                WindowState = WindowState.Normal;
                flag = true;
            }

        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e) => Close();

        private void Header_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}
