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
    class Plane : INotifyPropertyChanged
    {
        
        #region Fields
        private string _manufacturer;
        private string _model;
        private string _flightID;
        #endregion


        #region Properties       
        
        public int PlaneID { get; }

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

        public Flight Flight { get; set; }
        #endregion






        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
