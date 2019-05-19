using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;

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

        private void Join_Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Navigate(new SignUpPage());
        }

        private void SignIn_Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("GetUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                var loginParameter = new SqlParameter { ParameterName = "@l", Value = Login_TextBox.Text};
                var passwordParameter = new SqlParameter { ParameterName = "@p", Value = int.Parse(PasswordBox.Password)/* PasswordBox.Password.GetHashCode()*/ };
                var result = new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output};

                command.Parameters.Add(loginParameter);
                command.Parameters.Add(passwordParameter);
                command.Parameters.Add(result);

                command.ExecuteNonQuery();

                if((int)result.Value == 1)
                {
                    if (mainWindow.WindowState != WindowState.Maximized)
                    {
                        mainWindow.Hide();
                        mainWindow.Width = SystemParameters.PrimaryScreenWidth * 0.8;
                        mainWindow.Height = SystemParameters.PrimaryScreenHeight * 0.8;
                        mainWindow.Top = (SystemParameters.PrimaryScreenHeight - ActualHeight) / 2;
                        mainWindow.Left = (SystemParameters.PrimaryScreenWidth - ActualWidth) / 2;
                        mainWindow.Show();

                        mainWindow.frame.Navigate(new HomePage());
                    }
                }
            }
        }

        private void Continue_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Join_Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
