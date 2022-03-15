using Serilog;
using Serilog.Configuration;

namespace UIAdmin
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var log = new LoggerConfiguration()
                    .ReadFrom.AppSettings()
                    .CreateLogger();
            Log.Logger = log;
            Application.Run(new FormLogin());
        }
    }
}