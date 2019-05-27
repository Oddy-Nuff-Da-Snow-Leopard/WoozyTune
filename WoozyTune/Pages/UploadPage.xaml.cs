using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WoozyTune.UserControls;
using Microsoft.Win32;
using System.Windows.Media;

namespace WoozyTune.Pages
{
    

    public partial class UploadPage : Page
    {
        List<string> paths;
        public UploadPage()
        {
            InitializeComponent();
            paths = new List<string>();
        }


        int i = 1;
        private void Drop_Border_Drop(object sender, DragEventArgs e)
        {
            Drop_Border.Background = new SolidColorBrush(Color.FromRgb(230, 230, 230));

            if (Playlist_CheckBox.IsChecked == true)
            {
                var playlistLoadUserControl = new PlaylistLoadUserControl((string[])e.Data.GetData(DataFormats.FileDrop));
                Grid.SetRow(playlistLoadUserControl, i);
                Load_Grid.Children.Add(playlistLoadUserControl);

            }

            else
            {
                var FileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var fileName in FileNames)
                {
                    var trackLoadUserControl = new TrackLoadUserControl(fileName);
                    Grid.SetRow(trackLoadUserControl, i++);
                    Load_Grid.Children.Add(trackLoadUserControl);
                }
            }

        }


        private void Choose_Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Select files",
                Filter = "Audio files(*.mp3;*.waw;*.ra;*.au;*.ram*;*.aiff;*.alac;*.flac)|*.mp3;*.waw;*.ra;*.au;*.ram*;*.aiff;*.alac;*.flac| All files(*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == false) return;

            foreach (var fileName in openFileDialog.FileNames)
            {
                var trackLoadUserControl = new TrackLoadUserControl(fileName);
                Grid.SetRow(trackLoadUserControl, i++);
                Load_Grid.Children.Add(trackLoadUserControl);
            }
        }
       

        private void Drop_Border_DragEnter(object sender, DragEventArgs e)
        {
            Drop_Border.Background = new SolidColorBrush(Color.FromRgb(191, 191, 191));
        }

        private void Drop_Border_DragLeave(object sender, DragEventArgs e)
        {
            Drop_Border.Background = new SolidColorBrush(Color.FromRgb(230, 230, 230));
        }

        public void Remove(UIElement uIElement)
        {
            Load_Grid.Children.Remove(uIElement);
        }
    }
}
