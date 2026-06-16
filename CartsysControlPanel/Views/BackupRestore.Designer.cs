namespace CartsysControlPanel.Views
{
    partial class BackupRestore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDbpath = new Button();
            tbDbPath = new TextBox();
            tbErroCaminhoBancos = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tgCrypt = new ToggleButton();
            label3 = new Label();
            radioBackup = new RadioButton();
            radioRestore = new RadioButton();
            btnStart = new Button();
            cbPagination = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnDbpath
            // 
            btnDbpath.BackColor = Color.FromArgb(30, 42, 56);
            btnDbpath.BackgroundImageLayout = ImageLayout.None;
            btnDbpath.FlatAppearance.BorderSize = 0;
            btnDbpath.FlatStyle = FlatStyle.Flat;
            btnDbpath.ForeColor = Color.FromArgb(226, 232, 240);
            btnDbpath.Location = new Point(415, 101);
            btnDbpath.Name = "btnDbpath";
            btnDbpath.Size = new Size(28, 23);
            btnDbpath.TabIndex = 9;
            btnDbpath.Text = "...";
            btnDbpath.UseVisualStyleBackColor = false;
            btnDbpath.Click += btnDbpath_Click;
            // 
            // tbDbPath
            // 
            tbDbPath.BackColor = Color.FromArgb(30, 42, 56);
            tbDbPath.BorderStyle = BorderStyle.FixedSingle;
            tbDbPath.ForeColor = Color.FromArgb(226, 232, 240);
            tbDbPath.Location = new Point(47, 101);
            tbDbPath.Name = "tbDbPath";
            tbDbPath.PlaceholderText = "Caminho bancos";
            tbDbPath.ReadOnly = true;
            tbDbPath.Size = new Size(378, 23);
            tbDbPath.TabIndex = 8;
            // 
            // tbErroCaminhoBancos
            // 
            tbErroCaminhoBancos.BackColor = Color.FromArgb(17, 24, 39);
            tbErroCaminhoBancos.BorderStyle = BorderStyle.None;
            tbErroCaminhoBancos.ForeColor = Color.FromArgb(248, 113, 113);
            tbErroCaminhoBancos.Location = new Point(47, 130);
            tbErroCaminhoBancos.Name = "tbErroCaminhoBancos";
            tbErroCaminhoBancos.Size = new Size(396, 16);
            tbErroCaminhoBancos.TabIndex = 26;
            tbErroCaminhoBancos.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(47, 23);
            label2.Name = "label2";
            label2.Size = new Size(183, 30);
            label2.TabIndex = 28;
            label2.Text = "BACKUP/RESTORE";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(226, 232, 240);
            label1.Location = new Point(47, 75);
            label1.Name = "label1";
            label1.Size = new Size(247, 23);
            label1.TabIndex = 27;
            label1.Text = "Selecione o caminho do banco";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tgCrypt
            // 
            tgCrypt.BackColor = Color.Transparent;
            tgCrypt.Location = new Point(47, 219);
            tgCrypt.MinimumSize = new Size(25, 22);
            tgCrypt.Name = "tgCrypt";
            tgCrypt.Size = new Size(50, 22);
            tgCrypt.TabIndex = 29;
            tgCrypt.Text = "toggleButton1";
            tgCrypt.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(226, 232, 240);
            label3.Location = new Point(47, 193);
            label3.Name = "label3";
            label3.Size = new Size(134, 23);
            label3.TabIndex = 30;
            label3.Text = "Banco criptografado?";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // radioBackup
            // 
            radioBackup.AutoSize = true;
            radioBackup.Location = new Point(47, 130);
            radioBackup.Name = "radioBackup";
            radioBackup.Size = new Size(64, 19);
            radioBackup.TabIndex = 31;
            radioBackup.TabStop = true;
            radioBackup.Text = "Backup";
            radioBackup.UseVisualStyleBackColor = true;
            // 
            // radioRestore
            // 
            radioRestore.AutoSize = true;
            radioRestore.Location = new Point(47, 155);
            radioRestore.Name = "radioRestore";
            radioRestore.Size = new Size(64, 19);
            radioRestore.TabIndex = 32;
            radioRestore.TabStop = true;
            radioRestore.Text = "Restore";
            radioRestore.UseVisualStyleBackColor = true;
            radioRestore.CheckedChanged += radioRestore_CheckedChanged;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(100, 116, 139);
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.ForeColor = Color.FromArgb(226, 232, 240);
            btnStart.Location = new Point(47, 284);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(134, 38);
            btnStart.TabIndex = 33;
            btnStart.Text = "Iniciar ";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // cbPagination
            // 
            cbPagination.BackColor = Color.FromArgb(30, 42, 56);
            cbPagination.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPagination.FlatStyle = FlatStyle.Flat;
            cbPagination.ForeColor = Color.FromArgb(226, 232, 240);
            cbPagination.FormattingEnabled = true;
            cbPagination.Location = new Point(274, 219);
            cbPagination.Name = "cbPagination";
            cbPagination.Size = new Size(96, 23);
            cbPagination.TabIndex = 35;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(226, 232, 240);
            label4.Location = new Point(274, 192);
            label4.Name = "label4";
            label4.Size = new Size(134, 23);
            label4.TabIndex = 36;
            label4.Text = "Paginação do banco";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BackupRestore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(1264, 681);
            Controls.Add(label4);
            Controls.Add(cbPagination);
            Controls.Add(btnStart);
            Controls.Add(radioRestore);
            Controls.Add(radioBackup);
            Controls.Add(label3);
            Controls.Add(tgCrypt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbErroCaminhoBancos);
            Controls.Add(btnDbpath);
            Controls.Add(tbDbPath);
            ForeColor = Color.FromArgb(226, 232, 240);
            Name = "BackupRestore";
            Text = "BackupRestore";
            Load += BackupRestore_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDbpath;
        private TextBox tbDbPath;
        private TextBox tbErroCaminhoBancos;
        private Label label2;
        private Label label1;
        private ToggleButton tgCrypt;
        private Label label3;
        private RadioButton radioBackup;
        private RadioButton radioRestore;
        private Button btnStart;
        public ComboBox cbPagination;
        private Label label4;
    }
}