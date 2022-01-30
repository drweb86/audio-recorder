using HDE.AudioRecorder.Tools.AudioRecorder.Controller;
using System;
using System.IO;
using System.Linq;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Commands
{
    internal class InitializeCommand
    {
        public void Execute(AudioRecorderToolController controller)
        {
            controller.Services.Log.Debug($"Required 64-bit Vista+ or Server with Desktop Experience. OS Information: {Environment.OSVersion.VersionString}, Is 64-bit {Environment.Is64BitOperatingSystem}");
            controller.Model.LogsFolder = Path.GetDirectoryName(controller.Services.Log.LogFile);
            controller.Model.InputDevices = controller.Services.AudioDevicesListService.GetInputDevices();
            controller.Model.OutputDevices = controller.Services.AudioDevicesListService.GetOutputDevices();
            var defaultOutputDevice = controller.Services.AudioDevicesListService.GetDefaultOutputDevice();
            var defaultInputDevice = controller.Services.AudioDevicesListService.GetDefaultInputDevice();
            controller.Model.Settings = controller.Services.AudioRecorderSettingsService.Load();
            if (controller.Model.Settings.SaveRecordingToFolder == null) // Default settings
            {
                controller.Model.Settings.AudioInputDevice = defaultInputDevice;
                controller.Model.Settings.AudioOutputDevice = defaultOutputDevice;
            }
            if (controller.Model.Settings.AudioInputDevice != null &&
                !controller.Model.InputDevices.Any(device => device == controller.Model.Settings.AudioInputDevice))
            {
                controller.Model.Settings.AudioInputDevice = defaultInputDevice;
            }

            if (controller.Model.Settings.AudioOutputDevice != null &&
                !controller.Model.OutputDevices.Any(device => device == controller.Model.Settings.AudioOutputDevice))
            {
                controller.Model.Settings.AudioOutputDevice = defaultOutputDevice;
            }

            if (string.IsNullOrWhiteSpace(controller.Model.Settings.SaveRecordingToFolder))
            {
                var resource = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();
                var localizedFolder = resource.GetString("ConferenceRecordingsFolder");

                controller.Model.Settings.SaveRecordingToFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), localizedFolder);
            }

            if (!Directory.Exists(controller.Model.Settings.SaveRecordingToFolder))
            {
                Directory.CreateDirectory(controller.Model.Settings.SaveRecordingToFolder);
            }
        }
    }
}
