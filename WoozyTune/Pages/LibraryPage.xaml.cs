using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using WoozyTune.UserControls;

namespace WoozyTune.Pages
{
    public partial class LibraryPage : Page
    {
        public LibraryPage()
        {
            InitializeComponent();

            #region
            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = $"SELECT [Artist], [Title], [TrackPath], [ImagePath] FROM Tracks INNER JOIN UsersHistory ON Tracks.[TrackId] =" +
                    $" UsersHistory.[TrackId] WHERE UsersHistory.UserId = {CurrentUser.UserId}";
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
    }
}
