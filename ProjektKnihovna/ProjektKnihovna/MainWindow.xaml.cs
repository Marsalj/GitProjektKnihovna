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
        /*Ekniha kniha1 = new Ekniha("Pán Prstenů", 500, 458);
        Ekniha kniha2 = new Ekniha("Volání Cthulhu", 300, 666);
        Ekniha kniha3 = new Ekniha("Pejsek a Kočička", 120, 50);
        Audiokniha kniha4 = new Audiokniha("Pán Prstenů", 500, "Petr Macháček");

        Uzivatel admin = new Uzivatel("Admin","Admin", "Admin");*/

        public MainWindow()
        {
            InitializeComponent();
            Databaze.Deserializuj();

            //Databaze.Nabidka.Add(kniha1);
            //Databaze.Nabidka.Add(kniha2);
            //Databaze.Nabidka.Add(kniha3);
            //Databaze.Nabidka.Add(kniha4);

            //Databaze.Uzivatele.Add(admin);

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

                TabulkaNabidka.Height = 200;
                TabulkaZakoupene.Height = 200;
                TabulkaNabidka.Width = 400;
                TabulkaZakoupene.Width = 400;

                ButtonAdd.Width = 400;
                ButtonDelete.Width = 400;

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

                TabulkaNabidka.Height = 450;
                TabulkaZakoupene.Height = 450;
                TabulkaNabidka.Width = 700;
                TabulkaZakoupene.Width = 700;

                ButtonAdd.Width = 700;
                ButtonDelete.Width = 700;

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

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TabulkaZakoupene.SelectedItem != null)
            {
                var K = TabulkaZakoupene.SelectedItem as Kniha;
                Databaze.Odstranit(K);
            }
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string jmeno = TextJmeno.Text;
                string email = TextEmail.Text;
                string heslo = TextHeslo.Text;
                bool spatneUdaje = false;
                int index = 0;

                foreach (Uzivatel U in Databaze.Uzivatele)
                {
                    if (U.Jmeno == jmeno && U.Heslo == heslo && U.Email == email)
                    {
                        spatneUdaje = false;
                        index = Databaze.Uzivatele.IndexOf(U);

                    }
                    else
                    {
                        spatneUdaje = true;
                    }
                }

                if (spatneUdaje == false)
                {
                    Databaze.PrihlasenyUzivatel = Databaze.Uzivatele.ElementAt(index);
                    PrihlasenyUzivatel.Content = "Přihlášený uživatel: " + Databaze.PrihlasenyUzivatel.Jmeno;

                    TabulkaNabidka.ItemsSource = Databaze.Nabidka;
                    TabulkaZakoupene.ItemsSource = Databaze.PrihlasenyUzivatel.Koupene;

                    LabelError1.Visibility = Visibility.Hidden;
                    LabelError1.IsEnabled = false;
                    LabelError2.Visibility = Visibility.Hidden;
                    LabelError2.IsEnabled = false;
                    LabelJmeno.Visibility = Visibility.Hidden;
                    LabelJmeno.IsEnabled = false;
                    LabelEmail.Visibility = Visibility.Hidden;
                    LabelEmail.IsEnabled = false;
                    LabelHeslo.Visibility = Visibility.Hidden;
                    LabelHeslo.IsEnabled = false;
                    TextJmeno.Visibility = Visibility.Hidden;
                    TextJmeno.IsEnabled = false;
                    TextEmail.Visibility = Visibility.Hidden;
                    TextEmail.IsEnabled = false;
                    TextHeslo.Visibility = Visibility.Hidden;
                    TextHeslo.IsEnabled = false;
                    LabelNazev.Visibility = Visibility.Hidden;
                    LabelNazev.IsEnabled = false;
                    ButtonLogin.Visibility = Visibility.Hidden;
                    ButtonLogin.IsEnabled = false;
                    ButtonRegister.Visibility = Visibility.Hidden;
                    ButtonRegister.IsEnabled = false;


                    TabulkaNabidka.Visibility = Visibility.Visible;
                    TabulkaNabidka.IsEnabled = true;
                    TabulkaZakoupene.Visibility = Visibility.Visible;
                    TabulkaZakoupene.IsEnabled = true;
                    LabelNabidka.Visibility = Visibility.Visible;
                    LabelNabidka.IsEnabled = true;
                    LabelZakoupeno.Visibility = Visibility.Visible;
                    LabelZakoupeno.IsEnabled = true;
                    PrihlasenyUzivatel.Visibility = Visibility.Visible;
                    PrihlasenyUzivatel.IsEnabled = true;
                    ButtonAdd.Visibility = Visibility.Visible;
                    ButtonAdd.IsEnabled = true;
                    ButtonDelete.Visibility = Visibility.Visible;
                    ButtonDelete.IsEnabled = true;
                    ButtonOdhlaseni.Visibility = Visibility.Visible;
                    ButtonOdhlaseni.IsEnabled = true;
                }
                else
                {
                    LabelError1.Visibility = Visibility.Hidden;
                    LabelError1.IsEnabled = false;
                    LabelError2.Visibility = Visibility.Visible;
                    LabelError2.IsEnabled = true;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string jmeno = TextJmeno.Text;
                string email = TextEmail.Text;
                string heslo = TextHeslo.Text;
                bool uzExistuje = false;

                foreach (Uzivatel U in Databaze.Uzivatele)
                {
                    if (email == U.Email || jmeno == U.Jmeno)
                    {
                        uzExistuje = true;
                    }
                    else
                    {
                        uzExistuje = false;
                    }
                }

                if (uzExistuje == false)
                {
                    Uzivatel novyUzivatel = new Uzivatel(jmeno, email, heslo);
                    Databaze.Uzivatele.Add(novyUzivatel);
                }
                else
                {
                    LabelError2.Visibility = Visibility.Hidden;
                    LabelError2.IsEnabled = false;
                    LabelError1.Visibility = Visibility.Visible;
                    LabelError1.IsEnabled = true;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
