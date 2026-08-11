using RageAgainstThePhotos;

namespace RageAgainstThePhotos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new RATP(args));
        }
    }
}