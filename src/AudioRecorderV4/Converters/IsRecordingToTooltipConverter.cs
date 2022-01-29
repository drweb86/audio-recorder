using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace AudioRecorderV4.Converters
{
    public class IsRecordingToTooltipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }

            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();

            return ((bool)value) ?
                resourceLoader.GetString("Stop") :
                resourceLoader.GetString("StartRecording");
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
