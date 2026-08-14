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
        string[] trackers;
        bool isOnlyNewTor = false;
        string torClientAppPath = "";
        // Объявляем событие
        EventProps eventProps;
        public delegate void TorMakerHandler(TorMaker sender, EventProps eventProps);
        public event TorMakerHandler? NewEvent;

        public void makeTorrents()
        {
            if (isSingleDir)
            {
                rootDir = new DirectoryInfo(singleDir).Parent.ToString();
                singleDir = new DirectoryInfo(singleDir).Name.ToString();
                torMakerAppRun(singleDir);
            }
            else
            {
                getDirList();
                foreach (string dir in dirList) 
                { 
                    torMakerAppRun(dir);
                }
            }
        }
        public void seedTorrents()
        {
            torClientAppPath = torClientAppPath + "\\uTorrent.exe";
            if (isSingleDir)
            {
                rootDir = new DirectoryInfo(singleDir).Parent.ToString();
                singleDir = new DirectoryInfo(singleDir).Name.ToString();
                torClientAppRun(singleDir);
            }
            else
            {
                getDirList();
                foreach (string dir in dirList)
                {
                    torClientAppRun(dir);
                }
            }
        }
        public void checkTorsExist()
        {
            getDirList();
            foreach (string dir in dirList)
            {
                string path = rootDir + "\\" + dir;
                bool isExist = checkExistTorFile(path);
                NewEvent?.Invoke(this, new EventProps(dir, "", false, false, true, isExist));
            }
        }

        void getDirList()
        {
            dirList = Directory.GetDirectories(rootDir).Select(Path.GetFileName).ToArray();
        }
        void torClientAppRun(string dir)
        {      
            string arguments = "/directory \"" + rootDir + "\" \"" + rootDir + "\\" + dir + "\\" + dir + ".torrent\"";
            ProcessStartInfo startInfo = new ProcessStartInfo(torClientAppPath)
            {
                Arguments = arguments,
                UseShellExecute = false,
            };

            NewEvent?.Invoke(this, new EventProps(dir, true, arguments));

            using (Process process = Process.Start(startInfo))
            {
                Thread.Sleep(1000);
                process.Close();
            }
        }
        void torMakerAppRun(string dir)
        {
            string path = rootDir + "\\" + dir;
            string arguments = "-o \"" + path + "\\" + dir + ".torrent\" -t \"" + trackers[0] + "\" -t \"" + trackers[1] + "\" \"" + path + "\""; 
            //if (torrenttoolsApp) arguments = "create \"" + path + "\" -o \"" + path + "\" -a \"" + trackers[0] + "\" \"" + trackers[1] +  "\"";
            if (isOnlyNewTor)
            {
                if (checkExistTorFile(path))
                {
                    NewEvent?.Invoke(this, new EventProps(dir, "Exist", true, false, false, false));
                    return;
                }                   
            }
            NewEvent?.Invoke(this, new EventProps(dir, true, arguments));

            string torMakerAppPath = Directory.GetCurrentDirectory() + "\\transmission\\transmission-create.exe"; ;
            ProcessStartInfo startInfo = new ProcessStartInfo(torMakerAppPath)
            {
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            
            using (Process process = Process.Start(startInfo))
            {
                string standardOutput = process.StandardOutput.ReadToEnd();
                string standardError = process.StandardError.ReadToEnd();

                process.WaitForExit();

                Debug.WriteLine("ExitCode: " + process.ExitCode.ToString());
                Debug.WriteLine("standardOutput: " + standardOutput);
                Debug.WriteLine("standardError: " + standardError);
                if (process.ExitCode != 0 || standardError != "")
                {
                    NewEvent?.Invoke(this, new EventProps(dir, "Error", true, true, false, false));                               
                }
                else
                {
                    NewEvent?.Invoke(this, new EventProps(dir, "Created", true, false, false, false));  
                }   
            }
        }
        bool checkExistTorFile(string path)
        {
            var directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*.torrent");
            if (files.Length == 0) return false;
            return true;
        }

        public TorMaker() { }
        public TorMaker(TorProps torProps)
        {
            rootDir = torProps.rootDir;
            singleDir = torProps.singleDir;
            isSingleDir = torProps.isSingleDir;
            trackers = torProps.trackers;
            isOnlyNewTor = torProps.isOnlyNewTor;
            torClientAppPath = torProps.torClientPath;
        }
    }
    class EventProps
    {
        public bool isArgs = false;

        public string torName = "";
        public string message = "";

        public bool makerMode = false;
        public bool isError = false;

        public bool checkerMode = false;
        public bool isExist = false;

        public EventProps(string torName, string message, bool makerMode, bool isError, bool checkerMode, bool isExist)
        {         
            this.torName = torName;
            this.message = message;

            this.makerMode = makerMode;
            this.isError = isError;

            this.checkerMode = checkerMode;
            this.isExist = isExist;        
        }
        public EventProps(string torName, bool isArgs, string message)
        {
            this.torName=torName;
            this.isArgs = isArgs;
            this.message = message;
        }
    }
}