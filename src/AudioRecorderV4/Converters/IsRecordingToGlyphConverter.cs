using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace AudioRecorderV4.Converters
{
    public class IsRecordingToGlyphConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }

            return ((bool)value) ?
                "\uE73B" :
                "\uE7C8";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
