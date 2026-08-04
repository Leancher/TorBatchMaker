using System.Diagnostics;
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

        private void commandTextUpdate(object sender, string text)
        {
            Debug.WriteLine("event");
            txtCommand.Text = text;
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            torProps = new TorProps();
            torProps.rootDir = txtRootDir.Text;
            torProps.singleDir = txtSingleDir.Text;
            torProps.isSingleDir = cbSingleDir.Checked;
            torProps.tracker1 = txtTracker1.Text;
            torProps.tracker2 = txtTracker2.Text;
            torProps.isOnlyNewTor = cbOnlyNewTor.Checked;
            torMaker = new(torProps);
            torMaker.SendCommand += commandTextUpdate;
            torMaker.makeTorrents();
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
    }
}
