using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace TorBatchMaker
{
    public partial class Form1 : Form
    {
        TorMaker torMaker;
        TorProps torProps;
        public Form1()
        {
            InitializeComponent();
        }

        private void eventHandler(object sender, EventProps eventProps)
        {
            ListViewItem item = new ListViewItem();
            if (eventProps.isArgs) txtCommand.Text = eventProps.message;
            if (eventProps.checkerMode)
            {
                item.Text = eventProps.torName;
                if (eventProps.isExist == false)
                {
                    item.SubItems.Add("No");
                    item.BackColor = Color.LightBlue;
                }
                item.SubItems.Add("Exist");
                listTors.Items.Add(item);
            }
            if (eventProps.makerMode)
            {
                item.Text = eventProps.torName;
                item.SubItems.Add(eventProps.message);
                if (eventProps.isError) item.BackColor = Color.LightBlue;
                listTors.Items.Add(item);
            }
        }

        private void btMakeTorrents_Click(object sender, EventArgs e)
        {
            listTors.Items.Clear();
            setTorProps(true, false);
            torMaker = new(torProps);
            torMaker.NewEvent += eventHandler;
            torMaker.makeTorrents();
        }
        private void btAddSeed_Click(object sender, EventArgs e)
        {
            setTorProps(false, false);
            torMaker = new(torProps);
            torMaker.NewEvent += eventHandler;
            torMaker.seedTorrents();
        }
        void setTorProps(bool transmissionApp, bool torrenttoolsApp)
        {
            string rootDir = txtRootDir.Text + "\\" + listDirs.SelectedItems[0].ToString(); ;
            string singleDir = txtSingleDir.Text;
            bool isSingleDir = cbSingleDir.Checked;
            string[] trackers = new string[2];
            trackers[0] = txtTracker1.Text;
            trackers[1] = txtTracker2.Text;
            bool isOnlyNewTor = cbOnlyNewTor.Checked;
            string torClientPath = txtTorClientPath.Text;
            torProps = new(rootDir, singleDir, isSingleDir, trackers, isOnlyNewTor, torClientPath, transmissionApp, torrenttoolsApp);
        }
        private void listTors_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item;
            if (listTors.SelectedItems.Count > 0)
            {
                item = listTors.SelectedItems[0];
                // Укажите путь к вашей папке
                string folderPath = txtRootDir.Text + "\\" + item.Text;
                // Открыть папку в проводнике
                Process.Start("explorer.exe", folderPath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listTors.Items.Clear();
            showDirs();
        }

        void showDirs()
        {
            listDirs.Items.Clear();
            string rootDir = txtRootDir.Text;
            string[] dirList = Directory.GetDirectories(rootDir).Select(Path.GetFileName).ToArray();
            foreach (string dir in dirList)
            {
                listDirs.Items.Add(dir);
            }
            listDirs.SelectedIndex = 0;
        }
        private void btCheckTorExist_Click(object sender, EventArgs e)
        {
            listTors.Items.Clear();
            setTorProps(false, false);
            torMaker = new(torProps);
            torMaker.NewEvent += eventHandler;
            torMaker.checkTorsExist();
        }

    }

    class TorProps
    {
        public string rootDir = "";
        public string singleDir = "";
        public bool isSingleDir = false;
        public string[] trackers;
        public bool isOnlyNewTor = false;
        public string torClientPath = "";
        public bool transmissionApp = false;
        public bool torrenttoolsApp = false;

        public TorProps(string rootDir, string singleDir, bool isSingleDir, string[] trackers, bool isOnlyNewTor, string torClientPath, bool transmissionApp, bool torrenttoolsApp)
        {
            this.rootDir = rootDir;
            this.singleDir = singleDir;
            this.isSingleDir = isSingleDir;
            this.trackers = trackers;
            this.isOnlyNewTor = isOnlyNewTor;
            this.torClientPath = torClientPath;
            this.transmissionApp = transmissionApp;
            this.torrenttoolsApp = torrenttoolsApp;
        }
    }
}
