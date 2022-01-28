using HDE.AudioRecorder.Tools.AudioRecorder.Controller;
using System.Diagnostics;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Commands
{
    internal class OpenLogsFolderCommand
    {
        public void Execute(AudioRecorderToolController controller)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = controller.Model.LogsFolder,
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}
