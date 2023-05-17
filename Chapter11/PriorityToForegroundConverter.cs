using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Chapter11;

internal class PriorityToForegroundConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		if (targetType != typeof(Brush))
		{
			throw new InvalidOperationException("Celem powinien być typ Brush");
		}
		int priorytet = int.Parse(value.ToString());
		return (priorytet == 1 ? Brushes.Red : Brushes.Black);
	}

	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
}