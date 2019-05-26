using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace WoozyTune.Pages
{
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
            Login_TextBox.Text = "angry.school.boy";
            PasswordBox.Password = "P@ssw0rd";
        }

        private void Join_Button_Click(object sender, RoutedEventArgs e) => Windows.loginWindow.frame.Navigate(new SignUpPage());

        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Login_TextBox.Text) && !string.IsNullOrEmpty(PasswordBox.Password))
            {
                if ((CurrentUser.UserId = new Repository().FindUser(Login_TextBox.Text, PasswordBox.Password)) != 0)
                {
                    Windows.loginWindow.Hide();
                    new MainWindow().Show();
                    Windows.loginWindow.Close();
                }
                else { SignIn_Error_Label.Content = "Incorrect username or password"; }
            }

            if (string.IsNullOrEmpty(Login_TextBox.Text))
            {
                Login_Error_Label.Content = "Please enter your login.";
                Login_TextBox.BorderBrush = new SolidColorBrush(Color.FromRgb(166, 38, 38));
            }

            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                PasswordBox_Error_Label.Content = "Please enter your password.";
                PasswordBox.BorderBrush = new SolidColorBrush(Color.FromRgb(166, 38, 38));
            }
        }

        private void Clean_Error_Labels()
        {
            Login_Error_Label.Content = "";
            Login_TextBox.BorderBrush = null;

            PasswordBox_Error_Label.Content = "";
            PasswordBox.BorderBrush = null;

            SignIn_Error_Label.Content = "";
        }


        private void Login_TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) => Clean_Error_Labels();

        private void PasswordBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) => Clean_Error_Labels();

        private void No_Account_Button_Click(object sender, RoutedEventArgs e)
        {
            Join_Button.Visibility = Visibility.Visible;
            Or_Label.Visibility = Visibility.Visible;
            Continue_Button.Visibility = Visibility.Visible;

            var doubleAnimation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1));
            
            Join_Button.BeginAnimation(OpacityProperty, doubleAnimation);
            Or_Label.BeginAnimation(OpacityProperty, doubleAnimation);
            Continue_Button.BeginAnimation(OpacityProperty, doubleAnimation);
        }
    }
}