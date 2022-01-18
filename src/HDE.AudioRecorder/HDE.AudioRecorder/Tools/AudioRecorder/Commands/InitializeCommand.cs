using HDE.AudioRecorder.Tools.AudioRecorder.Controller;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Commands
{
    internal class InitializeCommand
    {
        public void Execute(AudioRecorderToolController controller)
        {
            controller.Model.InputDevices = controller.Services.AudioDevicesListService.GetInputDevices();
            controller.Model.OutputDevices = controller.Services.AudioDevicesListService.GetOutputDevices();
            var defaultOutputDevice = controller.Services.AudioDevicesListService.GetDefaultOutputDevice();
            var defaultInputDevice = controller.Services.AudioDevicesListService.GetDefaultInputDevice();
            controller.Model.Settings = controller.Services.AudioRecorderSettingsService.Load();

            if (!controller.Model.InputDevices.Any(device => device == controller.Model.Settings.AudioInputDevice))
            {
                controller.Model.Settings.AudioInputDevice = defaultInputDevice;
            }

            if (!controller.Model.OutputDevices.Any(device => device == controller.Model.Settings.AudioOutputDevice))
            {
                controller.Model.Settings.AudioOutputDevice = defaultOutputDevice;
            }

            if (string.IsNullOrWhiteSpace(controller.Model.Settings.SaveRecordingToFolder))
            {
                controller.Model.Settings.SaveRecordingToFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Audio Conference Recordings");
            }

            if (!Directory.Exists(controller.Model.Settings.SaveRecordingToFolder))
            {
                Directory.CreateDirectory(controller.Model.Settings.SaveRecordingToFolder);
            }
        }
    }
}
