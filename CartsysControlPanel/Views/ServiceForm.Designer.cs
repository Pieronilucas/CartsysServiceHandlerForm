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
            radioImoveis = new RadioButton();
            radioNotas = new RadioButton();
            panelActions = new Panel();
            btnStopService = new Button();
            btnStopAll = new Button();
            btnInitAllServices = new Button();
            btnInitService = new Button();
            label2 = new Label();
            label1 = new Label();
            btnReboot = new Button();
            btnUninstallAll = new Button();
            btnInstall = new Button();
            btnInstallAll = new Button();
            btnUninstall = new Button();
            panelServicos.SuspendLayout();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelServicos
            // 
            panelServicos.AutoScroll = true;
            panelServicos.BackColor = Color.FromArgb(17, 24, 39);
            panelServicos.Controls.Add(radioImoveis);
            panelServicos.Controls.Add(radioNotas);
            panelServicos.Dock = DockStyle.Left;
            panelServicos.FlowDirection = FlowDirection.TopDown;
            panelServicos.Location = new Point(0, 0);
            panelServicos.MaximumSize = new Size(280, 0);
            panelServicos.MinimumSize = new Size(280, 280);
            panelServicos.Name = "panelServicos";
            panelServicos.Size = new Size(280, 681);
            panelServicos.TabIndex = 2;
            panelServicos.Paint += panelServicos_Paint;
            // 
            // radioImoveis
            // 
            radioImoveis.AutoSize = true;
            radioImoveis.ForeColor = Color.FromArgb(226, 232, 240);
            radioImoveis.Location = new Point(3, 3);
            radioImoveis.Name = "radioImoveis";
            radioImoveis.Size = new Size(66, 19);
            radioImoveis.TabIndex = 0;
            radioImoveis.TabStop = true;
            radioImoveis.Text = "Imóveis";
            radioImoveis.UseVisualStyleBackColor = true;
            radioImoveis.CheckedChanged += radioImoveis_CheckedChanged;
            // 
            // radioNotas
            // 
            radioNotas.AutoSize = true;
            radioNotas.ForeColor = Color.FromArgb(226, 232, 240);
            radioNotas.Location = new Point(3, 28);
            radioNotas.Name = "radioNotas";
            radioNotas.Size = new Size(56, 19);
            radioNotas.TabIndex = 15;
            radioNotas.TabStop = true;
            radioNotas.Text = "Notas";
            radioNotas.UseVisualStyleBackColor = true;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(17, 24, 39);
            panelActions.Controls.Add(btnStopService);
            panelActions.Controls.Add(btnStopAll);
            panelActions.Controls.Add(btnInitAllServices);
            panelActions.Controls.Add(btnInitService);
            panelActions.Controls.Add(label2);
            panelActions.Controls.Add(label1);
            panelActions.Controls.Add(btnReboot);
            panelActions.Controls.Add(btnUninstallAll);
            panelActions.Controls.Add(btnInstall);
            panelActions.Controls.Add(btnInstallAll);
            panelActions.Controls.Add(btnUninstall);
            panelActions.Dock = DockStyle.Fill;
            panelActions.Location = new Point(280, 0);
            panelActions.MaximumSize = new Size(480, 1080);
            panelActions.MinimumSize = new Size(480, 480);
            panelActions.Name = "panelActions";
            panelActions.Size = new Size(480, 681);
            panelActions.TabIndex = 3;
            panelActions.Resize += panelActions_Resize;
            // 
            // btnStopService
            // 
            btnStopService.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnStopService.BackColor = Color.FromArgb(146, 64, 14);
            btnStopService.FlatAppearance.BorderSize = 0;
            btnStopService.FlatStyle = FlatStyle.Flat;
            btnStopService.ForeColor = Color.FromArgb(226, 232, 240);
            btnStopService.Location = new Point(43, 177);
            btnStopService.Name = "btnStopService";
            btnStopService.Size = new Size(400, 40);
            btnStopService.TabIndex = 14;
            btnStopService.Text = "Parar Serviço Selecionado";
            btnStopService.UseVisualStyleBackColor = false;
            btnStopService.Click += btnStopService_Click;
            // 
            // btnStopAll
            // 
            btnStopAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnStopAll.BackColor = Color.FromArgb(146, 64, 14);
            btnStopAll.FlatAppearance.BorderSize = 0;
            btnStopAll.FlatStyle = FlatStyle.Flat;
            btnStopAll.ForeColor = Color.FromArgb(226, 232, 240);
            btnStopAll.Location = new Point(43, 323);
            btnStopAll.Name = "btnStopAll";
            btnStopAll.Size = new Size(400, 40);
            btnStopAll.TabIndex = 13;
            btnStopAll.Text = "Parar Todos os Serviços";
            btnStopAll.UseVisualStyleBackColor = false;
            btnStopAll.Click += btnStopAll_Click;
            // 
            // btnInitAllServices
            // 
            btnInitAllServices.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnInitAllServices.BackColor = Color.FromArgb(30, 58, 95);
            btnInitAllServices.FlatAppearance.BorderSize = 0;
            btnInitAllServices.FlatStyle = FlatStyle.Flat;
            btnInitAllServices.ForeColor = Color.FromArgb(226, 232, 240);
            btnInitAllServices.Location = new Point(43, 369);
            btnInitAllServices.Name = "btnInitAllServices";
            btnInitAllServices.Size = new Size(400, 40);
            btnInitAllServices.TabIndex = 12;
            btnInitAllServices.Text = "Iniciar Todos os Serviço ";
            btnInitAllServices.UseVisualStyleBackColor = false;
            btnInitAllServices.Click += btnInitAllServices_Click;
            // 
            // btnInitService
            // 
            btnInitService.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnInitService.BackColor = Color.FromArgb(30, 58, 95);
            btnInitService.FlatAppearance.BorderSize = 0;
            btnInitService.FlatStyle = FlatStyle.Flat;
            btnInitService.ForeColor = Color.FromArgb(226, 232, 240);
            btnInitService.Location = new Point(43, 131);
            btnInitService.Name = "btnInitService";
            btnInitService.Size = new Size(400, 40);
            btnInitService.TabIndex = 11;
            btnInitService.Text = "Iniciar Serviço Selecionado";
            btnInitService.UseVisualStyleBackColor = false;
            btnInitService.Click += btnInitService_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(226, 232, 240);
            label2.Location = new Point(43, 254);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 10;
            label2.Text = "Todos os serviços ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(226, 232, 240);
            label1.Location = new Point(43, 9);
            label1.Name = "label1";
            label1.Size = new Size(141, 20);
            label1.TabIndex = 9;
            label1.Text = "Serviço selecionado";
            // 
            // btnReboot
            // 
            btnReboot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnReboot.BackColor = Color.FromArgb(212, 175, 55);
            btnReboot.FlatAppearance.BorderSize = 0;
            btnReboot.FlatStyle = FlatStyle.Flat;
            btnReboot.ForeColor = Color.FromArgb(226, 232, 240);
            btnReboot.Location = new Point(43, 482);
            btnReboot.Name = "btnReboot";
            btnReboot.Size = new Size(400, 40);
            btnReboot.TabIndex = 8;
            btnReboot.Text = "Colocar serviços para reinicializar em caso de falha";
            btnReboot.UseVisualStyleBackColor = false;
            btnReboot.Click += btnReboot_Click;
            // 
            // btnUninstallAll
            // 
            btnUninstallAll.Anchor = AnchorStyles.None;
            btnUninstallAll.BackColor = Color.FromArgb(127, 29, 29);
            btnUninstallAll.FlatAppearance.BorderSize = 0;
            btnUninstallAll.FlatStyle = FlatStyle.Flat;
            btnUninstallAll.ForeColor = Color.FromArgb(226, 232, 240);
            btnUninstallAll.Location = new Point(43, 423);
            btnUninstallAll.Name = "btnUninstallAll";
            btnUninstallAll.Size = new Size(400, 40);
            btnUninstallAll.TabIndex = 7;
            btnUninstallAll.Text = "Desinstalar Todos os Serviços";
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
            btnInstall.Location = new Point(43, 39);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(400, 40);
            btnInstall.TabIndex = 4;
            btnInstall.Text = "Instalar Serviço Selecionado";
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
            btnInstallAll.Location = new Point(43, 277);
            btnInstallAll.Name = "btnInstallAll";
            btnInstallAll.Size = new Size(400, 40);
            btnInstallAll.TabIndex = 6;
            btnInstallAll.Text = "Instalar Todos os Serviços";
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
            btnUninstall.Location = new Point(43, 85);
            btnUninstall.Name = "btnUninstall";
            btnUninstall.Size = new Size(400, 40);
            btnUninstall.TabIndex = 5;
            btnUninstall.Text = "Desinstalar Serviço Selecionado";
            btnUninstall.UseVisualStyleBackColor = false;
            btnUninstall.Click += btnUninstall_Click;
            // 
            // ServiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 24, 39);
            ClientSize = new Size(1264, 681);
            Controls.Add(panelActions);
            Controls.Add(panelServicos);
            Name = "ServiceForm";
            Text = "ServiceForm";
            Load += ServiceForm_Load;
            Shown += ServiceForm_Shown;
            panelServicos.ResumeLayout(false);
            panelServicos.PerformLayout();
            panelActions.ResumeLayout(false);
            panelActions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel panelServicos;
        private Panel panelActions;
        private Button btnInstall;
        private Button btnUninstall;
        private Button btnInstallAll;
        private Button btnUninstallAll;
        private Button btnReboot;
        private Label label2;
        private Label label1;
        private Button btnInitService;
        private Button btnInitAllServices;
        private Button btnStopService;
        private Button btnStopAll;
        private RadioButton radioImoveis;
        private RadioButton radioNotas;
    }
}