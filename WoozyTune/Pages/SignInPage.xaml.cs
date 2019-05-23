using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace WoozyTune.Pages
{
    public partial class SignInPage : Page
    {
        LoginWindow loginWindow;
        public SignInPage(LoginWindow loginWindow)
        {
            InitializeComponent();
            this.loginWindow = loginWindow;
        }

        private void Join_Button_Click(object sender, RoutedEventArgs e) => loginWindow.frame.Navigate(new SignUpPage(loginWindow));

        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(Login_TextBox.Text) && !string.IsNullOrEmpty(PasswordBox.Password))
            //{
            //    string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";

            //    using (var connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        var command = new SqlCommand("FindUser", connection);
            //        command.CommandType = CommandType.StoredProcedure;

            //        command.Parameters.Add(new SqlParameter { ParameterName = "@l", Value = Login_TextBox.Text });
            //        command.Parameters.Add(new SqlParameter { ParameterName = "@p", Value = PasswordBox.Password.GetHashCode() });
            //        command.Parameters.Add(new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });

            //        command.ExecuteNonQuery();

            //        if ((int)command.Parameters["@result"].Value == 1)
            //        {
                        loginWindow.Hide();
                        new MainWindow().Show();
                        loginWindow.Close();
            //        }
            //        else { SignIn_Error_Label.Content = "Incorrect username or password"; }
            //    }
            //}

            //if (string.IsNullOrEmpty(Login_TextBox.Text))
            //{
            //    Login_Error_Label.Content = "Please enter your login.";
            //    Login_TextBox.BorderBrush = new SolidColorBrush(Color.FromRgb(166, 38, 38));
            //}

            //if (string.IsNullOrEmpty(PasswordBox.Password))
            //{
            //    PasswordBox_Error_Label.Content = "Please enter your password.";
            //    PasswordBox.BorderBrush = new SolidColorBrush(Color.FromRgb(166, 38, 38));
            //}
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