using System.Globalization;

namespace Maui2Blazor.Maui.Converters
{
    public interface IMultiValueConverter
	{
        object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);
        object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);
    }
}

