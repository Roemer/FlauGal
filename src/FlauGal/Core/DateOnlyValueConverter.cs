using System;
using System.Globalization;
using System.Windows.Data;

namespace FlauGal.Core
{
    public class DateOnlyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var v = value as DateTime?;
            if (v == null)
            {
                return value;
            }

            return new DateTime(v.Value.Year, v.Value.Month, v.Value.Day);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
