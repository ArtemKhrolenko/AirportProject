using AirportPrj.DataBase;
using AirportPrj.Model;
using System.Data.Entity;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace AirportPrj.ViewModel
{
    class SettingsTabViewModel : ViewModelBase
    {
        public SettingsTabViewModel()
        {
        }

        #region Commands
        private RelayCommand _recreateDB;

        public ICommand RecreateDB => _recreateDB ??
                    (_recreateDB = new RelayCommand(
                        () =>
                        {                            
                            MessageBox.Show("_recreateDB");
                        },
                        () =>
                        {
                            return true;
                        }));
        #endregion
    }
}
