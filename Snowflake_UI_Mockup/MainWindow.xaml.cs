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

namespace Snowflake_UI_Mockup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_Snowflake_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Either load a menu or maybe a website?");
        }

        private void Image_KinectForWindows_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.microsoft.com/en-us/kinectforwindows/");
        }

        private void Button_Browse_Click(object sender, RoutedEventArgs e)
        {
            Window_Browse browseWindow = new Window_Browse();
            browseWindow.Show();
            this.Close();
        }

        private void Button_Scan_Click(object sender, RoutedEventArgs e)
        {
            WindowScan scanWindow = new WindowScan();
            scanWindow.Show();
            this.Close();
        }

        private void Button_Print_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Probably open the Metro App for printing to make use of the charms bar");
        }
    }
}
