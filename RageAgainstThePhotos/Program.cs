using RageAgainstThePhotos;
using System.IO.Pipes;
using System.Text;

namespace RageAgainstThePhotos
{
    internal static class Program
    {
        private const string MutexName = "RageAgainstThePhotos_SingleInstance";
        private const string PipeName = "RageAgainstThePhotos_FilePipe";

        [STAThread]
        static void Main(string[] args)
        {
            using Mutex mutex = new Mutex(true, MutexName, out bool isFirstInstance);

            if (!isFirstInstance)
            {
                SendFilesToMainInstance(args);
                return;
            }

            ApplicationConfiguration.Initialize();

            Application.Run(new RATP(args));
        }

        private static void SendFilesToMainInstance(string[] args)
        {
            if (args.Length == 0)
                return;

            try
            {
                using NamedPipeClientStream client = new NamedPipeClientStream(
                    ".",
                    PipeName,
                    PipeDirection.Out
                );

                client.Connect(2000);

                using StreamWriter writer = new StreamWriter(client, Encoding.UTF8);

                foreach (string file in args)
                {
                    writer.WriteLine(file);
                }

                writer.Flush();
            }
            catch
            {
            }
        }
    }
}