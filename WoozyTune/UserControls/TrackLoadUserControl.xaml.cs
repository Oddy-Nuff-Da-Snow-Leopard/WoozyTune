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
using Microsoft.Win32;
using System.Reflection;
using System.IO;

namespace WoozyTune.UserControls
{
    public partial class TrackLoadUserControl : UserControl
    {
        private string path;
        private string fileName;
        private string format;

        public TrackLoadUserControl(string path)
        {
            InitializeComponent();
            Genre_ComboBox.ItemsSource = new List<string> { "None", "Trap", "Hip-Hop", "Lo-fi", "Rock" };
            Genre_ComboBox.SelectedItem = "None";
            Image.Source = new BitmapImage(new Uri("/WoozyTune;component/BackgroundImages/LoadImageBackground.jpg", UriKind.Relative));

            this.path = path;
            fileName = this.path.Substring(path.LastIndexOf(@"\") + 1);
            format = this.path.Substring(path.LastIndexOf("."));
            File_Name_Label.Content = fileName;
        }

        private void Upload_Button_Style_Click(object sender, RoutedEventArgs e)
        {
            var rnd = new Random(Environment.TickCount);
            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";
            string catalog = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var newPath = catalog + @"\Tracks\" + (rnd.Next(int.MinValue, int.MaxValue).ToString() + fileName).GetHashCode() + format;
            File.Copy(path, newPath);

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    var command = new SqlCommand("UploadTrack", connection);
            //    command.CommandType = CommandType.StoredProcedure;

            //    command.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = CurrentUser.UserId});
            //    command.Parameters.Add(new SqlParameter { ParameterName = "@artist", Value = Artist_TextBox.Text });
            //    command.Parameters.Add(new SqlParameter { ParameterName = "@title", Value = Title_TextBox.Text });
            //    command.Parameters.Add(new SqlParameter { ParameterName = "@path", Value = newPath });
            //    command.Parameters.Add(new SqlParameter { ParameterName = "@imagePath", Value = 2});
            //    command.Parameters.Add(new SqlParameter { ParameterName = "@genre", Value = Genre_ComboBox.SelectedItem });

            //    command.ExecuteNonQuery();
            //}
        }

        private void Upload_Image_Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images files(*.jpg *.jpe *.png *.bmp*)|*.txt|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == false)
                return;
            string filename = openFileDialog.FileName;
            Image.Source = new BitmapImage(new Uri(filename, UriKind.Absolute));
        }
    }
}
