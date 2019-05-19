using System.Windows;
using System.Windows.Input;
using WoozyTune.Pages;

namespace WoozyTune
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Width = SystemParameters.PrimaryScreenWidth * 0.57;
            Height = SystemParameters.PrimaryScreenHeight * 0.57;
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            frame.Navigate(new SignInPage(this));
        }

        private void Minimize_Button_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private bool flag = true;
        private void Maximize_Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = flag ? WindowState.Maximized : WindowState.Normal;
            flag = !flag;
        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e) => Close();

        private void WindowState_Label_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}