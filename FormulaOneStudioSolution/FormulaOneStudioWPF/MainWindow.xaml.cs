using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// DLL
using FormulaOneDLL;

namespace FormulaOneStudioWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbTools db = new DbTools();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            db = new DbTools();
            //List<CardDriverDLL> driver = new List<CardDriverDLL>();
            //driver = db.LoadDrivers();

            //List<testClass> driver = new List<testClass>();
            //driver = db.LoadDrivers(cmbYear.SelectionBoxItem.ToString());

            //dgvDriver.ItemsSource = db.LoadDrivers(cmbYear.SelectionBoxItem.ToString());

            //for (int i = 0; i < driver.Count; i++)
            //{
            //    MyUserControls.CardDriver card = new MyUserControls.CardDriver();
            //    if (driver[i].PathImage == "")
            //        card.CardImage = new BitmapImage(new Uri("https://www.shareicon.net/data/512x512/2016/04/10/747353_people_512x512.png"));
            //    else
            //        card.CardImage = new BitmapImage(new Uri(driver[i].PathImage));
            //    card.DriverName = driver[i].Surname;
            //    card.DriverTeam = driver[i].Name;
            //    cardTest.Children.Add(card);
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyUserControls.CardTeam cardTeamMercedes = new MyUserControls.CardTeam();
            cardTeamMercedes.CardImage = new BitmapImage(
                new Uri("https://www.formula1.com/content/dam/fom-website/teams/2020/mercedes.png.transform/4col/image.png"));
            cardTeamMercedes.TeamName = "Mercedes";
            cardTeamMercedes.Driver1 = "Lewis Hamilton";
            cardTeamMercedes.Driver2 = "Valtteri Bottas";
            cardTeam.Children.Add(cardTeamMercedes);

            MyUserControls.CardTeam cardTeamFerrari = new MyUserControls.CardTeam();
            cardTeamFerrari.CardImage = new BitmapImage(
                new Uri("https://www.formula1.com/content/dam/fom-website/teams/2020/ferrari.png.transform/4col/image.png"));
            cardTeamFerrari.TeamName = "Ferrari";
            cardTeamFerrari.Driver1 = "Sebastian Vettel";
            cardTeamFerrari.Driver2 = "Charles Leclerc";
            cardTeam.Children.Add(cardTeamFerrari);
        }

        private void cmbYear_DropDownClosed(object sender, EventArgs e)
        {
            cardTest.Children.Clear();
            dgvDriver.ItemsSource = db.LoadDrivers(cmbYear.SelectionBoxItem.ToString());
            //List<testClass> driver = new List<testClass>();
            //driver = db.LoadDrivers(cmbYear.SelectionBoxItem.ToString());
            //for (int i = 0; i < driver.Count; i++)
            //{
            //    MyUserControls.CardDriver card = new MyUserControls.CardDriver();
            //    if (driver[i].PathImage == "")
            //        card.CardImage = new BitmapImage(new Uri("https://www.shareicon.net/data/512x512/2016/04/10/747353_people_512x512.png"));
            //    else
            //        card.CardImage = new BitmapImage(new Uri(driver[i].PathImage));
            //    card.DriverName = driver[i].Surname;
            //    card.DriverTeam = driver[i].Name;
            //    cardTest.Children.Add(card);
            //}
        }
    }
}
