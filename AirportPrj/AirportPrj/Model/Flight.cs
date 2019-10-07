using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportPrj.Model
{
    class Flight : INotifyPropertyChanged
    {
        #region Fields
        private string _flightID;               // номер рейса
        private DateTime? _time;                // время
        private string _cityName;               // назначения
        private string _airCompany;             // перевозчик
        private string _terminal;                 // терминал
        private string _gateID;                 // gate
        private FlightStatus _flightStatus;     // статус
        #endregion

        #region Properties

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

        public DateTime? Time
        {
            get => _time;
            set
            {
                if (value.Equals(_time)) return;
                _time = value;
                OnPropertyChanged();
            }
        }

        public string CityName
        {
            get => _cityName;
            set
            {
                if (value == _cityName) return;
                _cityName = value;
                OnPropertyChanged();
            }
        }

        public string AirCompany
        {
            get => _airCompany;
            set
            {
                if (value == _airCompany) return;
                _airCompany = value;
                OnPropertyChanged();
            }
        }

        public string Terminal
        {
            get => _terminal;
            set
            {
                if (value == _terminal) return;
                _terminal = value;
                OnPropertyChanged();
            }
        }

        public string GateID
        {
            get => _gateID;
            set
            {
                if (value == _gateID) return;
                _gateID = value;
                OnPropertyChanged();
            }
        }

        public FlightStatus FlightStatus
        {
            get => _flightStatus;
            set
            {
                if (value == _flightStatus) return;
                _flightStatus = value;
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

    // Статус рейса
    public enum FlightStatus
    {
        ChekIn,         // регистрация
        GateClosed,     // гейт закрыт
        Arrived,        // прибыл
        DepartedAt,     // отправляется в ...
        Unknown,        // неизвестен
        Canceled,       // отменен
        ExpectedAt,     // ожидается в ...
        Delayed,        // задерживается
        InFlight        // в полёте
    }
}
