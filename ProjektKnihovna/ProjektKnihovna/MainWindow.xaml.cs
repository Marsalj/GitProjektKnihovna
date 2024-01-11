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

namespace ProjektKnihovna
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            //zavře aplikaci
            try
            {
                this.Close();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MinimizeApp(object sender, RoutedEventArgs e)
        {
            //minimalizuje aplikaci
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ResizeSmallApp(object sender, RoutedEventArgs e)
        {
            //Zmenší aplikaci
            try
            {
                this.WindowState = WindowState.Normal;
                this.Height = 480;
                this.Width = 852;
                ButtonResizeSmall.IsEnabled = false;
                ButtonResizeSmall.Visibility = Visibility.Hidden;
                ButtonResizeBig.IsEnabled = true;
                ButtonResizeBig.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResizeBigApp(object sender, RoutedEventArgs e)
        {
            //Zvětší aplikaci
            try
            {
                this.WindowState = WindowState.Maximized;
                this.Height = 1080;
                this.Width = 1920;
                ButtonResizeSmall.IsEnabled = true;
                ButtonResizeSmall.Visibility = Visibility.Visible;
                ButtonResizeBig.IsEnabled = false;
                ButtonResizeBig.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
