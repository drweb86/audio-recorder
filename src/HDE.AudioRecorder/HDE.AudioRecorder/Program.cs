using HDE.AudioRecorder.SingleToolShell;

namespace HDE.AudioRecorder
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var controller = new ShellController())
            {
                controller.Run();
            }
        }
    }
}