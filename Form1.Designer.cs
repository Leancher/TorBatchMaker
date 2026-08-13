namespace TorBatchMaker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem("1");
            ListViewItem listViewItem2 = new ListViewItem("2");
            btCreate = new Button();
            btAddSeed = new Button();
            label1 = new Label();
            txtRootDir = new TextBox();
            txtTracker1 = new TextBox();
            txtTracker2 = new TextBox();
            label2 = new Label();
            txtSingleDir = new TextBox();
            cbSingleDir = new CheckBox();
            label3 = new Label();
            txtCommand = new TextBox();
            cbOnlyNewTor = new CheckBox();
            label4 = new Label();
            txtTorClientPath = new TextBox();
            listTors = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            SuspendLayout();
            // 
            // btCreate
            // 
            btCreate.Location = new Point(26, 188);
            btCreate.Name = "btCreate";
            btCreate.Size = new Size(320, 23);
            btCreate.TabIndex = 0;
            btCreate.Text = "Создать торренты";
            btCreate.UseVisualStyleBackColor = true;
            btCreate.Click += btCreate_Click;
            // 
            // btAddSeed
            // 
            btAddSeed.Location = new Point(26, 300);
            btAddSeed.Name = "btAddSeed";
            btAddSeed.Size = new Size(320, 23);
            btAddSeed.TabIndex = 1;
            btAddSeed.Text = "Добавить торренты для раздачи";
            btAddSeed.UseVisualStyleBackColor = true;
            btAddSeed.Click += btAddSeed_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 23);
            label1.Name = "label1";
            label1.Size = new Size(176, 15);
            label1.TabIndex = 2;
            label1.Text = "Корневая папка для торрентов";
            // 
            // txtRootDir
            // 
            txtRootDir.Location = new Point(26, 41);
            txtRootDir.Name = "txtRootDir";
            txtRootDir.Size = new Size(320, 23);
            txtRootDir.TabIndex = 3;
            txtRootDir.Text = "D:\\FTP-server\\Images\\Games";
            // 
            // txtTracker1
            // 
            txtTracker1.Location = new Point(26, 403);
            txtTracker1.Name = "txtTracker1";
            txtTracker1.Size = new Size(320, 23);
            txtTracker1.TabIndex = 5;
            txtTracker1.Text = "udp://tracker.openbittorrent.com:80/announce";
            // 
            // txtTracker2
            // 
            txtTracker2.Location = new Point(26, 432);
            txtTracker2.Name = "txtTracker2";
            txtTracker2.Size = new Size(320, 23);
            txtTracker2.TabIndex = 6;
            txtTracker2.Text = "udp://tracker.opentrackr.org:1337/announce";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 385);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 7;
            label2.Text = "Трекеры";
            // 
            // txtSingleDir
            // 
            txtSingleDir.Location = new Point(26, 142);
            txtSingleDir.Name = "txtSingleDir";
            txtSingleDir.Size = new Size(320, 23);
            txtSingleDir.TabIndex = 8;
            txtSingleDir.Text = "D:\\FTP-server\\Images\\Games\\TS";
            // 
            // cbSingleDir
            // 
            cbSingleDir.AutoSize = true;
            cbSingleDir.Location = new Point(26, 117);
            cbSingleDir.Name = "cbSingleDir";
            cbSingleDir.Size = new Size(312, 19);
            cbSingleDir.TabIndex = 10;
            cbSingleDir.Text = "Создать или добавить торрент для отдельной папки";
            cbSingleDir.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 465);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 11;
            label3.Text = "Команда";
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(28, 483);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(663, 23);
            txtCommand.TabIndex = 12;
            // 
            // cbOnlyNewTor
            // 
            cbOnlyNewTor.AutoSize = true;
            cbOnlyNewTor.Location = new Point(26, 83);
            cbOnlyNewTor.Name = "cbOnlyNewTor";
            cbOnlyNewTor.Size = new Size(204, 19);
            cbOnlyNewTor.TabIndex = 13;
            cbOnlyNewTor.Text = "Создать только новые торренты";
            cbOnlyNewTor.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 241);
            label4.Name = "label4";
            label4.Size = new Size(196, 15);
            label4.TabIndex = 14;
            label4.Text = "Паппка с клиентом для торрентов";
            // 
            // txtTorClientPath
            // 
            txtTorClientPath.Location = new Point(26, 259);
            txtTorClientPath.Name = "txtTorClientPath";
            txtTorClientPath.Size = new Size(320, 23);
            txtTorClientPath.TabIndex = 15;
            txtTorClientPath.Text = "C:\\Users\\Leancher\\AppData\\Roaming\\utorrent";
            // 
            // listTors
            // 
            listTors.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listTors.FullRowSelect = true;
            listTors.GridLines = true;
            listTors.HeaderStyle = ColumnHeaderStyle.None;
            listTors.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
            listTors.Location = new Point(372, 23);
            listTors.Name = "listTors";
            listTors.Size = new Size(319, 432);
            listTors.TabIndex = 16;
            listTors.UseCompatibleStateImageBehavior = false;
            listTors.View = View.Details;
            listTors.DoubleClick += listTors_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Width = 250;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 538);
            Controls.Add(listTors);
            Controls.Add(txtTorClientPath);
            Controls.Add(label4);
            Controls.Add(cbOnlyNewTor);
            Controls.Add(txtCommand);
            Controls.Add(label3);
            Controls.Add(cbSingleDir);
            Controls.Add(txtSingleDir);
            Controls.Add(label2);
            Controls.Add(txtTracker2);
            Controls.Add(txtTracker1);
            Controls.Add(txtRootDir);
            Controls.Add(label1);
            Controls.Add(btAddSeed);
            Controls.Add(btCreate);
            Name = "Form1";
            Text = "Пакетное создание торрент-файлов";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btCreate;
        private Button btAddSeed;
        private Label label1;
        private TextBox txtRootDir;
        private TextBox txtTracker1;
        private TextBox txtTracker2;
        private Label label2;
        private TextBox txtSingleDir;
        private CheckBox cbSingleDir;
        private Label label3;
        private TextBox txtCommand;
        private CheckBox cbOnlyNewTor;
        private Label label4;
        private TextBox txtTorClientPath;
        private ListView listTors;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}
