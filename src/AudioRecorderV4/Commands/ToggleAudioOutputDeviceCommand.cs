using HDE.AudioRecorder.Tools.AudioRecorder.Controller;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Commands
{
    internal class ToggleAudioOutputDeviceCommand
    {
        public string Execute(AudioRecorderToolController controller)
        {
            if (controller.Model.Settings.AudioOutputDevice == null)
            {
                return controller.Services.AudioDevicesListService.GetDefaultOutputDevice();
            }
            return null;
        }
    }
}
