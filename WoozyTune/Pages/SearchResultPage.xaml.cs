using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using WoozyTune.UserControls;

namespace WoozyTune.Pages
{
    public partial class SearchResultPage : Page
    {
        public SearchResultPage(string search)
        {
            InitializeComponent();

            #region
            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = $"SELECT * FROM Tracks WHERE [Title] LIKE '%{search}%'";
                var command = new SqlCommand(select, connection);

                var reader = command.ExecuteReader();

                int i = 1;
                while (reader.Read())
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    var trackViewUserControl = new TrackViewUserControl((int)reader.GetValue(0), reader.GetString(5), reader.GetString(6));
                    Grid.SetRow(trackViewUserControl, i++);
                    grid.Children.Add(trackViewUserControl);
                }
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = $"SELECT * FROM Tracks WHERE [Artist] LIKE '%{search}%'";
                var command = new SqlCommand(select, connection);

                var reader = command.ExecuteReader();

                int i = 1;
                while (reader.Read())
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    var trackViewUserControl = new TrackViewUserControl((int)reader.GetValue(0), reader.GetString(5), reader.GetString(6));
                    Grid.SetRow(trackViewUserControl, i++);
                    grid.Children.Add(trackViewUserControl);
                }
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = $"SELECT [UserId], [Username] FROM [UsersData] WHERE [Username] LIKE '%{search}%'";
                var command = new SqlCommand(select, connection);

                var reader = command.ExecuteReader();

                int i = 1;
                while (reader.Read())
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    var trackViewUserControl = new FollowUserControl((int)reader.GetValue(0), reader.GetString(1));
                    Grid.SetRow(trackViewUserControl, i++);
                    grid.Children.Add(trackViewUserControl);
                }
            }
            #endregion
        }
    }
}
