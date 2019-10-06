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
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using System.Windows;

namespace AirportPrj.ViewModel
{
    class PassengerTabViewModel : ViewModelBase
    {

        public AirportContext Context { get; }
        public Passenger PassengerInfo { get; set; } = new Passenger();
        public Passenger SelectedPassenger { get; set; }

        public PassengerTabViewModel()
        {

        }

        public PassengerTabViewModel(AirportContext context)
        {
            Context = context;
            Context.Passengers.Load();
        }

        public int SelectedComboboxSex { get; set; }

        #region Commands
        private RelayCommand _addPassengerCommand;
        private RelayCommand _updatePassengerCommand;
        private RelayCommand _deletePassengerCommand;
        private RelayCommand _passengerGridSelectionChangedCommand;

        public  ICommand AddPassengerCommand => _addPassengerCommand ??
                    (_addPassengerCommand = new RelayCommand(
                        () =>
                        {
                            MessageBox.Show("add");

                            Context.Passengers.Add(new Passenger()
                            {
                                FirstName = PassengerInfo.FirstName,
                                LastName = PassengerInfo.LastName,
                                Nationality = PassengerInfo.Nationality,
                                Passport = PassengerInfo.Passport,
                                DateOfBirth = PassengerInfo.DateOfBirth,
                                Sex = PassengerInfo.Sex,
                                PassClass = PassengerInfo.PassClass,
                                FlightID = PassengerInfo.FlightID,
                            });
                            Context.SaveChanges();
                        },
                        () =>
                        {
                            if (string.IsNullOrEmpty(PassengerInfo.FirstName) || string.IsNullOrEmpty(PassengerInfo.LastName) || PassengerInfo.Passport == null)
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
                    SelectedPassenger.FirstName = PassengerInfo.FirstName;
                    SelectedPassenger.LastName = PassengerInfo.LastName;
                    SelectedPassenger.Nationality = PassengerInfo.Nationality;
                    SelectedPassenger.Passport = PassengerInfo.Passport;
                    SelectedPassenger.DateOfBirth = PassengerInfo.DateOfBirth;
                    SelectedPassenger.Sex = PassengerInfo.Sex;
                    SelectedPassenger.PassClass = PassengerInfo.PassClass;
                    SelectedPassenger.FlightID = PassengerInfo.FlightID;
                    Context.SaveChanges();
                },
                () =>
                {
                    if (SelectedPassenger == null) return false;
                    if (string.IsNullOrEmpty(PassengerInfo.FirstName)
                        || string.IsNullOrEmpty(PassengerInfo.LastName)
                        || PassengerInfo.Passport == null)
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

        public ICommand PassengerGridSelectionChangedCommand
        {
            get
            {
                return _passengerGridSelectionChangedCommand ??
                    (_passengerGridSelectionChangedCommand = new RelayCommand(
                        () =>
                        {
                            PassengerInfo.FirstName = SelectedPassenger.FirstName;
                            PassengerInfo.LastName = SelectedPassenger.LastName;
                            PassengerInfo.Nationality = SelectedPassenger.Nationality;
                            PassengerInfo.Passport = SelectedPassenger.Passport;
                            PassengerInfo.DateOfBirth = SelectedPassenger.DateOfBirth;
                            PassengerInfo.Sex = SelectedPassenger.Sex;

                            SelectedComboboxSex = (int)SelectedPassenger.Sex;

                            PassengerInfo.PassClass = SelectedPassenger.PassClass;
                            PassengerInfo.FlightID = SelectedPassenger.FlightID;
                        },
                        () => SelectedPassenger != null));
            }
        }

        #endregion

    }
}
