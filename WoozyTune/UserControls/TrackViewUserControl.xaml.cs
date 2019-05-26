using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Data.SqlClient;
using System.Data;

namespace WoozyTune.UserControls
{
    public partial class TrackViewUserControl : UserControl
    {
        private string trackPath;
        private int trackId;
        BitmapImage playIcon, pauseIcon;

        public TrackViewUserControl(int trackId, string trackPath, string imagePath)
        {
            InitializeComponent();
            this.trackPath = trackPath;
            this.trackId = trackId;
            Image.Source = new BitmapImage(new Uri(imagePath));


            playIcon = new BitmapImage(new Uri("/WoozyTune;component/Icons/Play.png", UriKind.Relative));
            pauseIcon = new BitmapImage(new Uri("/WoozyTune;component/Icons/Pause.png", UriKind.Relative));

            Icon.Source = playIcon;

            string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string select = $"SELECT [Artist], [Title] FROM Tracks WHERE [TrackId] = {trackId}";
                var command = new SqlCommand(select, connection);

                var reader = command.ExecuteReader();
                reader.Read();
                Artist_TextBox.Content = reader.GetString(0);
                Title_TextBox.Content = reader.GetString(1);
            }

        }

        int k = 0;
        private void Playback_Button_Click(object sender, RoutedEventArgs e)
        {
            if (k == 0)
            {
                Windows.mainWindow.mediaPlayer.Open(new Uri(trackPath, UriKind.Absolute));
                Windows.mainWindow.mediaPlayer.Play();
                foreach (var a in Windows.mainWindow.list)
                    a.Icon.Source = playIcon;

                Icon.Source = pauseIcon;


                foreach (var a in Windows.mainWindow.list)
                    a.k = 0;

                string connectionString = @"Data Source=JAMES-SPLEEN;Initial Catalog=WoozyTune;Integrated Security=True";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("AddHistory", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter { ParameterName = "@userId", Value = CurrentUser.UserId });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@trackId", Value = trackId });
                    command.ExecuteNonQuery();
                }
            }
            

            if(k == 1)
            {
                Windows.mainWindow.mediaPlayer.Pause();
                Icon.Source = playIcon;
                
                k = 1;
            }

            if (k == 2)
            {
                Windows.mainWindow.mediaPlayer.Play();
                Icon.Source = pauseIcon;
                
                k = 0;
            }

            k++;
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Playback_Button.Visibility = Visibility.Visible;
            Icon.Visibility = Visibility.Visible;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Playback_Button.Visibility = Visibility.Hidden;
            Icon.Visibility = Visibility.Hidden;
        }

        private void Playback_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Playback_Button.Visibility = Visibility.Visible;
            Icon.Visibility = Visibility.Visible;
        }
    }
}
