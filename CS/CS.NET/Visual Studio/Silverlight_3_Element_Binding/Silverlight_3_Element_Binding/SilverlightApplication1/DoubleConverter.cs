using System;
using System.Windows.Data;

namespace SilverlightApplication1
{
    public class DoubleConverter : IValueConverter
    {       
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Math.Round(double.Parse(value.ToString()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
