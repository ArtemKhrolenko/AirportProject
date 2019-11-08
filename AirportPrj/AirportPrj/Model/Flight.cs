using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AirportPrj.Model
{
    public class Flight : INotifyPropertyChanged
    {
        #region Fields
        private string _flightID;                   // номер рейса
        private DateTime? _time;                    // время
        private string _cityName;                   // назначения
        private string _airCompany;                 // перевозчик
        private string _terminal;                   // терминал
        private string _gateID;                     // gate
        private FlightStatus _flightStatus;         // статус
        private Plane _plane;                       // тип самолета
                                                    //private ObservableCollection<Seat> _seats;  // места в самолете
        #endregion

        #region Constructor
        public Flight()
        {            
        }
        public Flight(string FlightID)
        {
            this.FlightID = FlightID;
            CreateSeats();
        }
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

        [ForeignKey ("Plane")]
        public string PlaneID { get; set; }        
        // тип самолета, с типом и количеством мест в нем
        public Plane Plane
        {
            get => _plane;
            set
            {
                if (value == _plane) return;
                _plane = value;
                OnPropertyChanged();
            }
        }

        // коллекция с местами в самолете, ограничена местами по типу
        public ObservableCollection<Seat> Seats { get; set; } = new ObservableCollection<Seat>();

        #endregion

        public void CreateSeats()
        {
            for (int i = 1; i < 145; i++)
            {
                Seats.Add(new Seat() { Number = $"{FlightID}_{(i).ToString()}" });
            }
        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    #region классы ArrivalFlight и DepartureFlight, созданные для того чтобы в БД создать две разные таблицы типа Flight
    public class ArrivalFlight : Flight
    {
        public ArrivalFlight()
        {
        }

        public ArrivalFlight(string FlightId) : base(FlightId)
        {
        }
    }

    public class DepartureFlight : Flight
    {
        public DepartureFlight()
        {
        }
        public DepartureFlight(string FlightId) : base(FlightId)
        {
        }
    }
    #endregion

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
