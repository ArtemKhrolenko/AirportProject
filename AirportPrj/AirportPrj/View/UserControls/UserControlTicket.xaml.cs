using AirportPrj.DataBase;
using AirportPrj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirportPrj.View.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlTicket.xaml
    /// </summary>
    public partial class UserControlTicket : UserControl
    {
        private AirportContext Context { get; }

        public UserControlBoing userControlBoing;
        public UserControlAirbus userControlAirbus;

        public UserControlTicket()
        {
            InitializeComponent();

            // загружаем ресурсы пользовательских элементов
            userControlBoing = new UserControlBoing();
            userControlAirbus = new UserControlAirbus();

            ContentGrid.Children.Clear();
            ContentGrid.Children.Add(userControlBoing);
        }

        private void DataGridFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            ContentGrid.Children.Clear();

            if (listBox.SelectedIndex < 0) return;

            switch (((DepartureFlight)listBox.SelectedItem).Plane.Manufacturer)
            {
                case "Boeing":
                    ContentGrid.Children.Add(userControlBoing);
                    break;
                case "AirBus":
                    ContentGrid.Children.Add(userControlAirbus);
                    break;
                default:
                    break;
            }

        }

        private void LisBoxFlight_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            if (listBox != null && listBox.HasItems) listBox.SelectedIndex = 1;

            //MessageBox.Show(listBox.SelectedIndex.ToString());
            //ListBox lb = sender as ListBox;
            //if (lb != null && lb.HasItems) lb.SelectedIndex = 0;
        }
    }
}
