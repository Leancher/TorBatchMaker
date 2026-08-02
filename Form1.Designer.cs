namespace TorMakerBatch
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
            btCreate = new Button();
            btAddSeed = new Button();
            label1 = new Label();
            txtRootDir = new TextBox();
            progressBar1 = new ProgressBar();
            txtTracker1 = new TextBox();
            txtTracker2 = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btCreate
            // 
            btCreate.Location = new Point(36, 186);
            btCreate.Name = "btCreate";
            btCreate.Size = new Size(316, 23);
            btCreate.TabIndex = 0;
            btCreate.Text = "Создать файлы";
            btCreate.UseVisualStyleBackColor = true;
            btCreate.Click += btCreate_Click;
            // 
            // btAddSeed
            // 
            btAddSeed.Location = new Point(507, 186);
            btAddSeed.Name = "btAddSeed";
            btAddSeed.Size = new Size(218, 23);
            btAddSeed.TabIndex = 1;
            btAddSeed.Text = "Добавить файлы для раздачи";
            btAddSeed.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 38);
            label1.Name = "label1";
            label1.Size = new Size(229, 15);
            label1.TabIndex = 2;
            label1.Text = "Корневая папка для создания торрентов";
            // 
            // txtRootDir
            // 
            txtRootDir.Location = new Point(33, 56);
            txtRootDir.Name = "txtRootDir";
            txtRootDir.Size = new Size(319, 23);
            txtRootDir.TabIndex = 3;
            txtRootDir.Text = "D:\\FTP-server\\Images\\Games";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(33, 292);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(692, 23);
            progressBar1.TabIndex = 4;
            // 
            // txtTracker1
            // 
            txtTracker1.Location = new Point(33, 115);
            txtTracker1.Name = "txtTracker1";
            txtTracker1.Size = new Size(319, 23);
            txtTracker1.TabIndex = 5;
            txtTracker1.Text = "udp://tracker.openbittorrent.com:80/announce";
            // 
            // txtTracker2
            // 
            txtTracker2.Location = new Point(33, 144);
            txtTracker2.Name = "txtTracker2";
            txtTracker2.Size = new Size(319, 23);
            txtTracker2.TabIndex = 6;
            txtTracker2.Text = "udp://tracker.opentrackr.org:1337/announce";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 97);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 7;
            label2.Text = "Трекеры";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(761, 344);
            Controls.Add(label2);
            Controls.Add(txtTracker2);
            Controls.Add(txtTracker1);
            Controls.Add(progressBar1);
            Controls.Add(txtRootDir);
            Controls.Add(label1);
            Controls.Add(btAddSeed);
            Controls.Add(btCreate);
            Name = "Form1";
            Text = "Пакетное создание торрент-файлов";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btCreate;
        private Button btAddSeed;
        private Label label1;
        private TextBox txtRootDir;
        private ProgressBar progressBar1;
        private TextBox txtTracker1;
        private TextBox txtTracker2;
        private Label label2;
    }
}
