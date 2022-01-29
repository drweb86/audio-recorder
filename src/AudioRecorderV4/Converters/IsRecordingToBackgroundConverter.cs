using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using Windows.UI;

namespace AudioRecorderV4.Converters
{
    public class IsRecordingToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }

            var color = ((bool)value) ? Color.FromArgb(255, 49, 137, 196) : Color.FromArgb(255, 233, 66, 55);

            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
