using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using WoozyTune.UserControls;

namespace WoozyTune.Pages
{
    public partial class ProfilePage : Page
    {
        private int userId;
        Repository repository = new Repository();

        public ProfilePage(int userId)
        {
            InitializeComponent();
            if (userId == CurrentUser.UserId)
                Follow_Button.Visibility = Visibility.Hidden;

            this.userId = userId;


            if (repository.CheckForFollow(userId) == 1)
                Follow_Button.Content = "Followed!";

            #region
            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = $"SELECT [Artist], [Title], [TrackPath], [ImagePath] FROM Tracks WHERE [UserId] = {userId}";
                var command = new SqlCommand(select, connection);

                var reader = command.ExecuteReader();

                int i = 1;
                while (reader.Read())
                {
                    Tracks_Grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    var userTrackUserControl = new UserTrackUserControl(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    Grid.SetRow(userTrackUserControl, i++);
                    Tracks_Grid.Children.Add(userTrackUserControl);
                }
            }
            #endregion
        }

        private void Follow_Button_Click(object sender, RoutedEventArgs e)
        {
            if ((string)Follow_Button.Content == "Followed!")
            {
                repository.DropFollow(userId);
                Follow_Button.Content = "Follow";
            }

            else
            {
                repository.AddFollow(userId);
                Follow_Button.Content = "Followed!";
            }
        }
    }
}
