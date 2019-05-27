using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WoozyTune.UserControls
{
    public partial class UserTrackUserControl : UserControl
    {
        private string trackPath;
        public UserTrackUserControl(string artist, string title, string trackPath, string imagePath)
        {
            InitializeComponent();
            Track_Name_TextBlock.Text = artist + " - " + title;
            Image.Source = new BitmapImage(new Uri(imagePath));
            this.trackPath = trackPath;
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Windows.mainWindow.mediaPlayer.Open(new Uri(trackPath));
            Windows.mainWindow.mediaPlayer.Play();
        }
    }
}
