namespace CartsysControlPanel.Views
{
    partial class FirebirdHqbirdForm
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
            btnDirectDownload = new Button();
            btnHqbirdPage = new Button();
            label1 = new Label();
            label2 = new Label();
            btnFirebirdInstall = new Button();
            label3 = new Label();
            btnFirebirdConfig = new Button();
            btnDbcrypt = new Button();
            btnBackupFolder = new Button();
            btnUdr = new Button();
            btnAllConfig = new Button();
            SuspendLayout();
            // 
            // btnDirectDownload
            // 
            btnDirectDownload.BackColor = Color.FromArgb(100, 116, 139);
            btnDirectDownload.FlatAppearance.BorderSize = 0;
            btnDirectDownload.FlatStyle = FlatStyle.Flat;
            btnDirectDownload.ForeColor = Color.FromArgb(226, 232, 240);
            btnDirectDownload.Location = new Point(39, 83);
            btnDirectDownload.Name = "btnDirectDownload";
            btnDirectDownload.Size = new Size(119, 38);
            btnDirectDownload.TabIndex = 3;
            btnDirectDownload.Text = "Download Direto";
            btnDirectDownload.UseVisualStyleBackColor = false;
            btnDirectDownload.Click += btnDirectDownload_Click;
            // 
            // btnHqbirdPage
            // 
            btnHqbirdPage.BackColor = Color.FromArgb(100, 116, 139);
            btnHqbirdPage.FlatAppearance.BorderSize = 0;
            btnHqbirdPage.FlatStyle = FlatStyle.Flat;
            btnHqbirdPage.ForeColor = Color.FromArgb(226, 232, 240);
            btnHqbirdPage.Location = new Point(203, 83);
            btnHqbirdPage.Name = "btnHqbirdPage";
            btnHqbirdPage.Size = new Size(119, 38);
            btnHqbirdPage.TabIndex = 4;
            btnHqbirdPage.Text = "Página Oficial HQBird";
            btnHqbirdPage.UseVisualStyleBackColor = false;
            btnHqbirdPage.Click += btnHqbirdPage_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(39, 36);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 5;
            label1.Text = "DOWNLOAD HQBIRD";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(39, 158);
            label2.Name = "label2";
            label2.Size = new Size(163, 20);
            label2.TabIndex = 6;
            label2.Text = "INSTALAR FIREBIRD 3.0";
            // 
            // btnFirebirdInstall
            // 
            btnFirebirdInstall.BackColor = Color.FromArgb(100, 116, 139);
            btnFirebirdInstall.FlatAppearance.BorderSize = 0;
            btnFirebirdInstall.FlatStyle = FlatStyle.Flat;
            btnFirebirdInstall.ForeColor = Color.FromArgb(226, 232, 240);
            btnFirebirdInstall.Location = new Point(39, 200);
            btnFirebirdInstall.Name = "btnFirebirdInstall";
            btnFirebirdInstall.Size = new Size(119, 38);
            btnFirebirdInstall.TabIndex = 7;
            btnFirebirdInstall.Text = "Instalar Firebird";
            btnFirebirdInstall.UseVisualStyleBackColor = false;
            btnFirebirdInstall.Click += btnFirebirdInstall_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(39, 270);
            label3.Name = "label3";
            label3.Size = new Size(230, 20);
            label3.TabIndex = 8;
            label3.Text = "CONFIGURAÇÕES/CRIPTOGRAFIA";
            // 
            // btnFirebirdConfig
            // 
            btnFirebirdConfig.BackColor = Color.FromArgb(100, 116, 139);
            btnFirebirdConfig.FlatAppearance.BorderSize = 0;
            btnFirebirdConfig.FlatStyle = FlatStyle.Flat;
            btnFirebirdConfig.ForeColor = Color.FromArgb(226, 232, 240);
            btnFirebirdConfig.Location = new Point(39, 308);
            btnFirebirdConfig.Name = "btnFirebirdConfig";
            btnFirebirdConfig.Size = new Size(119, 38);
            btnFirebirdConfig.TabIndex = 9;
            btnFirebirdConfig.Text = "Aplicar Firebird.conf";
            btnFirebirdConfig.UseVisualStyleBackColor = false;
            btnFirebirdConfig.Click += btnFirebirdConfig_Click;
            // 
            // btnDbcrypt
            // 
            btnDbcrypt.BackColor = Color.FromArgb(100, 116, 139);
            btnDbcrypt.FlatAppearance.BorderSize = 0;
            btnDbcrypt.FlatStyle = FlatStyle.Flat;
            btnDbcrypt.ForeColor = Color.FromArgb(226, 232, 240);
            btnDbcrypt.Location = new Point(203, 308);
            btnDbcrypt.Name = "btnDbcrypt";
            btnDbcrypt.Size = new Size(119, 38);
            btnDbcrypt.TabIndex = 10;
            btnDbcrypt.Text = "Aplicar DbCrypt.conf";
            btnDbcrypt.UseVisualStyleBackColor = false;
            btnDbcrypt.Click += btnDbcrypt_Click;
            // 
            // btnBackupFolder
            // 
            btnBackupFolder.BackColor = Color.FromArgb(100, 116, 139);
            btnBackupFolder.FlatAppearance.BorderSize = 0;
            btnBackupFolder.FlatStyle = FlatStyle.Flat;
            btnBackupFolder.ForeColor = Color.FromArgb(226, 232, 240);
            btnBackupFolder.Location = new Point(39, 375);
            btnBackupFolder.Name = "btnBackupFolder";
            btnBackupFolder.Size = new Size(119, 38);
            btnBackupFolder.TabIndex = 11;
            btnBackupFolder.Text = "Configurar Pasta de Backup";
            btnBackupFolder.UseVisualStyleBackColor = false;
            btnBackupFolder.Click += btnBackupFolder_Click;
            // 
            // btnUdr
            // 
            btnUdr.BackColor = Color.FromArgb(100, 116, 139);
            btnUdr.FlatAppearance.BorderSize = 0;
            btnUdr.FlatStyle = FlatStyle.Flat;
            btnUdr.ForeColor = Color.FromArgb(226, 232, 240);
            btnUdr.Location = new Point(203, 375);
            btnUdr.Name = "btnUdr";
            btnUdr.Size = new Size(119, 38);
            btnUdr.TabIndex = 12;
            btnUdr.Text = "Configurar UDR_SC.dll";
            btnUdr.UseVisualStyleBackColor = false;
            btnUdr.Click += btnUdr_Click;
            // 
            // btnAllConfig
            // 
            btnAllConfig.BackColor = Color.FromArgb(100, 116, 139);
            btnAllConfig.FlatAppearance.BorderSize = 0;
            btnAllConfig.FlatStyle = FlatStyle.Flat;
            btnAllConfig.ForeColor = Color.FromArgb(226, 232, 240);
            btnAllConfig.Location = new Point(39, 453);
            btnAllConfig.Name = "btnAllConfig";
            btnAllConfig.Size = new Size(283, 38);
            btnAllConfig.TabIndex = 13;
            btnAllConfig.Text = "Executar configuração completa";
            btnAllConfig.UseVisualStyleBackColor = false;
            btnAllConfig.Click += btnAllConfig_Click;
            // 
            // FirebirdHqbirdForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(1264, 681);
            Controls.Add(btnAllConfig);
            Controls.Add(btnUdr);
            Controls.Add(btnBackupFolder);
            Controls.Add(btnDbcrypt);
            Controls.Add(btnFirebirdConfig);
            Controls.Add(label3);
            Controls.Add(btnFirebirdInstall);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnHqbirdPage);
            Controls.Add(btnDirectDownload);
            ForeColor = Color.FromArgb(226, 232, 240);
            Name = "FirebirdHqbirdForm";
            Text = "FirebirdHqbirdForm";
            Load += FirebirdHqbirdForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnFirebirdInstall;
        private Button btnDirectDownload;
        private Button btnHqbirdPage;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnFirebirdConfig;
        private Button btnDbcrypt;
        private Button btnBackupFolder;
        private Button btnUdr;
        private Button btnAllConfig;
    }
}