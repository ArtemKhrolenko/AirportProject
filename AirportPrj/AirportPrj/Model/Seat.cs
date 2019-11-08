using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace AirportPrj.Model
{
    public class Seat : INotifyPropertyChanged
    {
        #region Fields
        private string _number;               // номер места
        private SeatClass _seatType;         // тип места
        private Passenger _passenger;         // сылка на пассажира
        private Flight _flight;
        #endregion

        #region Properties
        [Key]
        public string Number
        {
            get => _number;
            set
            {
                if (value == _number) return;
                _number = value;
                OnPropertyChanged();
            }
        }

        public SeatClass SeatType
        {
            get => _seatType;
            set
            {
                if (value == _seatType) return;
                _seatType = value;
                OnPropertyChanged();
            }
        }

        public Passenger Passenger
        {
            get => _passenger;
            set
            {
                if (value == _passenger) return;
                _passenger = value;
                OnPropertyChanged();
            }
        }

        public Flight Flight
        {
            get => _flight;
            set
            {
                if (value == _flight) return;
                _flight = value;
                OnPropertyChanged();
            }
        }

        //[ForeignKey("Ticket")]
        //public string TicketNumb { get; set; }

        //public Ticket Ticket { get; set; }

        #endregion

        #region Event
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        
        // тип места
        public enum SeatClass
        {
            BusinessClass,         // бизнесс класс
            FirstClass,            // первый класс
            EconomClass            // эконом класс
        }
    }
}
