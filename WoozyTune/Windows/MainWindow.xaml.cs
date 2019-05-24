﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WoozyTune.UserControls;
using WoozyTune.Pages;
using System.Windows.Media;

namespace WoozyTune
{
    public partial class MainWindow : Window
    {
        private HomePage homePage;
        private LibraryPage libraryPage;
        private MediaPlayer mediaPlayer;
        private UploadPage uploadPage;
        

        public MainWindow()
        {
            InitializeComponent();
            Width = SystemParameters.PrimaryScreenWidth * 0.8;
            Height = SystemParameters.PrimaryScreenHeight * 0.8;
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            var a = new WindowStateUserControl(this);
            a.WindowState_Label.Opacity = 0.7;
            grid.Children.Add(a);

            homePage = new HomePage(this);
            libraryPage = new LibraryPage();
            mediaPlayer = new MediaPlayer();

            frame.Navigate(homePage);

            //MessageBox.Show(UserId.ToString());
        }

        private void Home_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Home_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Home_Underline.ActualWidth, Home_Button.ActualWidth, TimeSpan.FromSeconds(0.3)));
            frame.Navigate(homePage);
        }

        private void Library_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Library_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Library_Underline.ActualWidth, Library_Button.ActualWidth, TimeSpan.FromSeconds(0.3)));
            frame.Navigate(libraryPage);
        }

        public void GetRef(Uri path)
        {
            mediaPlayer.Close();
            mediaPlayer.Open(path);
            mediaPlayer.Play();
        }

        private void Playback_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Playback_Button.IsChecked == true)
                mediaPlayer.Pause();
            else
                mediaPlayer.Play();
        }

        private void Upload_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Upload_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Upload_Underline.ActualWidth, Upload_Button.ActualWidth, TimeSpan.FromSeconds(0.3)));
            frame.Navigate(uploadPage = new UploadPage());
        }

    }
}
