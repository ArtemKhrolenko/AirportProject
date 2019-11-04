using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirportPrj.Model
{
    class Passenger : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _nationality;
        private string _passport;
        private DateTime? _dateOfBirth;
        private Sex _sex;
        private PassClass _passClass;
        private string _flightID;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == _firstName) return;
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Nationality
        {
            get => _nationality;
            set
            {
                if (value == _nationality) return;
                _nationality = value;
                OnPropertyChanged();
            }
        }

        public string Passport
        {
            get => _passport;
            set
            {
                if (value == _passport) return;
                _passport = value;
                OnPropertyChanged();
            }
        }
        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (value.Equals(_dateOfBirth)) return;
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }
        public Sex Sex
        {
            get => _sex;
            set
            {
                if (value == _sex) return;
                _sex = value;
                OnPropertyChanged();
            }
        }
        public PassClass PassClass
        {
            get => _passClass;
            set
            {
                if (value == _passClass) return;
                _passClass = value;
                OnPropertyChanged();
            }
        }
        
        [ForeignKey("Flight")]
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
        public Flight Flight { get; set; }


        [ForeignKey("Ticket")]
        public string TicketNumb { get; set; }
        public Ticket Ticket { get; set; }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    enum Sex
    {
        Male,
        Female
    }

    enum PassClass
    {
        Business,
        Economy
    }
}
