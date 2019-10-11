using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace AirportPrj.Model
{
    class Ticket : INotifyPropertyChanged
    {
        #region Fields
        private string _flightID;               // номер рейса
        private string _ticketNumb;               // номер билета

        //[ForeignKey("FlightID")]
        //private Passenger Passenger { get; set; }   // пассажир

        private decimal _price;                 // цена
        #endregion

        #region Properties

        public string TicketNumb
        {
            get => _ticketNumb;
            set
            {
                if (value == _ticketNumb) return;
                _ticketNumb = value;
                OnPropertyChanged();
            }
        }
        //[ForeignKey("Passenger")]
        public string FlightID
        {
            get => _flightID;
            set
            {
                if (value == _flightID) return;
                _flightID = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value == _price) return;
                _price = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
