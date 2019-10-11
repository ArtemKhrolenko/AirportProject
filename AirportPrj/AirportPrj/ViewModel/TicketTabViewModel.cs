using AirportPrj.DataBase;
using AirportPrj.Model;
using System.Data.Entity;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace AirportPrj.ViewModel
{
    class TicketTabViewModel : ViewModelBase
    {
        public AirportContext Context { get; }

        public TicketTabViewModel()
        {
        }
        public Ticket TicketInfo { get; set; } = new Ticket();
        public Ticket SelectedTicket { get; set; }
        public TicketTabViewModel(AirportContext context)
        {
            Context = context;
            Context.Passengers.Load();
        }

        #region Commands
        private RelayCommand _addTicketCommand;
        private RelayCommand _updateTicketCommand;
        private RelayCommand _deleteTicketCommand;
        private RelayCommand _ticketGridSelectionChangedCommand;

        public ICommand AddTicketCommand => _addTicketCommand ??
                    (_addTicketCommand = new RelayCommand(
                        () =>
                        {
                            Context.Tickets.Add(new Ticket()
                            {
                                TicketNumb = TicketInfo.TicketNumb,
                                FlightID = TicketInfo.FlightID,
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
                    SelectedTicket.FlightID = TicketInfo.FlightID;
                    SelectedTicket.Price = TicketInfo.Price;
                    Context.SaveChanges();
                },
                () =>
                {
                    if (SelectedTicket == null) return false;
                    if (
                         string.IsNullOrEmpty(TicketInfo.FlightID)
                        || TicketInfo.Price == 0)
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
                            TicketInfo.FlightID = SelectedTicket.FlightID;
                            TicketInfo.Price = SelectedTicket.Price;
                        },
                        () => SelectedTicket != null));
            }
        }

        #endregion
    }
}
