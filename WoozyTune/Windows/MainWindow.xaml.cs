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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WoozyTune.UserControls;

namespace WoozyTune
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Width = SystemParameters.PrimaryScreenWidth * 0.8;
            Height = SystemParameters.PrimaryScreenHeight * 0.8;
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            var a = new WindowStateUserControl(this);
            a.WindowState_Label.Opacity = 0.7;
            grid.Children.Add(a);
        }



        private void BurgerCategory_MouseDown(object sender, MouseButtonEventArgs e) =>
            Home_Underline.BeginAnimation(WidthProperty, new DoubleAnimation(Home_Underline.ActualWidth, Home_Button.Width, TimeSpan.FromSeconds(0.7)));

        private void Home_Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
