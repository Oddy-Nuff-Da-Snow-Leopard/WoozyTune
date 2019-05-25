using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Controls;
using WoozyTune.UserControls;

namespace WoozyTune.Pages
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            var gridList = new List<Grid>();
            gridList.Add(Trap);
            foreach (var g in gridList)
            {
                LoadPlayList(g);
            }

        }

        private void LoadPlayList(Grid grid)
        {
            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = $"SELECT * FROM Tracks WHERE Genre = '{grid.Name}'";
                var command = new SqlCommand(select, connection);

                var reader = command.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    var trackViewUserControl = new TrackViewUserControl(reader.GetString(5), reader.GetString(6));
                    Grid.SetColumn(trackViewUserControl, i++);
                    grid.Children.Add(trackViewUserControl);
                }
            }

        }
    }
}
