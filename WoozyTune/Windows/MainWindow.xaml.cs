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

            grid.Children.Add(new WindowStateUserControl(this));
        }
    }
}
