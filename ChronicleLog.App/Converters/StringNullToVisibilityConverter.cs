using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ChronicleLog.App.Converters
{
	internal class StringNullToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ( value == null || string.IsNullOrWhiteSpace(value.ToString()) ) ?
				Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}
