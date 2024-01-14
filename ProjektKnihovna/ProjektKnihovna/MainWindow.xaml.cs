using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace ProjektKnihovna
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Databaze.Deserializuj();

            foreach (Uzivatel U in Databaze.Uzivatele)
            {
                if (U.Jmeno == "Pepa")
                {
                    Databaze.PrihlasenyUzivatel = U;
                }
            }
            PrihlasenyUzivatel.Content = Databaze.PrihlasenyUzivatel.Jmeno;

            TabulkaNabidka.ItemsSource = Databaze.Nabidka;
            TabulkaZakoupene.ItemsSource = Databaze.PrihlasenyUzivatel.Koupene;
        }

        private void ZavriAplikaci(object sender, RoutedEventArgs e)
        {
            //zavře aplikaci a ulozi do xml souboru
            try
            {
                Databaze.Serializuj();
                this.Close();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MinimalizujAplikaci(object sender, RoutedEventArgs e)
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
        private void ZmensiAplikaci(object sender, RoutedEventArgs e)
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

        private void ZvetsiAplikaci(object sender, RoutedEventArgs e)
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
            //Toto umožňuje pohyb ve zmešení aplikace
            try
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.DragMove();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TabulkaNabidka.SelectedItem != null)
            {
                var K = TabulkaNabidka.SelectedItem as Kniha;
                Databaze.Koupit(K);
            }
        }
    }
}
