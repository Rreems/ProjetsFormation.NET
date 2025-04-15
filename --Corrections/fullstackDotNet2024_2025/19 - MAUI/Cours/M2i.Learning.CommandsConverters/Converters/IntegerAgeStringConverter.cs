using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2i.Learning.CommandsConverters.Converters
{
    class IntegerAgeStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var valueAsInt = (int) (value ?? 0);
            return $"{valueAsInt} yo";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var valueAsString = (string?) value ?? "0";
            return System.Convert.ToInt32(valueAsString.Split(" ")[0]);
        }
    }
}
