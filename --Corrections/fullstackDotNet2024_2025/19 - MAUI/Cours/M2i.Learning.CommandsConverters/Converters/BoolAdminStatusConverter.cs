using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2i.Learning.CommandsConverters.Converters
{
    class BoolAdminStatusConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            //var valueAsBool = value as bool;
            var valueAsBool = (bool) value;
            return valueAsBool ? "ADMIN" : "USER";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var valueAsString = value as string;
            if (valueAsString == null && string.IsNullOrEmpty(valueAsString)) return false;
            return valueAsString.Equals("ADMIN");
        }
    }
}
