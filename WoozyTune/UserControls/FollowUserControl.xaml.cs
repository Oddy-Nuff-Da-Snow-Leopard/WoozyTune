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
using WoozyTune.UserControls;
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
