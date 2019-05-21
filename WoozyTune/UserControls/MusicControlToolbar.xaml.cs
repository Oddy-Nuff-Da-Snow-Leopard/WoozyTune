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

namespace WoozyTune.UserControls
{
    public partial class MusicControlToolbar : UserControl
    {
        public MusicControlToolbar()
        {
            InitializeComponent();
        }

        private MediaPlayer player = new MediaPlayer();

        private void Playback_Button_Click(object sender, RoutedEventArgs e)
        {
            player.Open(new Uri("D:/Music/music.mp3", UriKind.Absolute));
            player.Play();
        }
    }
}
