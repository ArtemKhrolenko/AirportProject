using AirportPrj.DataBase;
using AirportPrj.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;

namespace AirportPrj.ViewModel
{
    class PassengerTabViewModel : ViewModelBase
    {

        public PassengerTabViewModel(AirportContext context)
        {
            Context = context;
            Context.Passengers.Load();
        }

        public AirportContext Context { get; }
        public Passenger PassengertInfo { get; set; } = new Passenger();
        public Passenger SelectedPassenger { get; set; }

        #region Commands
        private RelayCommand _addPassengerCommand;
        private RelayCommand _updatePassengerCommand;
        private RelayCommand _deletePassengerCommand;
        private RelayCommand _passengerGridSelectionChangedCommand;


        public ICommand AddPassengerCommand => _addPassengerCommand ??
                    (_addPassengerCommand = new RelayCommand(
                        () =>
                        {
                            Context.Passengers.Add(new Passenger()
                            {
                                FirstName = PassengertInfo.FirstName,
                                LastName = PassengertInfo.LastName,
                                Nationality = PassengertInfo.Nationality,
                                Passport = PassengertInfo.Passport,
                                DateOfBirth = PassengertInfo.DateOfBirth,
                                Sex = PassengertInfo.Sex,
                                PassClass = PassengertInfo.PassClass,
                                FlightID = PassengertInfo.FlightID,
                            });
                            Context.SaveChanges();
                        },
                        () =>
                        {
                            if (string.IsNullOrEmpty(PassengertInfo.FirstName)
                            || string.IsNullOrEmpty(PassengertInfo.LastName)
                            || PassengertInfo.Passport == null)
                            {
                                return false;
                            }
                            return true;
                        }));

        public ICommand UpdatePassengerCommand =>
            _updatePassengerCommand ??
            (_updatePassengerCommand = new RelayCommand(
                () =>
                {
                    SelectedPassenger.FirstName = PassengertInfo.FirstName;
                    SelectedPassenger.LastName = PassengertInfo.LastName;
                    SelectedPassenger.Nationality = PassengertInfo.Nationality;
                    SelectedPassenger.Passport = PassengertInfo.Passport;
                    SelectedPassenger.DateOfBirth = PassengertInfo.DateOfBirth;
                    SelectedPassenger.Sex = PassengertInfo.Sex;
                    SelectedPassenger.PassClass = PassengertInfo.PassClass;
                    SelectedPassenger.FlightID = PassengertInfo.FlightID;
                    Context.SaveChanges();
                },
                () =>
                {
                    if (SelectedPassenger == null) return false;
                    if (string.IsNullOrEmpty(PassengertInfo.FirstName)
                        || string.IsNullOrEmpty(PassengertInfo.LastName)
                        || PassengertInfo.Passport == null)
                    {
                        return false;
                    }
                    return true;
                }));

        public ICommand DeletePassengerCommand =>
            _deletePassengerCommand ??
            (_deletePassengerCommand = new RelayCommand(
                () =>
                {
                    Context.Passengers.Remove(SelectedPassenger);
                    Context.SaveChanges();
                },
                () => SelectedPassenger != null));

        public ICommand PassengerGridSelectionChangedCommand =>
            _passengerGridSelectionChangedCommand ??
            (_passengerGridSelectionChangedCommand =
                new RelayCommand(
                    () =>
                    {
                        PassengertInfo.FirstName = SelectedPassenger.FirstName;
                        PassengertInfo.LastName = SelectedPassenger.LastName;
                        PassengertInfo.Nationality = SelectedPassenger.Nationality;
                        PassengertInfo.Passport = SelectedPassenger.Passport;
                        PassengertInfo.DateOfBirth = SelectedPassenger.DateOfBirth;
                        PassengertInfo.Sex = SelectedPassenger.Sex;
                        PassengertInfo.PassClass = SelectedPassenger.PassClass;
                        PassengertInfo.FlightID = SelectedPassenger.FlightID;
                    },
                    () => SelectedPassenger != null));

        #endregion

    }
}
