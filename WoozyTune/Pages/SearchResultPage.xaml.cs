using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
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
using WoozyTune.UserControls;

namespace WoozyTune.Pages
{
    public partial class SearchResultPage : Page
    {
        public SearchResultPage(string search)
        {
            InitializeComponent();

            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = $"SELECT * FROM Tracks WHERE [Title] LIKE '%{search}%'";
                var command = new SqlCommand(select, connection);

                var reader = command.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    var trackViewUserControl = new TrackViewUserControl((int)reader.GetValue(0), reader.GetString(5), reader.GetString(6));
                    Grid.SetRow(trackViewUserControl, i++);
                    grid.Children.Add(trackViewUserControl);
                }
            }
        }
    }
}
