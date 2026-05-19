namespace CartsysControlPanel.Views
{
    partial class MenuPrincipal
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
            menuPanel = new Panel();
            hqBirdCalculator = new FontAwesome.Sharp.IconButton();
            firebirdHqbird = new FontAwesome.Sharp.IconButton();
            networkHandler = new FontAwesome.Sharp.IconButton();
            servicesHandler = new FontAwesome.Sharp.IconButton();
            regeditButton = new FontAwesome.Sharp.IconButton();
            logoPanel = new Panel();
            btnHome = new PictureBox();
            panel1 = new Panel();
            menuPanel.SuspendLayout();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHome).BeginInit();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.FromArgb(30, 42, 56);
            menuPanel.Controls.Add(hqBirdCalculator);
            menuPanel.Controls.Add(firebirdHqbird);
            menuPanel.Controls.Add(networkHandler);
            menuPanel.Controls.Add(servicesHandler);
            menuPanel.Controls.Add(regeditButton);
            menuPanel.Controls.Add(logoPanel);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(220, 631);
            menuPanel.TabIndex = 0;
            // 
            // hqBirdCalculator
            // 
            hqBirdCalculator.Dock = DockStyle.Top;
            hqBirdCalculator.FlatAppearance.BorderSize = 0;
            hqBirdCalculator.FlatStyle = FlatStyle.Flat;
            hqBirdCalculator.ForeColor = Color.FromArgb(226, 232, 240);
            hqBirdCalculator.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            hqBirdCalculator.IconColor = Color.FromArgb(100, 116, 139);
            hqBirdCalculator.IconFont = FontAwesome.Sharp.IconFont.Auto;
            hqBirdCalculator.IconSize = 32;
            hqBirdCalculator.ImageAlign = ContentAlignment.MiddleLeft;
            hqBirdCalculator.Location = new Point(0, 380);
            hqBirdCalculator.Name = "hqBirdCalculator";
            hqBirdCalculator.Padding = new Padding(10, 0, 20, 0);
            hqBirdCalculator.Size = new Size(220, 60);
            hqBirdCalculator.TabIndex = 6;
            hqBirdCalculator.Text = "Calculadora HQBird";
            hqBirdCalculator.TextAlign = ContentAlignment.MiddleLeft;
            hqBirdCalculator.TextImageRelation = TextImageRelation.ImageBeforeText;
            hqBirdCalculator.UseVisualStyleBackColor = true;
            hqBirdCalculator.Click += hqBirdCalculator_Click;
            // 
            // firebirdHqbird
            // 
            firebirdHqbird.Dock = DockStyle.Top;
            firebirdHqbird.FlatAppearance.BorderSize = 0;
            firebirdHqbird.FlatStyle = FlatStyle.Flat;
            firebirdHqbird.ForeColor = Color.FromArgb(226, 232, 240);
            firebirdHqbird.IconChar = FontAwesome.Sharp.IconChar.Database;
            firebirdHqbird.IconColor = Color.FromArgb(100, 116, 139);
            firebirdHqbird.IconFont = FontAwesome.Sharp.IconFont.Auto;
            firebirdHqbird.IconSize = 32;
            firebirdHqbird.ImageAlign = ContentAlignment.MiddleLeft;
            firebirdHqbird.Location = new Point(0, 320);
            firebirdHqbird.Name = "firebirdHqbird";
            firebirdHqbird.Padding = new Padding(10, 0, 20, 0);
            firebirdHqbird.Size = new Size(220, 60);
            firebirdHqbird.TabIndex = 4;
            firebirdHqbird.Text = "Firebird/HQbird";
            firebirdHqbird.TextAlign = ContentAlignment.MiddleLeft;
            firebirdHqbird.TextImageRelation = TextImageRelation.ImageBeforeText;
            firebirdHqbird.UseVisualStyleBackColor = true;
            firebirdHqbird.Click += firebirdHqbird_Click;
            // 
            // networkHandler
            // 
            networkHandler.Dock = DockStyle.Top;
            networkHandler.FlatAppearance.BorderSize = 0;
            networkHandler.FlatStyle = FlatStyle.Flat;
            networkHandler.ForeColor = Color.FromArgb(226, 232, 240);
            networkHandler.IconChar = FontAwesome.Sharp.IconChar.NetworkWired;
            networkHandler.IconColor = Color.FromArgb(100, 116, 139);
            networkHandler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            networkHandler.IconSize = 32;
            networkHandler.ImageAlign = ContentAlignment.MiddleLeft;
            networkHandler.Location = new Point(0, 260);
            networkHandler.Name = "networkHandler";
            networkHandler.Padding = new Padding(10, 0, 20, 0);
            networkHandler.Size = new Size(220, 60);
            networkHandler.TabIndex = 3;
            networkHandler.Text = "Rede";
            networkHandler.TextAlign = ContentAlignment.MiddleLeft;
            networkHandler.TextImageRelation = TextImageRelation.ImageBeforeText;
            networkHandler.UseVisualStyleBackColor = true;
            networkHandler.Click += networkHandler_Click;
            // 
            // servicesHandler
            // 
            servicesHandler.Dock = DockStyle.Top;
            servicesHandler.FlatAppearance.BorderSize = 0;
            servicesHandler.FlatStyle = FlatStyle.Flat;
            servicesHandler.ForeColor = Color.FromArgb(226, 232, 240);
            servicesHandler.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            servicesHandler.IconColor = Color.FromArgb(100, 116, 139);
            servicesHandler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            servicesHandler.IconSize = 32;
            servicesHandler.ImageAlign = ContentAlignment.MiddleLeft;
            servicesHandler.Location = new Point(0, 200);
            servicesHandler.Name = "servicesHandler";
            servicesHandler.Padding = new Padding(10, 0, 20, 0);
            servicesHandler.Size = new Size(220, 60);
            servicesHandler.TabIndex = 2;
            servicesHandler.Text = "Serviços";
            servicesHandler.TextAlign = ContentAlignment.MiddleLeft;
            servicesHandler.TextImageRelation = TextImageRelation.ImageBeforeText;
            servicesHandler.UseVisualStyleBackColor = true;
            servicesHandler.Click += servicesHandler_Click;
            // 
            // regeditButton
            // 
            regeditButton.Dock = DockStyle.Top;
            regeditButton.FlatAppearance.BorderSize = 0;
            regeditButton.FlatStyle = FlatStyle.Flat;
            regeditButton.ForeColor = Color.FromArgb(226, 232, 240);
            regeditButton.IconChar = FontAwesome.Sharp.IconChar.Tools;
            regeditButton.IconColor = Color.FromArgb(100, 116, 139);
            regeditButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            regeditButton.IconSize = 32;
            regeditButton.ImageAlign = ContentAlignment.MiddleLeft;
            regeditButton.Location = new Point(0, 140);
            regeditButton.Name = "regeditButton";
            regeditButton.Padding = new Padding(10, 0, 20, 0);
            regeditButton.Size = new Size(220, 60);
            regeditButton.TabIndex = 1;
            regeditButton.Text = "Editor de Registro";
            regeditButton.TextAlign = ContentAlignment.MiddleLeft;
            regeditButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            regeditButton.UseVisualStyleBackColor = true;
            regeditButton.Click += regeditButton_Click;
            // 
            // logoPanel
            // 
            logoPanel.Controls.Add(btnHome);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(220, 140);
            logoPanel.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.Image = Properties.Resources.Cartsys_logo;
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(220, 140);
            btnHome.SizeMode = PictureBoxSizeMode.Zoom;
            btnHome.TabIndex = 0;
            btnHome.TabStop = false;
            btnHome.Click += btnHome_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 42, 56);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(220, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(964, 100);
            panel1.TabIndex = 1;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 25, 44);
            ClientSize = new Size(1184, 631);
            Controls.Add(panel1);
            Controls.Add(menuPanel);
            Name = "MenuPrincipal";
            Text = "Form2";
            menuPanel.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnHome).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel menuPanel;
        private Panel logoPanel;
        private FontAwesome.Sharp.IconButton regeditButton;
        private FontAwesome.Sharp.IconButton hqBirdCalculator;
        private FontAwesome.Sharp.IconButton firebirdHqbird;
        private FontAwesome.Sharp.IconButton networkHandler;
        private FontAwesome.Sharp.IconButton servicesHandler;
        private PictureBox btnHome;
        private Panel panel1;
    }
}