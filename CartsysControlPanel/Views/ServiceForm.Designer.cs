namespace CartsysControlPanel.Views
{
    partial class ServiceForm
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
            panelServicos = new FlowLayoutPanel();
            panelActions = new Panel();
            btnUninstallAll = new Button();
            btnInstall = new Button();
            btnInstallAll = new Button();
            btnUninstall = new Button();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelServicos
            // 
            panelServicos.AutoScroll = true;
            panelServicos.BackColor = Color.FromArgb(17, 24, 39);
            panelServicos.Dock = DockStyle.Left;
            panelServicos.FlowDirection = FlowDirection.TopDown;
            panelServicos.Location = new Point(0, 0);
            panelServicos.MaximumSize = new Size(280, 0);
            panelServicos.MinimumSize = new Size(280, 280);
            panelServicos.Name = "panelServicos";
            panelServicos.Size = new Size(280, 450);
            panelServicos.TabIndex = 2;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(17, 24, 39);
            panelActions.Controls.Add(btnUninstallAll);
            panelActions.Controls.Add(btnInstall);
            panelActions.Controls.Add(btnInstallAll);
            panelActions.Controls.Add(btnUninstall);
            panelActions.Dock = DockStyle.Fill;
            panelActions.Location = new Point(280, 0);
            panelActions.MaximumSize = new Size(280, 1080);
            panelActions.MinimumSize = new Size(280, 280);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(280, 450);
            panelActions.TabIndex = 3;
            panelActions.Resize += panelActions_Resize;
            // 
            // btnUninstallAll
            // 
            btnUninstallAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnUninstallAll.BackColor = Color.FromArgb(127, 29, 29);
            btnUninstallAll.FlatAppearance.BorderSize = 0;
            btnUninstallAll.FlatStyle = FlatStyle.Flat;
            btnUninstallAll.ForeColor = Color.FromArgb(226, 232, 240);
            btnUninstallAll.Location = new Point(43, 267);
            btnUninstallAll.Name = "btnUninstallAll";
            btnUninstallAll.Size = new Size(200, 40);
            btnUninstallAll.TabIndex = 7;
            btnUninstallAll.Text = "Desinstalar Todos";
            btnUninstallAll.UseVisualStyleBackColor = false;
            btnUninstallAll.Click += btnUninstallAll_Click;
            // 
            // btnInstall
            // 
            btnInstall.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnInstall.BackColor = Color.FromArgb(20, 83, 45);
            btnInstall.FlatAppearance.BorderSize = 0;
            btnInstall.FlatStyle = FlatStyle.Flat;
            btnInstall.ForeColor = Color.FromArgb(226, 232, 240);
            btnInstall.Location = new Point(43, 92);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(200, 40);
            btnInstall.TabIndex = 4;
            btnInstall.Text = "Instalar serviço";
            btnInstall.UseVisualStyleBackColor = false;
            btnInstall.Click += btnInstall_Click;
            // 
            // btnInstallAll
            // 
            btnInstallAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnInstallAll.BackColor = Color.FromArgb(20, 83, 45);
            btnInstallAll.FlatAppearance.BorderSize = 0;
            btnInstallAll.FlatStyle = FlatStyle.Flat;
            btnInstallAll.ForeColor = Color.FromArgb(226, 232, 240);
            btnInstallAll.Location = new Point(43, 221);
            btnInstallAll.Name = "btnInstallAll";
            btnInstallAll.Size = new Size(200, 40);
            btnInstallAll.TabIndex = 6;
            btnInstallAll.Text = "Instalar Todos";
            btnInstallAll.UseVisualStyleBackColor = false;
            btnInstallAll.Click += btnInstallAll_Click;
            // 
            // btnUninstall
            // 
            btnUninstall.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnUninstall.BackColor = Color.FromArgb(127, 29, 29);
            btnUninstall.FlatAppearance.BorderSize = 0;
            btnUninstall.FlatStyle = FlatStyle.Flat;
            btnUninstall.ForeColor = Color.FromArgb(226, 232, 240);
            btnUninstall.Location = new Point(43, 138);
            btnUninstall.Name = "btnUninstall";
            btnUninstall.Size = new Size(200, 40);
            btnUninstall.TabIndex = 5;
            btnUninstall.Text = "Desinstalar Serviço";
            btnUninstall.UseVisualStyleBackColor = false;
            btnUninstall.Click += btnUninstall_Click;
            // 
            // ServiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(800, 450);
            Controls.Add(panelActions);
            Controls.Add(panelServicos);
            Name = "ServiceForm";
            Text = "ServiceForm";
            Load += ServiceForm_Load;
            Shown += ServiceForm_Shown;
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel panelServicos;
        private Panel panelActions;
        private Button btnInstall;
        private Button btnUninstall;
        private Button btnInstallAll;
        private Button btnUninstallAll;
    }
}