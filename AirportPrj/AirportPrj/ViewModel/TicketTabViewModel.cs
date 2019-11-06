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
using System;

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

        // свойства связаные с рейсом
        public Plane PlaneInfo { get; set; } = new Plane();
        public DepartureFlight SelectedflightID { get; set; }


        // свойства связаные с местом
        public DepartureFlight FlightInfo { get; set; } = new DepartureFlight();
        public DepartureFlight SelectedSeatflightID { get; set; }
        public Seat SelectedSeatID { get; set; } = new Seat();
        public Button SelectedButton { get; set; } = new Button();
        public string SeatID {get;  set;}

        #endregion

        #region Constructor
        public TicketTabViewModel()
        {

        }
        public TicketTabViewModel(AirportContext context)
        {
            Context = context;
            Context.DepartureFlight.Load();
        }
        #endregion


        #region Commands
        private RelayCommand _addTicketCommand;
        private RelayCommand _updateTicketCommand;
        private RelayCommand _deleteTicketCommand;
        private RelayCommand _ticketGridSelectionChangedCommand;
        private RelayCommand _flightSelectionChangedCommand;
        private CustomRelayCommand _seatSelectionChangedCommand;
        //private ICommand _onButtonClickCommand;
        private string seatID;

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
                            PlaneInfo.PlaneID = SelectedflightID.Plane.PlaneID;
                            PlaneInfo.Manufacturer = SelectedflightID.Plane.Manufacturer;
                            PlaneInfo.Model = SelectedflightID.Plane.Model;

                            PlaneInfo.TotalSeatsNumbers = SelectedflightID.Plane.TotalSeatsNumbers;             // вначале инициализация мест, для корректного подсчета эконом
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
                            //MessageBox.Show( ((Button)obj).Tag.ToString());
                            //MessageBox.Show(obj.GetType().ToString());
                            MessageBox.Show(obj.ToString());


                            //MessageBox.Show("tttt");
                            //MessageBox.Show(SeatID + " - " + SelectedflightID.Seats[0].Number);
                            /*SelectedSeatflightID.Seats*/
                        },
                        (obj) => SelectedSeatID != null));
            }
        }

        //ICommand _onButtonClickCommand;

        //public ICommand OnButtonClickCommand
        //{
        //    get { return _onButtonClickCommand ?? (_onButtonClickCommand = new RelayBtnCommand(ButtonClick)); }
        //}

        #endregion


        //private void ButtonClick(object button)
        //{
        //    Button clickedbutton = button as Button;

        //    if (clickedbutton != null)
        //    {
        //        // Here we can check (clickedbutton.Tag) value with static string properties of ButtonNames class..

        //        string msg = string.Format("You Pressed : {0} button", clickedbutton.Tag);
        //        MessageBox.Show(msg);
        //    }
        //}

    }

    public class CustomRelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
       
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CustomRelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
