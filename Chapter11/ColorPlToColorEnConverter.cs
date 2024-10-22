﻿using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Media;

namespace Chapter11;

internal class ColorPlToColorEnConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		if (targetType != typeof(Brush))
		{
			throw new InvalidOperationException("Celem powinien być typ Brush");
		}

		// Kolor w języku polskim jako string
		string colorPL = value.ToString();

		Dictionary<string, Brush> colors = new()
		{
			{ "Czarny", Brushes.Black },
			{ "Czerwony", Brushes.Red },
			{ "Żółty", Brushes.Yellow },
			{ "Zielony", Brushes.Green },
			{ "Niebieski", Brushes.Blue }
		};

		return colors.TryGetValue(colorPL, out Brush brush) ? brush : (object)Brushes.LightGray;
	}

	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		=> throw new NotImplementedException();
}