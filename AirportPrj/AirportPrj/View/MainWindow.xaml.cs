using AirportPrj.DataBase;
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


            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AirportContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<AirportContext>()); // set it if you want to recreate database
            Context = new AirportContext();
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
    }
}
