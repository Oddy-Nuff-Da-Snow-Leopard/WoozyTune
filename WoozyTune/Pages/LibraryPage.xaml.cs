using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using WoozyTune.UserControls;

namespace WoozyTune.Pages
{
    public partial class LibraryPage : Page
    {
        public LibraryPage()
        {
            InitializeComponent();

            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = $"SELECT [Artist], [Title], [TrackPath], [ImagePath] FROM Tracks INNER JOIN UsersHistory ON Tracks.[TrackId] =" +
                    $" UsersHistory.[TrackId] WHERE UsersHistory.UserId = {CurrentUser.UserId}";
                var command = new SqlCommand(select, connection);

                var reader = command.ExecuteReader();

                int i = 1;
                while (reader.Read() && i != 13)
                {
                    var userTrackUserControl = new UserTrackUserControl(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    Grid.SetRow(userTrackUserControl, i++);
                    Tracks_Grid.Children.Add(userTrackUserControl);
                }
            }
        }
    }
}
