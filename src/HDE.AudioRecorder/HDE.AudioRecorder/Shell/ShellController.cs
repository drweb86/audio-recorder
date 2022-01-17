using HDE.Platform.AspectOrientedFramework.WinForms;
using HDE.Platform.Logging;

namespace HDE.AudioRecorder.SingleToolShell
{
    class ShellController : ShellBaseController<ShellModel, ShellMainForm>
    {
        protected override ILog CreateOpenLog()
        {
            var log = new HtmlLog(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HDE",
                "AudioRecorder",
                "1.0"));

            log.Open();

            return log;
        }
    }
}
