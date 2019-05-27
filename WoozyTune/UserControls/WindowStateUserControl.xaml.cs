using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WoozyTune.UserControls
{
    public partial class WindowStateUserControl : UserControl
    {
        private Window window;
        public WindowStateUserControl(Window window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void Minimize_Button_Click(object sender, RoutedEventArgs e) => window.WindowState = WindowState.Minimized;

        private bool flag = true;
        private void Maximize_Button_Click(object sender, RoutedEventArgs e)
        {
            window.WindowState = flag ? WindowState.Maximized : WindowState.Normal;
            flag = !flag;
        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e) => window.Close();

        private void WindowState_Label_MouseDown(object sender, MouseButtonEventArgs e) => window.DragMove();
    }
}
