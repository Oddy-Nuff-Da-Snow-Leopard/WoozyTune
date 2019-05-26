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
using System.Media;
using System.Windows.Shapes;

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
