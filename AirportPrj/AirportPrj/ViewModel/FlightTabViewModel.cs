using AirportPrj.DataBase;
using AirportPrj.Model;
using System.Data.Entity;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Controls;

namespace AirportPrj.ViewModel
{
    class FlightTabViewModel
    {
        public AirportContext Context { get; }
        public Flight FlightInfo { get; set; } = new Flight();
        public Flight SelectedFlight { get; set; }

        #region Constructors
        public FlightTabViewModel()
        {

        }

        public FlightTabViewModel(AirportContext context)
        {
            Context = context;
            Context.ArrivalFlight.Load();
            Context.DepartureFlight.Load();
        }
        #endregion

        #region Commands
        private RelayCommand _addFlightCommand;
        private RelayCommand _updateFlightCommand;
        private RelayCommand _deleteFlightCommand;
        private RelayCommand _flightGridSelectionChangedCommand;

        public ICommand AddFlightCommand => _addFlightCommand ??
                    (_addFlightCommand = new RelayCommand(
                        () =>
                        {
                            switch (SelectedFlight)
                            {
                                case ArrivalFlight _:
                                    Context.ArrivalFlight.Add(new ArrivalFlight()
                                    {
                                        FlightID = FlightInfo.FlightID,
                                        Time = FlightInfo.Time,
                                        CityName = FlightInfo.CityName,
                                        AirCompany = FlightInfo.AirCompany,
                                        Terminal = FlightInfo.Terminal,
                                        GateID = FlightInfo.GateID,
                                        FlightStatus = FlightInfo.FlightStatus
                                    }).CreateSeats();
                                    break;
                                case DepartureFlight _:
                                    Context.DepartureFlight.Add(new DepartureFlight()
                                    {
                                        FlightID = FlightInfo.FlightID,
                                        Time = FlightInfo.Time,
                                        CityName = FlightInfo.CityName,
                                        AirCompany = FlightInfo.AirCompany,
                                        Terminal = FlightInfo.Terminal,
                                        GateID = FlightInfo.GateID,
                                        FlightStatus = FlightInfo.FlightStatus
                                    }).CreateSeats();
                                    break;
                                default:
                                    break;
                            }
                            Context.SaveChanges();
                        },
                        () =>
                        {
                            if (string.IsNullOrEmpty(FlightInfo.FlightID) || SelectedFlight.FlightID == FlightInfo.FlightID)
                            {
                                return false;
                            }
                            return true;
                        }));

        public ICommand UpdateFlightCommand =>
            _updateFlightCommand ??
            (_updateFlightCommand = new RelayCommand(
                () =>
                {
                    SelectedFlight.FlightID = FlightInfo.FlightID;
                    SelectedFlight.Time = FlightInfo.Time;
                    SelectedFlight.CityName = FlightInfo.CityName;
                    SelectedFlight.AirCompany = FlightInfo.AirCompany;
                    SelectedFlight.Terminal = FlightInfo.Terminal;
                    SelectedFlight.GateID = FlightInfo.GateID;
                    SelectedFlight.FlightStatus = FlightInfo.FlightStatus;
                    Context.SaveChanges();
                },
                () =>
                {
                    if (SelectedFlight == null) return false;
                    if (string.IsNullOrEmpty(FlightInfo.FlightID)
                        || string.IsNullOrEmpty(FlightInfo.AirCompany))
                    {
                        return false;
                    }
                    return true;
                }));

        public ICommand DeleteFlightCommand =>
            _deleteFlightCommand ??
            (_deleteFlightCommand = new RelayCommand(
                () =>
                {
                    switch (SelectedFlight)
                    {
                        case ArrivalFlight _:
                            Context.ArrivalFlight.Remove((ArrivalFlight)SelectedFlight);
                            break;
                        case DepartureFlight _:
                            Context.DepartureFlight.Remove((DepartureFlight)SelectedFlight);
                            break;
                        default:
                            break;
                    }

                    Context.SaveChanges();
                },
                () => SelectedFlight != null));

        public ICommand FlightGridSelectionChangedCommand
        {
            get
            {
                return _flightGridSelectionChangedCommand ??
                    (_flightGridSelectionChangedCommand = new RelayCommand(
                        () =>
                        {
                            FlightInfo.FlightID = SelectedFlight.FlightID;
                            FlightInfo.Time = SelectedFlight.Time;
                            FlightInfo.CityName = SelectedFlight.CityName;
                            FlightInfo.AirCompany = SelectedFlight.AirCompany;
                            FlightInfo.Terminal = SelectedFlight.Terminal;
                            FlightInfo.GateID = SelectedFlight.GateID;
                            FlightInfo.FlightStatus = SelectedFlight.FlightStatus;
                        },
                        () => SelectedFlight != null));
            }
        }

        #endregion
    }
}
