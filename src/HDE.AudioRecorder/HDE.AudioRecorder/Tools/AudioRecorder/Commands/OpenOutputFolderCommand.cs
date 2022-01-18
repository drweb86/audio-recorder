using HDE.AudioRecorder.Tools.AudioRecorder.Controller;
using System.Diagnostics;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Commands
{
    internal class OpenOutputFolderCommand
    {
        public void Execute(AudioRecorderToolController controller)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = controller.Model.Settings.SaveRecordingToFolder,
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}
