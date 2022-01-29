using HDE.AudioRecorder.Tools.AudioRecorder.Controller;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Commands
{
    internal class ToggleAudioInputDeviceCommand
    {
        public string Execute(AudioRecorderToolController controller)
        {
            if (controller.Model.Settings.AudioInputDevice == null)
            {
                return controller.Services.AudioDevicesListService.GetDefaultInputDevice();
            }
            return null;
        }
    }
}
