using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using WoozyTune.UserControls;
using WoozyTune.Pages;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;

namespace WoozyTune
{
    public partial class MainWindow : Window
    {
        public MediaPlayer mediaPlayer;

        public List<TrackViewUserControl> list;
        
        private HomePage homePage;

        Repository repository = new Repository();
        public MainWindow()
        {
            InitializeComponent();
            list = new List<TrackViewUserControl>();

            Windows.mainWindow = this;
            homePage = new HomePage();

            Width = SystemParameters.PrimaryScreenWidth * 0.8;
            Height = SystemParameters.PrimaryScreenHeight * 0.8;
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            var a = new WindowStateUserControl(this);
            a.WindowState_Label.Opacity = 0.7;
            grid.Children.Add(a);

            mediaPlayer = new MediaPlayer();

            frame.Navigate(homePage);

            Profile_Button.Content = repository.GetUsername();

            var tuple = new Repository().GetUsersToFollow();
            for (int i = 0, j = 1; i < tuple.Item1.Length; i++, j++)
            {
                var followUserControl = new FollowUserControl(tuple.Item1[i], tuple.Item2[i]);
                Grid.SetRow(followUserControl, j);
                Users_Grid.Children.Add(followUserControl);
            }
        }

        private void Home_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Home_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Home_Underline.ActualWidth, Home_Button.ActualWidth, TimeSpan.FromSeconds(0.3)));
            Library_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Library_Underline.ActualWidth, 0, TimeSpan.FromSeconds(0.3)));
            Upload_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Upload_Underline.ActualWidth, 0, TimeSpan.FromSeconds(0.3)));

            frame.Navigate(homePage);

        }

        private void Library_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Home_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Home_Underline.ActualWidth, 0, TimeSpan.FromSeconds(0.3)));
            Library_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Library_Underline.ActualWidth, Library_Button.ActualWidth, TimeSpan.FromSeconds(0.3)));
            Upload_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Upload_Underline.ActualWidth, 0, TimeSpan.FromSeconds(0.3)));

            frame.Navigate(new LibraryPage());
        }


        private void Upload_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Home_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Home_Underline.ActualWidth, 0, TimeSpan.FromSeconds(0.3)));
            Library_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Library_Underline.ActualWidth, 0, TimeSpan.FromSeconds(0.3)));
            Upload_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Upload_Underline.ActualWidth, Upload_Button.ActualWidth, TimeSpan.FromSeconds(0.3)));

            frame.Navigate(new UploadPage());
        }


        private void Search_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                frame.Navigate(new SearchResultPage(Search_TextBox.Text));
        }

        private void Profile_Button_MouseDown(object sender, MouseButtonEventArgs e) => frame.Navigate(new ProfilePage(CurrentUser.UserId));

    }
}