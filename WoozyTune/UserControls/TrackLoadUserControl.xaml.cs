using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
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
            imagePath = catalog + @"\Images\Default track images\DefaultTrackImage.jpg";
            Image.Source = new BitmapImage(new Uri(imagePath));
            Genre_ComboBox.ItemsSource = new List<string> { "None", "Ambient", "Country", "Dubstep", "Electronic", "Hip-Hop & Rap", "Rock", "Lo-fi", "Trap"};
            Genre_ComboBox.SelectedItem = "None";

            this.trackPath = trackPath;
            trackFileName = this.trackPath.Substring(trackPath.LastIndexOf(@"\") + 1);
            File_Name_Label.Content = trackFileName;
        }

        private void Upload_Button_Click(object sender, RoutedEventArgs e)
        {
            var rnd = new Random(Environment.TickCount);
            var newTrackPath = catalog + @"\Tracks\" + (rnd.Next(int.MinValue, int.MaxValue).ToString() + trackFileName).GetHashCode() + trackPath.Substring(trackPath.LastIndexOf("."));
            File.Copy(trackPath, newTrackPath);

            imageFileName = imagePath.Substring(imagePath.LastIndexOf(@"\") + 1);
            var newImagePath = catalog + @"\Images\" + (rnd.Next(int.MinValue, int.MaxValue).ToString() + imageFileName).GetHashCode() + imagePath.Substring(imagePath.LastIndexOf("."));
            if (flag)
                File.Copy(imagePath, newImagePath);
            else
                newImagePath = imagePath;

            new Repository().UploadTrack(0, Artist_TextBox.Text, Title_TextBox.Text, newTrackPath, newImagePath, Genre_ComboBox.Text);
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