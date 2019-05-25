using System.Windows;
using System.Data.SqlClient;
using System.Data;
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
                string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("CreateUser", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    string a = "";
                    foreach(var c in Gender_RadioButtons_Grid.Children)
                    {
                        if(((RadioButton)c).IsChecked == true)
                        {
                            a = (c as RadioButton).Content.ToString();
                        }
                    }

                    command.Parameters.Add(new SqlParameter { ParameterName = "@l", Value = Login_TextBox.Text });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@p", Value = PasswordBox1.Password.GetHashCode() });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@a", Value = int.Parse(Age_TextBox.Text) });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@g", Value =  a});
                    command.Parameters.Add(new SqlParameter { ParameterName = "@u", Value = Username_TextBox.Text});
                    var result = new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                    command.Parameters.Add(result);

                    command.ExecuteNonQuery();

                    if ((int)result.Value != 0)
                    {
                        CurrentUser.UserId = (int)result.Value;
                        Windows.loginWindow.Hide();
                        new MainWindow().Show();
                        Windows.loginWindow.Close();
                    }
                    //else { SignIn_Error_Label.Content = "Incorrect username or password"; }
                }
            }
        }
    }
}
