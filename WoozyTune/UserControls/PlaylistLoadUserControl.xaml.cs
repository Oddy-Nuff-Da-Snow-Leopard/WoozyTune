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
    public partial class PlaylistLoadUserControl : UserControl
    {
        private string[] paths;
        private string imagePath;

        string catalog = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        List<TextBox> textBoxes;

        public PlaylistLoadUserControl(string[] paths)
        {
            InitializeComponent();
            Genre_ComboBox.ItemsSource = new List<string> { "None", "Ambient", "Classical", "Country", "Dubstep", "Electronic", "Hip-Hop & Rap", "Lo-fi", "Trap" };
            Genre_ComboBox.SelectedItem = "None";

            Type_ComboBox.ItemsSource = new List<string> { "Album", "Compilation", "EP", "Playlist", "Mixtape" };
            Type_ComboBox.SelectedItem = "Playlist";

            imagePath = catalog + @"\Images\Default track images\DefaultTrackImage.jpg";
            Image.Source = new BitmapImage(new Uri(imagePath));

            this.paths = paths;

            int i = 0;
            textBoxes = new List<TextBox>();
            foreach (var path in paths)
            {
                var textBox = new TextBox();
                var title = path.Substring(path.LastIndexOf(@"\") + 1);
                var format = path.Substring(path.LastIndexOf(@"."));
                textBox.Text = title.Substring(title.LastIndexOf("-") + 2).Replace(format, "");

                Grid.SetRow(textBox, i++);
                File_Names_Grid.Children.Add(textBox);
                textBoxes.Add(textBox);
            }
        }


        private void Upload_Button_Click(object sender, RoutedEventArgs e)
        {
            var newPaths = new List<string>();
            var rnd = new Random(Environment.TickCount);
            foreach (var path in paths)
            {
                var newPath = catalog + @"\Tracks\" + (rnd.Next(int.MinValue, int.MaxValue).ToString() + path.Substring(path.LastIndexOf(@"\") + 1)).GetHashCode() +
                    path.Substring(path.LastIndexOf("."));
                File.Copy(path, newPath);
                newPaths.Add(newPath);
            }

            var newImagePath = catalog + @"\Images\" + (rnd.Next(int.MinValue, int.MaxValue).ToString() + imagePath.Substring(imagePath.LastIndexOf(@"\") + 1)).GetHashCode() + imagePath.Substring(imagePath.LastIndexOf("."));
            if (flag)
                File.Copy(imagePath, newImagePath);
            else
                newImagePath = imagePath;

            var repository = new Repository();

            var playlistId = repository.UploadPlaylist(repository.GetUsername(), Title_TextBox.Text, newImagePath, Type_ComboBox.SelectedItem.ToString(), Genre_ComboBox.SelectedItem.ToString());

            int i = 0;
            foreach(var newPath in newPaths)
                repository.UploadTrack(playlistId, repository.GetUsername(), textBoxes[i++].Text, newPath, newImagePath, Genre_ComboBox.Text);
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
