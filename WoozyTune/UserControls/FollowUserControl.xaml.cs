using System.Windows;
using System.Windows.Controls;
using WoozyTune.Pages;

namespace WoozyTune.UserControls
{
    public partial class FollowUserControl : UserControl
    {
        private int userId;
        public FollowUserControl(int userId, string username)
        {
            InitializeComponent();
            Open_User_Page_Button.Content = username;
            this.userId = userId;
        }

        private void Open_User_Page_Button_Click(object sender, RoutedEventArgs e)
        {
            Windows.mainWindow.frame.Navigate(new ProfilePage(userId));
        }
    }
}
