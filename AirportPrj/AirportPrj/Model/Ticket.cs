using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace AirportPrj.Model
{
    public class Ticket : INotifyPropertyChanged
    {
        #region Fields
        private string _ticketNumb;                 // номер билета

        private decimal _price;                     // цена
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

       
        //public Passenger Passenger { get; set; }   // пассажир
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
