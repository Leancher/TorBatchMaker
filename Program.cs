
using System.Diagnostics;

namespace TorMakerBatch
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
            Application.Run(new Form1());
        }
    }
    internal class TorMaker
    {
        string[] dirList;
        string rootDir = "";
        string tracker1 = "";
        string tracker2 = "";
        string command = "";
        public void makeTorrents()
        {
            getDirList();
            createCommand();
        }
        void getDirList()
        {
            Debug.WriteLine("Dir list: ");
            dirList = Directory.GetDirectories(rootDir).Select(Path.GetFileName).ToArray(); ;
            foreach (string dir in dirList)
            {
                Debug.WriteLine(dir);
            }
        }
        void createCommand()
        {
            command = "torrenttools create \"" + rootDir + "\\" + dirList[0] + "\" -o \"" + rootDir + "\\" + dirList[0] + "\" -a \"" + tracker1 + "\" \"" + tracker2 + 
                "\"";
            Debug.WriteLine("Command: " + command);
        }
        void torrenttoolsRun()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe")
            {
                Arguments = "/c dir",
                UseShellExecute = false
            };

            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
            }
        }
        public TorMaker() { }
        public TorMaker(string rootDir, string tracker1, string tracker2)
        {
            this.rootDir = rootDir;
            this.tracker1 = tracker1;
            this.tracker2 = tracker2;
        }
    }
}