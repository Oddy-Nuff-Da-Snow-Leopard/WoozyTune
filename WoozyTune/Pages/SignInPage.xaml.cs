using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Animation;
using WoozyTune.UserControls;

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

        private void Join_Button_Click(object sender, RoutedEventArgs e)
        {
            loginWindow.frame.Navigate(new SignUpPage());
        }

        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(SignIn_Login_TextBox.Text) && !string.IsNullOrEmpty(SignIn_PasswordBox.Password))
            //{
            //    string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";

            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        var command = new SqlCommand("FindUser", connection);
            //        command.CommandType = CommandType.StoredProcedure;

            //        var loginParameter = new SqlParameter { ParameterName = "@l", Value = SignIn_Login_TextBox.Text };
            //        var passwordParameter = new SqlParameter { ParameterName = "@p", Value = int.Parse(SignIn_PasswordBox.Password)/* PasswordBox.Password.GetHashCode()*/ };
            //        var result = new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            //        command.Parameters.Add(loginParameter);
            //        command.Parameters.Add(passwordParameter);
            //        command.Parameters.Add(result);

            //        command.ExecuteNonQuery();

            //        if ((int)result.Value == 1)
            //        {
                           

                loginWindow.Hide();
                new MainWindow().Show();
                loginWindow.Close();
                            
                //        }
                //    }
                //    else
                //        SignIn_Button_Error_Label.Content = "Incorrect username or password";
                //}

            if(string.IsNullOrEmpty(SignIn_Login_TextBox.Text))
            {
                SignIn_Login_Error_Label.Content = "Please enter your login.";
                SignIn_Login_TextBox.BorderBrush = Brushes.Red;
            }


            if(string.IsNullOrEmpty(SignIn_PasswordBox.Password))
            {
                SignIn_PasswordBox_Error_Label.Content = "Please enter your password.";
                SignIn_PasswordBox.BorderBrush = Brushes.Red;
            }
        }

        private void Continue_Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Login_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            SignIn_Login_Error_Label.Content = "";
            SignIn_Login_TextBox.BorderBrush = null;
            //if (e.Text == '!' &&  e.Text == "-")
            //{
            //    e.Handled = true; // отклоняем ввод
            //    Login_Error_Label.Content = "Login ";
            //}
        }

        private void Login_TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Space)
            //{
            //    e.Handled = true; // если пробел, отклоняем ввод
            //}
        }

        private void Clean_Error_Labels()
        {
            SignIn_Login_Error_Label.Content = "";
            SignIn_Login_TextBox.BorderBrush = null;

            SignIn_PasswordBox_Error_Label.Content = "";
            SignIn_PasswordBox.BorderBrush = null;

            SignIn_Button_Error_Label.Content = "";
        }


        private void SignIn_Login_TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) => Clean_Error_Labels();

        private void SignIn_PasswordBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) => Clean_Error_Labels();

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Join_Button.Visibility = Visibility.Visible;
            //or.Visibility = Visibility.Visible;
            Continue_Button.Visibility = Visibility.Visible;

            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = Join_Button.Opacity;
            doubleAnimation.To = 1;

            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            Join_Button.BeginAnimation(Button.OpacityProperty, doubleAnimation);

            //or.BeginAnimation(Label.OpacityProperty, doubleAnimation);
            Continue_Button.BeginAnimation(Button.OpacityProperty, doubleAnimation);

        }
    }
}
