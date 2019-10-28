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

        //public UserControlHome userControlHome;
        public UserControlPassenger userControlPassenger;
        public UserControlFlight userControlFlight;
        public UserControlTicket userControlTicket;

        public MainWindow()
        {
            InitializeComponent();

            // загружаем ресурсы пользовательских элементов
            //userControlHome = new UserControlHome();
            userControlPassenger = new UserControlPassenger();
            userControlFlight = new UserControlFlight();
            userControlTicket = new UserControlTicket();

            Context = new AirportContext();
            InitDB.IsRebuid = true; // set it if you want to recreate database
            if (InitDB.IsRebuid)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<AirportContext>());
                InitDB.Fill(Context);
            }
            else
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AirportContext>());
            }

            userControlPassenger.PassengersGrid.DataContext = new PassengerTabViewModel(Context);
            userControlFlight.ArrivalFlightsGrid.DataContext = new FlightTabViewModel(Context);
            userControlFlight.DepartureFlightsGrid.DataContext = new FlightTabViewModel(Context);
            userControlTicket.TicketsGrid.DataContext = new TicketTabViewModel(Context);

            ContentGrid.Children.Add(userControlFlight);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            ContentGrid.Children.Clear();

            switch (clickedButton.Content.ToString())
            {
                case "Home":
                    //ContentGrid.Children.Add(userControlHome);
                    break;
                case "Passenger":
                    ContentGrid.Children.Add(userControlPassenger);
                    break;
                case "Flight":
                    ContentGrid.Children.Add(userControlFlight);
                    break;
                case "Ticket":
                    ContentGrid.Children.Add(userControlTicket);
                    break;
                default:
                    break;
            }

        }

    }
}
