using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AirportPrj.Model
{
    public class Plane : INotifyPropertyChanged
    {
        
        #region Fields
        private string _manufacturer;           // производитель
        private string _model;                  // модель воздушного судна
        private string _flightID;               // связующие звено
        private int _businessSeatsNumbers;      // количество мест бизнесс класса
        private int _firstClassSeatsNumbers;    // количество мест первого класса
        //private int _economSeatsNumbers;        // количество мест эконом класса
        #endregion


        #region Properties
        public string PlaneID { get; set; }
        public int TotalSeatsNumbers { get; set; }

        public string Manufacturer
        {
            get => _manufacturer;
            set
            {
                if (value == _manufacturer) return;
                _manufacturer = value;
                OnPropertyChanged();
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                if (value == _model) return;
                _model = value;
                OnPropertyChanged();
            }
        }
        
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

        public int BusinessSeatsNumbers
        {
            get => _businessSeatsNumbers;
            set
            {
                if (value == _businessSeatsNumbers) return;
                _businessSeatsNumbers = value;
                OnPropertyChanged();
            }
        }

        public int FirstClassSeatsNumbers
        {
            get => _firstClassSeatsNumbers;
            set
            {
                if (value == _firstClassSeatsNumbers) return;
                _firstClassSeatsNumbers = value;
                OnPropertyChanged();
            }
        }

        public int EconomSeatsNumbers
        {
            get
            {
                return TotalSeatsNumbers - (EconomSeatsNumbers + FirstClassSeatsNumbers);
            }
        }

        #endregion


        #region Event
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
