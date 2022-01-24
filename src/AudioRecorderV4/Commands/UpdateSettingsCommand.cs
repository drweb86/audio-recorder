using HDE.AudioRecorder.Tools.AudioRecorder.Controller;
using HDE.AudioRecorder.Tools.AudioRecorder.Model;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Commands
{
    internal class UpdateSettingsCommand
    {
        public void Execute(AudioRecorderToolController controller, AudioRecorderSettings update)
        {
            if (update.AudioInputDevice != null)
            {
                controller.Model.Settings.AudioInputDevice = update.AudioInputDevice;
            }

            if (update.AudioOutputDevice != null)
            {
                controller.Model.Settings.AudioOutputDevice = update.AudioOutputDevice;
            }

            if (update.SaveRecordingToFolder != null)
            {
                controller.Model.Settings.SaveRecordingToFolder = update.SaveRecordingToFolder;
            }

            controller.Services.AudioRecorderSettingsService.Save(controller.Model.Settings);
        }
    }
}
