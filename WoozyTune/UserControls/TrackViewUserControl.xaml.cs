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
using System.Windows.Media.Imaging;

namespace WoozyTune.UserControls
{
    public partial class TrackViewUserControl : UserControl
    {
        private string trackPath;

        string playIconPath = "/WoozyTune;component/Icons/Play.png";
        string pauseIconPath = "/WoozyTune;component/Icons/Pause.png";

        public TrackViewUserControl(string trackPath, string imagePath)
        {
            InitializeComponent();
            this.trackPath = trackPath;
            Image.Source = new BitmapImage(new Uri(imagePath));

            
            Icon.Source = new BitmapImage(new Uri(playIconPath));
        }

        private void Playback_Button_Click(object sender, RoutedEventArgs e)
        {
            //if(Playback_Button.IsChecked == false)
            //    Windows.mainWindow.Open(U)

            //else


        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Playback_Button.Visibility = Visibility.Visible;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Playback_Button.Visibility = Visibility.Hidden;
        }

        private void Playback_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Playback_Button.Visibility = Visibility.Visible;
        }
    }
}
