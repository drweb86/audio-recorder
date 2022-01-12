using HDE.AudioRecorder.Controller;

namespace HDE.AudioRecorder
{
    internal static class Program
    {
        public readonly static AppController Controller = new AppController();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Controller.Initialize();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}