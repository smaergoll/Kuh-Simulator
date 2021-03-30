using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kuh_Simulator_2._0
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Kuh[] kuehe = new Kuh[3];
        Kuh kuh1 = new Kuh("Lisa", 700, 1);
        Kuh kuh2 = new Kuh("Karl", 1000, 2);
        Kuh kuh3 = new Kuh("Riko", 1100, 1);
        private static GPSLocation Stuttgart;
        private static Weide Weide1;
        private static Stall Stall1;
        private static int currentKuh = 0;

        private static Timer aTimer;
        
        
        public MainWindow()
        {
            InitializeComponent();
            kuehe[0] = kuh1;
            kuehe[1] = kuh2;
            kuehe[2] = kuh3;
            initBauernHof();
            SetTimer();
        }

        private void SetTimer()
        {
            aTimer = new Timer(15000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            alterErhoehenTimer();
            Application.Current.Dispatcher.Invoke(() =>
            {
                setEigenschaftenKuh(currentKuh);
            },
            System.Windows.Threading.DispatcherPriority.Normal);
            
        }

        private void initBauernHof()
        {
            Stuttgart = new GPSLocation(9.1800132, 48.7784485, 245);
            Weide1 = new Weide(Stuttgart, 1000);
            Stall1 = new Stall(500);
            foreach(Kuh k in kuehe)
            {
                Stall1.KuhHinzufuegen(k);
            }
        }

        private void alterErhoehenTimer()
        {
            foreach(Kuh k in kuehe)
            {
                k.setAlter(k.getAlter() + 1);
            }
            
        }

        private void setEigenschaftenKuh(int currentKuh)
        {
            lblName.Content = "Name: " + kuehe[currentKuh].getName();
            lblAlter.Content = "Alter: " + kuehe[currentKuh].getAlter();
            lblEuterInhalt.Content = "Euterinhalt: " + kuehe[currentKuh].getEuterInhalt();
            lblGewicht.Content = "Gewicht: " + kuehe[currentKuh].getGewicht();
            lblMilchMenge.Content = kuehe[currentKuh].getEuterInhalt();
            lblGesMilchMenge.Content = kuehe[currentKuh].getAbgegebeneMilchMenge();
            _ = Stall1.getMeineKuehe().Contains(kuehe[currentKuh]) ? lblLocation.Content = "Location: Stall" : lblLocation.Content = "Location: Weide";
        }

        private void Button_Kuh0(object sender, RoutedEventArgs e)
        {
            currentKuh = 0;
            setEigenschaftenKuh(currentKuh);
            
        }

        private void Button_Kuh1(object sender, RoutedEventArgs e)
        {
            currentKuh = 1;
            setEigenschaftenKuh(currentKuh);
        }

        private void Button_Kuh2(object sender, RoutedEventArgs e)
        {
            currentKuh = 2;
            setEigenschaftenKuh(currentKuh);
        }

        private void Button_Füttern(object sender, RoutedEventArgs e)
        {
            string heuMengeText = txtHeuMenge.Text;
            double heuMenge = Convert.ToDouble(heuMengeText);
            Kuh kuh = kuehe[currentKuh];
            kuh.fressen(heuMenge);
            setEigenschaftenKuh(currentKuh);
        }

        private void Button_Melken(object sender, RoutedEventArgs e)
        {
            Kuh kuh = kuehe[currentKuh];
            kuh.melken();
            setEigenschaftenKuh(currentKuh);
        }

        private void Button_Location(object sender, RoutedEventArgs e)
        {
            Kuh kuh = kuehe[currentKuh];
            if(Stall1.getMeineKuehe().Contains(kuh))
            {
                Stall1.KuhRausLassen(Weide1, kuh.getName());
            }else
            {
                Stall1.KuhVonWeideHolen(Weide1, kuh.getName());
            }
            setEigenschaftenKuh(currentKuh);
        }
    }
}
