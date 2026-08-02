using System.Diagnostics;
namespace TorMakerBatch
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            TorMaker torMaker = new(txtRootDir.Text,txtTracker1.Text,txtTracker2.Text);
            torMaker.makeTorrents();
        }
    }
}
