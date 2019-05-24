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
using System.Reflection;
using WoozyTune.UserControls;
using System.IO;
using Microsoft.Win32;

namespace WoozyTune.Pages
{
    public partial class UploadPage : Page
    {
        List<string> paths;
        public UploadPage()
        {
            InitializeComponent();
            paths = new List<string>();
            Drop_Grid.AllowDrop = true;
        }

        private int i = 1;
        private void Drop_Grid_Drop(object sender, DragEventArgs e)
        {
            var b = (string[])e.Data.GetData(DataFormats.FileDrop);
            var path = b[0];
            if (!paths.Contains(path))
            {
                paths.Add(path);
                var trackLoadUserControl = new TrackLoadUserControl(path);
                Grid.SetRow(trackLoadUserControl, i++);
                Load_Grid.Children.Add(trackLoadUserControl);
            }
            //ScrollViewer.ScrollToVerticalOffset(300);
        }

        private void Choose_Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
