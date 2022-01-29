using Microsoft.UI.Xaml.Data;
using System;

namespace AudioRecorderV4.Converters
{
    public class TooltipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string language)
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();
            if (value == null)
            {
                return resourceLoader.GetString("DeviceRecordingIsDisabled");
            }

            return string.Format(
                resourceLoader.GetString("RecordingFromDeviceIsEnabled"),
                value);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
