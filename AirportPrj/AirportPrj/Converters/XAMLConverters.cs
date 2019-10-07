using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using AirportPrj.Model;

namespace AirportPrj.Converters
{
    public class EnumConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value;
        }

        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (FlightStatus)value;
        }
    }

    public class DistinctConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            var values = value as IEnumerable;
            return values?.Cast<object>().Distinct();
        }

        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
