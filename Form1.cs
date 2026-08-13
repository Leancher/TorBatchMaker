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
            if (eventProps.isArgs) txtCommand.Text = eventProps.torName;
            if (eventProps.isTorName)
            {
                item.Text = eventProps.torName;
                item.SubItems.Add(eventProps.message);
                if (eventProps.isError) item.BackColor = Color.LightBlue;
                listTors.Items.Add(item);
            }

        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            listTors.Items.Clear();
            torProps = new TorProps();
            setTorProps(torProps);
            torMaker = new(torProps);
            torMaker.NewEvent += eventHandler;
            torMaker.makeTorrents();
        }

        private void btAddSeed_Click(object sender, EventArgs e)
        {
            torProps = new TorProps();
            setTorProps(torProps);
            torMaker = new(torProps);
            torMaker.NewEvent += eventHandler;
            torMaker.seedTorrents();
        }
        void setTorProps(TorProps torProps)
        {
            torProps.rootDir = txtRootDir.Text;
            torProps.singleDir = txtSingleDir.Text;
            torProps.isSingleDir = cbSingleDir.Checked;
            torProps.tracker1 = txtTracker1.Text;
            torProps.tracker2 = txtTracker2.Text;
            torProps.isOnlyNewTor = cbOnlyNewTor.Checked;
            torProps.torClientPath = txtTorClientPath.Text;
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
        }
    }

    public class TorProps()
    {
        public string rootDir = "";
        public string singleDir = "";
        public bool isSingleDir = false;
        public string tracker1 = "";
        public string tracker2 = "";
        public bool isOnlyNewTor = false;
        public string torClientPath = "";
    }
}
