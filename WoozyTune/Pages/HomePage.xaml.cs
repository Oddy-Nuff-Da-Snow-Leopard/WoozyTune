using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
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
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        MainWindow mainWindow;

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        public HomePage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = /*$ {}*/"SELECT * FROM Tracks WHERE Genre = 'Chill'";


                var command = new SqlCommand(select, connection);

                var reader = command.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    var a = new g();
                    var c = reader.GetString(2);
                    a.image.Source = new BitmapImage(new Uri(reader.GetString(3)));
                    a.image.MouseEnter += (s, t) => { a.play.Visibility = Visibility.Visible; };
                    
                    a.play.Click += (s, t) => { mainWindow.GetRef(new Uri(c)); };
                    Grid.SetColumn(a, i++);
                    grid.Children.Add(a);
                }

            }



        }
    }
}
