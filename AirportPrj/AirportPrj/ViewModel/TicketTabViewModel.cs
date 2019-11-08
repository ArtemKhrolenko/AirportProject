using AirportPrj.DataBase;
using AirportPrj.Model;
using System.Data.Entity;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using AirportPrj.View.UserControls;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using AirportPrj.Helper;
using System.Linq;

namespace AirportPrj.ViewModel
{
    class TicketTabViewModel : ViewModelBase
    {

        #region Fields

        #endregion

        #region Propirties
        // cсылка на БД
        public AirportContext Context { get; }

        // свойства связаные с билетами
        public Ticket TicketInfo { get; set; } = new Ticket();
        public Ticket SelectedTicket { get; set; }
        public Passenger PassengerInfo { get; set; } = new Passenger();

        // свойства связаные с рейсом
        public Plane PlaneInfo { get; set; } = new Plane();
        public DepartureFlight SelectedflightID { get; set; }


        // свойства связаные с местом
        public DepartureFlight FlightInfo { get; set; } = new DepartureFlight();
        public DepartureFlight SelectedSeatflightID { get; set; }
        public Seat SelectedSeatID { get; set; } = new Seat();
        //public Button SelectedButton { get; set; } = new Button();
        //public string SeatIDInfo { get; set; } = "hgdfdhsgfsdf";

        #endregion

        #region Constructor
        public TicketTabViewModel()
        {

        }
        public TicketTabViewModel(AirportContext context)
        {
            Context = context;
            Context.DepartureFlight.Load(); // загружаем таблицу DepartureFlight
            Context.Tickets.Load();         // загружаем таблицу Tickets
            Context.Passengers.Load();      // загружаем таблицу Passengers
        }
        #endregion


        #region Commands
        private RelayCommand _addTicketCommand;
        private RelayCommand _updateTicketCommand;
        private RelayCommand _deleteTicketCommand;
        private RelayCommand _ticketGridSelectionChangedCommand;
        private RelayCommand _flightSelectionChangedCommand;
        private CustomRelayCommand _seatSelectionChangedCommand;

        public ICommand AddTicketCommand => _addTicketCommand ??
                    (_addTicketCommand = new RelayCommand(
                        () =>
                        {
                            Context.Tickets.Add(new Ticket()
                            {
                                TicketNumb = TicketInfo.TicketNumb,
                                //FlightID = TicketInfo.FlightID,
                                Price = TicketInfo.Price,
                            });
                            Context.SaveChanges();
                        },
                        () =>
                        {
                            if (TicketInfo.Price == 0)
                            {
                                return false;
                            }
                            return true;
                        }));

        public ICommand UpdateTicketCommand =>
            _updateTicketCommand ??
            (_updateTicketCommand = new RelayCommand(
                () =>
                {
                    SelectedTicket.TicketNumb = TicketInfo.TicketNumb;
                    //SelectedTicket.FlightID = TicketInfo.FlightID;
                    SelectedTicket.Price = TicketInfo.Price;
                    Context.SaveChanges();
                },
                () =>
                {
                    if (SelectedTicket == null) return false;
                    if (
                        //string.IsNullOrEmpty(TicketInfo.FlightID)
                        TicketInfo.Price == 0)
                    {
                        return false;
                    }
                    return true;
                }));

        public ICommand DeleteTicketCommand =>
            _deleteTicketCommand ??
            (_deleteTicketCommand = new RelayCommand(
                () =>
                {
                    Context.Tickets.Remove(SelectedTicket);
                    Context.SaveChanges();
                },
                () => SelectedTicket != null));

        public ICommand TicketGridSelectionChangedCommand
        {
            get
            {
                return _ticketGridSelectionChangedCommand ??
                    (_ticketGridSelectionChangedCommand = new RelayCommand(
                        () =>
                        {
                            TicketInfo.TicketNumb = SelectedTicket.TicketNumb;
                            //TicketInfo.FlightID = SelectedTicket.FlightID;
                            TicketInfo.Price = SelectedTicket.Price;
                        },
                        () => SelectedTicket != null));
            }
        }

        // команда выделения в ListBox по FlightId
        public ICommand FlightSelectionChangedCommand
        {
            get
            {
                return _flightSelectionChangedCommand ??
                    (_flightSelectionChangedCommand = new RelayCommand(
                        () =>
                        {
                            FlightInfo.FlightID = SelectedflightID.FlightID;

                            PlaneInfo.PlaneID = SelectedflightID.Plane.PlaneID;
                            PlaneInfo.Manufacturer = SelectedflightID.Plane.Manufacturer;
                            PlaneInfo.Model = SelectedflightID.Plane.Model;

                            PlaneInfo.TotalSeatsNumbers = SelectedflightID.Plane.TotalSeatsNumbers;                 // вначале инициализация мест, для корректного подсчета эконом
                            PlaneInfo.BusinessSeatsNumbers = SelectedflightID.Plane.BusinessSeatsNumbers;
                            PlaneInfo.FirstClassSeatsNumbers = SelectedflightID.Plane.FirstClassSeatsNumbers;
                            PlaneInfo.EconomSeatsNumbers = SelectedflightID.Plane.EconomSeatsNumbers;
                        },
                        () => SelectedflightID != null));
            }
        }

        // команда выделения Seat
        public ICommand SeatSelectionChangedCommand
        {
            get
            {
                return _seatSelectionChangedCommand ??
                    (_seatSelectionChangedCommand = new CustomRelayCommand(
                        (obj) =>
                        {
                            // значение поля Tag из объекта типа Button
                            int seatNumb = int.Parse(obj.ToString()) - 1;
                            var SeatID = SelectedflightID.Seats[seatNumb].Number;

                            // выборка из таблицы билетов по SeatID
                            var tickets = from t in Context.Tickets
                                          where t.SeatID == SeatID
                                          select t;

                            var ticket = tickets.FirstOrDefault();

                            if (ticket == null)
                            {
                                MessageBox.Show("Место не продано!!!");
                                return;
                            }

                                // выборка из таблицы пассажиров по номеру билета
                                var passengers = from p in Context.Passengers
                                                 where p.TicketNumb == ticket.TicketNumb
                                                 select p;

                                var passenger = passengers.FirstOrDefault();

                                TicketInfo.TicketNumb = passenger.Ticket.TicketNumb;
                                //TicketInfo.Seat.Number = passenger.Ticket.SeatID;
                                TicketInfo.Price = passenger.Ticket.Price;

                                PassengerInfo.Passport = passenger.Passport;
                                PassengerInfo.FirstName = passenger.FirstName;
                                PassengerInfo.LastName = passenger.LastName;

                                //MessageBox.Show(ticket.TicketNumb +" - "+ passengers.FirstOrDefault().TicketNumb);

                        },
                        (obj) => SelectedflightID != null));
            }
        }

        #endregion

    }
}
