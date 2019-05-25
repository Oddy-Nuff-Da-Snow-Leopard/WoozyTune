using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;
using System.Reflection;
using System.IO;

namespace WoozyTune.UserControls
{
    public partial class TrackLoadUserControl : UserControl
    {
        private string trackPath, imagePath;
        private string trackFileName, imageFileName;

        string catalog = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public TrackLoadUserControl(string trackPath)
        {
            InitializeComponent();
            imagePath = catalog + @"\Images\Default track images\DefaultTrackImage.png";
            Image.Source = new BitmapImage(new Uri(imagePath));
            Genre_ComboBox.ItemsSource = new List<string> { "None", "Trap", "Hip-Hop", "Lo-fi", "Rock" };
            Genre_ComboBox.SelectedItem = "None";

            this.trackPath = trackPath;
            trackFileName = this.trackPath.Substring(trackPath.LastIndexOf(@"\") + 1);
            File_Name_Label.Content = trackFileName;
        }

        private void Upload_Button_Style_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";

            var rnd = new Random(Environment.TickCount);
            var newTrackPath = catalog + @"\Tracks\" + (rnd.Next(int.MinValue, int.MaxValue).ToString() + trackFileName).GetHashCode() + trackPath.Substring(trackPath.LastIndexOf("."));
            File.Copy(trackPath, newTrackPath);

            imageFileName = imagePath.Substring(trackPath.LastIndexOf(@"\") + 1);
            var newImagePath = catalog + @"\Images\" + (rnd.Next(int.MinValue, int.MaxValue).ToString() + imageFileName).GetHashCode() + imagePath.Substring(imagePath.LastIndexOf("."));
            if (flag)
                File.Copy(imagePath, newImagePath);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UploadTrack", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = CurrentUser.UserId });
                command.Parameters.Add(new SqlParameter { ParameterName = "@artist", Value = Artist_TextBox.Text });
                command.Parameters.Add(new SqlParameter { ParameterName = "@title", Value = Title_TextBox.Text });
                command.Parameters.Add(new SqlParameter { ParameterName = "@path", Value = newTrackPath });
                command.Parameters.Add(new SqlParameter { ParameterName = "@imagePath", Value = newImagePath });
                command.Parameters.Add(new SqlParameter { ParameterName = "@genre", Value = Genre_ComboBox.SelectedItem });

                command.ExecuteNonQuery();
            }
        }

        private bool flag = false;
        private void Upload_Image_Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images files(*.jpg;*.jpe;*.png;*.bmp*)|*.jpg;*.jpe;*.png;*.bmp*| All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == false)
                return;
            flag = true;
            
            imagePath = openFileDialog.FileName;
            Image.Source = new BitmapImage(new Uri(imagePath));
        }
    }
}