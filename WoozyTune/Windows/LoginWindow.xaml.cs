using System.Windows;
using WoozyTune.Pages;
using WoozyTune.UserControls;

namespace WoozyTune
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Width = SystemParameters.PrimaryScreenWidth * 0.57;
            Height = SystemParameters.PrimaryScreenHeight * 0.57;
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            grid.Children.Add(new WindowStateUserControl(this));
            frame.Navigate(new SignInPage(this));
        }
    }
}