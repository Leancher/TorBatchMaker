using System.Diagnostics;

namespace TorBatchMaker
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
        string singleDir = "";
        bool isSingleDir = false;
        string tracker1 = "";
        string tracker2 = "";
        bool isOnlyNewTor = false;
        string torNameApp = Directory.GetCurrentDirectory() + "\\transmission\\transmission_create.exe";

        // Объявляем событие
        public delegate void TorMakerHandler(TorMaker sender, string text);
        public event TorMakerHandler? SendCommand;

        public void makeTorrents()
        {
            if (isSingleDir)
            {
                rootDir = new DirectoryInfo(singleDir).Parent.ToString();
                singleDir = new DirectoryInfo(singleDir).Name.ToString();
                Debug.WriteLine("rootDir: " + rootDir);
                Debug.WriteLine("singleDir: " + singleDir);

                torAppRun(singleDir);
            }
            else
            {
                getDirList();
                foreach (string dir in dirList) 
                { 
                    torAppRun(dir);
                }
            }
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
        void torAppRun(string dir)
        {
            //string arguments = "create \"" + rootDir + "\\" + dir + "\" -o \"" + rootDir + "\\" + dir + "\" -a \"" + tracker1 + "\" \"" + tracker2 + "\"";
            //string command = "torrenttools create \"" + rootDir + "\\" + dirList[0] + "\" -o \"" + rootDir + "\\" + dirList[0] + "\" -a \"" + tracker1 + "\" \"" + tracker2 +  "\"";
            string arguments = "-o \"" + rootDir + "\\" + dir + "\\" + dir + ".torrent\" -t \"" + tracker1 + "\" -t \"" + tracker2 + "\" \"" + rootDir + "\\" + dir + "\""; 
            Debug.WriteLine("dir: " + dir);
            Debug.WriteLine("arguments: " + arguments);
            Debug.WriteLine("checkExistTorFile: " + checkExistTorFile(dir).ToString());
            
            // Вызываем событие, когда нужно обновить данные
            SendCommand?.Invoke(this, arguments);

            ProcessStartInfo startInfo = new ProcessStartInfo(torNameApp)
            {
                Arguments = arguments,
                UseShellExecute = false,
            };
            
            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
            }
        }
        bool checkExistTorFile(string path)
        {
            var directory = new DirectoryInfo(rootDir + "\\" + path);
            FileInfo[] files = directory.GetFiles("*.torrent");
            if (files.Length == 0)
            {
                return false;
            }
            return true;
        }
        public TorMaker() { }
        public TorMaker(TorProps torProps)
        {
            this.rootDir = torProps.rootDir;
            this.singleDir = torProps.singleDir;
            this.isSingleDir = torProps.isSingleDir;
            this.tracker1 = torProps.tracker1;
            this.tracker2 = torProps.tracker2;
            this.isOnlyNewTor = torProps.isOnlyNewTor;       
        }
    }
}