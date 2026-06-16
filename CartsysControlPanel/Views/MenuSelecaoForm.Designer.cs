namespace CartsysControlPanel.Views
{
    partial class MenuSelecaoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuSelecaoForm));
            menuPanel = new Panel();
            btnBackupRestore = new FontAwesome.Sharp.IconButton();
            hqBirdCalculatorBtn = new FontAwesome.Sharp.IconButton();
            firebirdHqbirdBtn = new FontAwesome.Sharp.IconButton();
            configsHandlerBtn = new FontAwesome.Sharp.IconButton();
            servicesHandlerBtn = new FontAwesome.Sharp.IconButton();
            btnHome = new FontAwesome.Sharp.IconButton();
            logoPanel = new Panel();
            btnIcon = new PictureBox();
            panelDesktop = new Panel();
            menuPanel.SuspendLayout();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnIcon).BeginInit();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.FromArgb(30, 42, 56);
            menuPanel.Controls.Add(btnBackupRestore);
            menuPanel.Controls.Add(hqBirdCalculatorBtn);
            menuPanel.Controls.Add(firebirdHqbirdBtn);
            menuPanel.Controls.Add(configsHandlerBtn);
            menuPanel.Controls.Add(servicesHandlerBtn);
            menuPanel.Controls.Add(btnHome);
            menuPanel.Controls.Add(logoPanel);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(220, 681);
            menuPanel.TabIndex = 0;
            // 
            // btnBackupRestore
            // 
            btnBackupRestore.Dock = DockStyle.Top;
            btnBackupRestore.FlatAppearance.BorderSize = 0;
            btnBackupRestore.FlatStyle = FlatStyle.Flat;
            btnBackupRestore.ForeColor = Color.FromArgb(226, 232, 240);
            btnBackupRestore.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            btnBackupRestore.IconColor = Color.FromArgb(100, 116, 139);
            btnBackupRestore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBackupRestore.IconSize = 32;
            btnBackupRestore.ImageAlign = ContentAlignment.MiddleLeft;
            btnBackupRestore.Location = new Point(0, 400);
            btnBackupRestore.Name = "btnBackupRestore";
            btnBackupRestore.Padding = new Padding(10, 0, 20, 0);
            btnBackupRestore.Size = new Size(220, 60);
            btnBackupRestore.TabIndex = 7;
            btnBackupRestore.Text = "Backup/Restore";
            btnBackupRestore.TextAlign = ContentAlignment.MiddleLeft;
            btnBackupRestore.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBackupRestore.UseVisualStyleBackColor = true;
            btnBackupRestore.Click += backupRestore_Click;
            // 
            // hqBirdCalculatorBtn
            // 
            hqBirdCalculatorBtn.Dock = DockStyle.Top;
            hqBirdCalculatorBtn.FlatAppearance.BorderSize = 0;
            hqBirdCalculatorBtn.FlatStyle = FlatStyle.Flat;
            hqBirdCalculatorBtn.ForeColor = Color.FromArgb(226, 232, 240);
            hqBirdCalculatorBtn.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            hqBirdCalculatorBtn.IconColor = Color.FromArgb(100, 116, 139);
            hqBirdCalculatorBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            hqBirdCalculatorBtn.IconSize = 32;
            hqBirdCalculatorBtn.ImageAlign = ContentAlignment.MiddleLeft;
            hqBirdCalculatorBtn.Location = new Point(0, 340);
            hqBirdCalculatorBtn.Name = "hqBirdCalculatorBtn";
            hqBirdCalculatorBtn.Padding = new Padding(10, 0, 20, 0);
            hqBirdCalculatorBtn.Size = new Size(220, 60);
            hqBirdCalculatorBtn.TabIndex = 6;
            hqBirdCalculatorBtn.Text = "Calculadora HQBird";
            hqBirdCalculatorBtn.TextAlign = ContentAlignment.MiddleLeft;
            hqBirdCalculatorBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            hqBirdCalculatorBtn.UseVisualStyleBackColor = true;
            hqBirdCalculatorBtn.Click += hqBirdCalculatorBtn_Click;
            // 
            // firebirdHqbirdBtn
            // 
            firebirdHqbirdBtn.Dock = DockStyle.Top;
            firebirdHqbirdBtn.FlatAppearance.BorderSize = 0;
            firebirdHqbirdBtn.FlatStyle = FlatStyle.Flat;
            firebirdHqbirdBtn.ForeColor = Color.FromArgb(226, 232, 240);
            firebirdHqbirdBtn.IconChar = FontAwesome.Sharp.IconChar.Database;
            firebirdHqbirdBtn.IconColor = Color.FromArgb(100, 116, 139);
            firebirdHqbirdBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            firebirdHqbirdBtn.IconSize = 32;
            firebirdHqbirdBtn.ImageAlign = ContentAlignment.MiddleLeft;
            firebirdHqbirdBtn.Location = new Point(0, 280);
            firebirdHqbirdBtn.Name = "firebirdHqbirdBtn";
            firebirdHqbirdBtn.Padding = new Padding(10, 0, 20, 0);
            firebirdHqbirdBtn.Size = new Size(220, 60);
            firebirdHqbirdBtn.TabIndex = 4;
            firebirdHqbirdBtn.Text = "Firebird/HQbird";
            firebirdHqbirdBtn.TextAlign = ContentAlignment.MiddleLeft;
            firebirdHqbirdBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            firebirdHqbirdBtn.UseVisualStyleBackColor = true;
            firebirdHqbirdBtn.Click += firebirdHqbirdBtn_Click;
            // 
            // configsHandlerBtn
            // 
            configsHandlerBtn.Dock = DockStyle.Top;
            configsHandlerBtn.FlatAppearance.BorderSize = 0;
            configsHandlerBtn.FlatStyle = FlatStyle.Flat;
            configsHandlerBtn.ForeColor = Color.FromArgb(226, 232, 240);
            configsHandlerBtn.IconChar = FontAwesome.Sharp.IconChar.Sliders;
            configsHandlerBtn.IconColor = Color.FromArgb(100, 116, 139);
            configsHandlerBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            configsHandlerBtn.IconSize = 32;
            configsHandlerBtn.ImageAlign = ContentAlignment.MiddleLeft;
            configsHandlerBtn.Location = new Point(0, 220);
            configsHandlerBtn.Name = "configsHandlerBtn";
            configsHandlerBtn.Padding = new Padding(10, 0, 20, 0);
            configsHandlerBtn.Size = new Size(220, 60);
            configsHandlerBtn.TabIndex = 3;
            configsHandlerBtn.Text = "Configurações";
            configsHandlerBtn.TextAlign = ContentAlignment.MiddleLeft;
            configsHandlerBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            configsHandlerBtn.UseVisualStyleBackColor = true;
            configsHandlerBtn.Click += configsHandlerBtn_Click;
            // 
            // servicesHandlerBtn
            // 
            servicesHandlerBtn.Dock = DockStyle.Top;
            servicesHandlerBtn.FlatAppearance.BorderSize = 0;
            servicesHandlerBtn.FlatStyle = FlatStyle.Flat;
            servicesHandlerBtn.ForeColor = Color.FromArgb(226, 232, 240);
            servicesHandlerBtn.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            servicesHandlerBtn.IconColor = Color.FromArgb(100, 116, 139);
            servicesHandlerBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            servicesHandlerBtn.IconSize = 32;
            servicesHandlerBtn.ImageAlign = ContentAlignment.MiddleLeft;
            servicesHandlerBtn.Location = new Point(0, 160);
            servicesHandlerBtn.Name = "servicesHandlerBtn";
            servicesHandlerBtn.Padding = new Padding(10, 0, 20, 0);
            servicesHandlerBtn.Size = new Size(220, 60);
            servicesHandlerBtn.TabIndex = 2;
            servicesHandlerBtn.Text = "Serviços";
            servicesHandlerBtn.TextAlign = ContentAlignment.MiddleLeft;
            servicesHandlerBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            servicesHandlerBtn.UseVisualStyleBackColor = true;
            servicesHandlerBtn.Click += servicesHandlerBtn_Click;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.ForeColor = Color.FromArgb(226, 232, 240);
            btnHome.IconChar = FontAwesome.Sharp.IconChar.House;
            btnHome.IconColor = Color.FromArgb(100, 116, 139);
            btnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHome.IconSize = 32;
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(0, 100);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(10, 0, 20, 0);
            btnHome.Size = new Size(220, 60);
            btnHome.TabIndex = 1;
            btnHome.Text = "Menu Iniciar";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // logoPanel
            // 
            logoPanel.Controls.Add(btnIcon);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(220, 100);
            logoPanel.TabIndex = 0;
            // 
            // btnIcon
            // 
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Image = Properties.Resources.cartsysLogo;
            btnIcon.Location = new Point(0, 0);
            btnIcon.Name = "btnIcon";
            btnIcon.Size = new Size(220, 100);
            btnIcon.SizeMode = PictureBoxSizeMode.Zoom;
            btnIcon.TabIndex = 0;
            btnIcon.TabStop = false;
            btnIcon.Click += btnIcon_Click;
            // 
            // panelDesktop
            // 
            panelDesktop.Anchor = AnchorStyles.None;
            panelDesktop.Location = new Point(260, 25);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(0, 0);
            panelDesktop.TabIndex = 1;
            // 
            // MenuSelecaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(1264, 681);
            Controls.Add(panelDesktop);
            Controls.Add(menuPanel);
            ForeColor = Color.FromArgb(226, 232, 240);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MenuSelecaoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Suporte Cartsys";
            WindowState = FormWindowState.Maximized;
            Activated += MenuSelecaoForm_Activated;
            Load += MenuPrincipal_Load;
            menuPanel.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnIcon).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private Panel menuPanel;
        private Panel logoPanel;
        private FontAwesome.Sharp.IconButton btnHome;
        private FontAwesome.Sharp.IconButton hqBirdCalculatorBtn;
        private FontAwesome.Sharp.IconButton firebirdHqbirdBtn;
        private FontAwesome.Sharp.IconButton configsHandlerBtn;
        private FontAwesome.Sharp.IconButton servicesHandlerBtn;
        private PictureBox btnIcon;
        private Panel panelDesktop;
        private FontAwesome.Sharp.IconButton btnBackupRestore;
    }
}