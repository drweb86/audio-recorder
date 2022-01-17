using HDE.AudioRecorder.Controller;
using HDE.AudioRecorder.SingleToolShell;

namespace HDE.AudioRecorder
{
    internal static class Program
    {
        public readonly static AppController Controller = new AppController();

        [STAThread]
        static void Main()
        {
            using (var controller = new ShellController())
            {
                Controller.Initialize(); // Remove!
                controller.Run();
            }
        }
    }
}