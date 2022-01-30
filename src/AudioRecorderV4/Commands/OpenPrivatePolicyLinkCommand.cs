using HDE.AudioRecorder.Tools.AudioRecorder.Controller;
using System.Diagnostics;

namespace HDE.AudioRecorder.Tools.AudioRecorder.Commands
{
    internal class OpenPrivatePolicyLinkCommand
    {
        public void Execute(AudioRecorderToolController controller)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/drweb86/conference-audio-recorder/blob/main/Privacy%20Policy.md",
                UseShellExecute = true,
                Verb = "open"
            });
        }
    }
}
