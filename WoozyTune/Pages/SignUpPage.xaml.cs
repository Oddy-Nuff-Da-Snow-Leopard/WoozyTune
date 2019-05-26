using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WoozyTune.Pages
{
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void Login_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Login_Error_Label.Content = "";
            Login_TextBox.BorderBrush = null;
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

        private void SignUp_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Login_TextBox.Text) && !string.IsNullOrEmpty(PasswordBox1.Password))
            {
                string gender = "";
                foreach (var c in Gender_RadioButtons_Grid.Children)
                    if (((RadioButton)c).IsChecked == true)
                        gender = (c as RadioButton).Content.ToString();


                if ((CurrentUser.UserId = new Repository().CreateUser(Login_TextBox.Text,
                        PasswordBox1.Password, int.Parse(Age_TextBox.Text), gender, Username_TextBox.Text)) != 0)
                {
                    Windows.loginWindow.Hide();
                    new MainWindow().Show();
                    Windows.loginWindow.Close();
                }
                    //else { SignIn_Error_Label.Content = "Incorrect username or password"; }
            }
        }
    }
}
