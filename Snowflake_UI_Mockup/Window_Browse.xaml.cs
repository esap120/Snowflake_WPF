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

namespace Snowflake_UI_Mockup
{
    /// <summary>
    /// Interaction logic for Window_Browse.xaml
    /// </summary>
    public partial class Window_Browse : Window
    {
        public Window_Browse()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@"Download selected STL files.");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(@"Most likely redirect to another page with additional
                              information, pictures, a more detailed description etc.
                               Could be cool to have a 3D preview.");
        }
    }
}
