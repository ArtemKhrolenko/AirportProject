using AirportPrj.DataBase;
using AirportPrj.Model;
using AirportPrj.ViewModel;
using AirportPrj.View.UserControls;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AirportPrj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AirportContext Context { get; }

        public UserControlHome userControlHome;
        public UserControlPassenger userControlPassenger;
        public UserControlFlight userControlFlight;
        public UserControlSettings userControlSettings;

        public MainWindow()
        {
            InitializeComponent();

            // загружаем ресурсы пользовательских элементов
            userControlHome = new UserControlHome();
            userControlPassenger = new UserControlPassenger();
            userControlFlight = new UserControlFlight();
            userControlSettings = new UserControlSettings();


            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AirportContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<AirportContext>()); // set it if you want to recreate database
            Context = new AirportContext();
            Fill();
            userControlPassenger.PassengersGrid.DataContext = new PassengerTabViewModel(Context);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            ContentGrid.Children.Clear();

            switch (clickedButton.Content.ToString())
            {
                case "Home":
                    ContentGrid.Children.Add(userControlHome);
                    break;
                case "Passenger":
                    ContentGrid.Children.Add(userControlPassenger);
                    break;
                case "Flight":
                    ContentGrid.Children.Add(userControlFlight);
                    break;
                case "Settings":
                    ContentGrid.Children.Add(userControlSettings);
                    break;
                default:
                    break;
            }

        }

        private void Fill()
        {
            var passengers = new[]
            {
                new Passenger {FirstName = "Mohammed", LastName = "Woodham", Nationality = "Afghan", Passport = "CH 123456", DateOfBirth = new DateTime(1995, 9, 2), Sex = Sex.Male, PassClass = PassClass.Business, FlightID = ""},
                new Passenger {FirstName = "Porter", LastName = "Hilger", Nationality = "Belgian", Passport = "QW 132447", DateOfBirth = new DateTime(1996, 9, 2), Sex = Sex.Male, PassClass = PassClass.Economy, FlightID = ""},
                new Passenger {FirstName = "Chad", LastName = "Heyer", Nationality = "Brazilian", Passport = "DF 345678", DateOfBirth = new DateTime(1997, 9, 2), Sex = Sex.Male, PassClass = PassClass.Business, FlightID = ""},
                new Passenger {FirstName = "Fidel", LastName = "Dorsey", Nationality = "Chinese", Passport = "JK 135286", DateOfBirth = new DateTime(1998, 9, 2), Sex = Sex.Male, PassClass = PassClass.Economy, FlightID = ""},
                new Passenger {FirstName = "Faustino", LastName = "Sweatt", Nationality = "Cuban", Passport = "PQ 102938", DateOfBirth = new DateTime(1999, 9, 2), Sex = Sex.Male, PassClass = PassClass.Business, FlightID = ""},

                new Passenger {FirstName = "Alexandra", LastName = "Barrientez", Nationality = "Ethiopian", Passport = "AS 416587", DateOfBirth = new DateTime(1985, 9, 2), Sex = Sex.Female, PassClass = PassClass.Economy, FlightID = ""},
                new Passenger {FirstName = "Bari", LastName = "Lazar", Nationality = "Iranian", Passport = "DG 764556", DateOfBirth = new DateTime(2000, 9, 2), Sex = Sex.Female, PassClass = PassClass.Business, FlightID = ""},
                new Passenger {FirstName = "Awilda", LastName = "Marson", Nationality = "Nambian", Passport = "JH 653076", DateOfBirth = new DateTime(2001, 9, 2), Sex = Sex.Female, PassClass = PassClass.Economy, FlightID = ""},
                new Passenger {FirstName = "Patrica", LastName = "Blackledge", Nationality = "Serbian", Passport = "MN 852700", DateOfBirth = new DateTime(2002, 9, 2), Sex = Sex.Female, PassClass = PassClass.Business, FlightID = ""},
                new Passenger {FirstName = "Ellie", LastName = "Baumer", Nationality = "Ukranian", Passport = "CX 336629", DateOfBirth = new DateTime(1999, 9, 2), Sex = Sex.Female, PassClass = PassClass.Economy, FlightID = ""}
            };

            Context.Passengers.AddRange(passengers);
            Context.SaveChanges();
        }
    }
}
