using HDE.AudioRecorder.Tools.AudioRecorder.Controller;
using System.Diagnostics;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Commands
{
    internal class OpenSupportLinkCommand
    {
        public void Execute(AudioRecorderToolController controller)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/drweb86/conference-audio-recorder/issues",
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}
