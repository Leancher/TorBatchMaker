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
        string torMakerAppPath = Directory.GetCurrentDirectory() + "\\transmission\\transmission-create.exe";
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
        void getDirList()
        {
            dirList = Directory.GetDirectories(rootDir).Select(Path.GetFileName).ToArray(); ;
        }
        void torClientAppRun(string dir)
        {      
            string path = rootDir + "\\" + dir;
            string arguments = "/directory \"" + path + "\" \"" + path + "\\" + dir + ".torrent\"";
            ProcessStartInfo startInfo = new ProcessStartInfo(torClientAppPath)
            {
                Arguments = arguments,
                UseShellExecute = false,
            };
            using (Process process = Process.Start(startInfo))
            {
                Thread.Sleep(1000);
                process.Close();
            }
        }
        void torMakerAppRun(string dir)
        {
            string path = rootDir + "\\" + dir;
            //string command = "torrenttools create \"" + path + "\" -o \"" + path + "\" -a \"" + tracker1 + "\" \"" + tracker2 +  "\"";
            string arguments = "-o \"" + path + "\\" + dir + ".torrent\" -t \"" + tracker1 + "\" -t \"" + tracker2 + "\" \"" + path + "\""; 
            if (isOnlyNewTor)
            {
                if (checkExistTorFile(path))
                {
                    sendEvent(false, true, dir, false, "Exist");
                    return;
                }                   
            }
            sendEvent(true, false, arguments, false, "");

            ProcessStartInfo startInfo = new ProcessStartInfo(torMakerAppPath)
            {
                Arguments = arguments,
                UseShellExecute = false,
            };
            
            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
                Debug.WriteLine("ExitCode: " + process.ExitCode.ToString());
                if (process.ExitCode == 0)
                {
                    sendEvent(false, true, dir, false, "Created");                
                }
                else
                {
                    sendEvent(false, true, dir, true, "Error");
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

        void sendEvent(bool isArgs, bool isTorName, string torName, bool isError, string message)
        {
            eventProps = new EventProps();
            eventProps.isArgs = isArgs;
            eventProps.isTorName = isTorName;
            eventProps.torName = torName;
            eventProps.isError = isError;
            eventProps.message = message;
            NewEvent?.Invoke(this, eventProps);
        }

        public TorMaker() { }
        public TorMaker(TorProps torProps)
        {
            rootDir = torProps.rootDir;
            singleDir = torProps.singleDir;
            isSingleDir = torProps.isSingleDir;
            tracker1 = torProps.tracker1;
            tracker2 = torProps.tracker2;
            isOnlyNewTor = torProps.isOnlyNewTor;
            torClientAppPath = torProps.torClientPath;
        }

    }
    public class EventProps()
    {
        public bool isArgs = false;
        public bool isTorName = false;
        public string torName = "";
        public bool isError = false;
        public string message = "";
    }
}