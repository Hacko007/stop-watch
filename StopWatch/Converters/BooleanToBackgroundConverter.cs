using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TimeRecording.Converters
{
    public class BooleanToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                var brush = Application.Current.FindResource("StandardRecoredTimeBgBrush") as LinearGradientBrush;
                if ((bool)value)
                {
                    var selectedBrash = brush.Clone();
                    selectedBrash.GradientStops[2] = new GradientStop(Colors.Red, 0.824);
                    return selectedBrash;
                }
                return brush;
            }
            return Brushes.Beige;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}