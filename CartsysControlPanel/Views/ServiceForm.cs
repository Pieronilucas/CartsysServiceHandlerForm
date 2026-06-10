using CartsysControlPanel.Infrastructure.System;
using CartsysControlPanel.Logging;
using System.ComponentModel;
using static CartsysControlPanel.Infrastructure.System.ServiceHandler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CartsysControlPanel.Views
{


    public partial class ServiceForm : Form
    {

        private Panel _selectedPanel;
        private int _selectedService = -1;
        private static readonly Color _colorInactive = Color.FromArgb(30, 42, 56);
        private static readonly Color _colorActive = Color.FromArgb(30, 58, 95);
        private static readonly Color _colorText = Color.FromArgb(226, 232, 240);
        public bool IsProcessing { get; private set; }
        public event EventHandler ProcessingChanged;




        private static readonly Dictionary<int, (string name, Image Icone)> _serviceNames = new()
    {
        {1, ("Executa", Properties.Resources.cartsys)},
        {2, ("Guardian", Properties.Resources.guardian)},
        {3, ("Notificação", Properties.Resources.notificacao)},
        {4, ("NFS-e", Properties.Resources.nfs)},
        {5, ("Tarefas", Properties.Resources.tarefas)},
        {6, ("WhatsApp", Properties.Resources.cartsys)},
        {7, ("Update", Properties.Resources.cartsys)},
        {8, ("Parcela Express", Properties.Resources.cartsys)},
        {9, ("SignalR Cliente", Properties.Resources.signalr)},
        {10, ("Alertas", Properties.Resources.cartsys)}
    };
        public ServiceForm()
        {
            InitializeComponent();
        }
        private void CenterServiceList()
        {
            int itemHeight = 56 + 4; // height + margin
            int totalHeight = _serviceNames.Count * itemHeight;
            int topPadding = Math.Max(0, (panelServicos.Height - totalHeight) / 2);
            panelServicos.Padding = new Padding(0, topPadding, 0, 0);
        }
        private void ServiceForm_Shown(object sender, EventArgs e)
        {
            ResetButtonPositions();
            CenterServiceList();
            CenterActionButtons();
        }
        private void panelActions_Resize(object sender, EventArgs e)
        {
            ResetButtonPositions();
            CenterActionButtons();
        }
        private void CenterActionButtons()
        {


            int btnWidth = 200;
            int btnHeight = 40;
            int spacing = 20;
            int margin = 20;
            int separatorHeight = 30;
            int labelHeight = 20;

            int col1x = margin;
            int col2x = (panelActions.Width / 2) + margin;

            int blockHeight = labelHeight + 5 + btnHeight + spacing + btnHeight;
            int startY = panelActions.Height / 2 - blockHeight / 2;

            label1.Size = new Size(btnWidth, btnHeight);
            label1.Location = new Point(col1x, startY);

            btnInstall.Size = new Size(btnWidth, btnHeight);
            btnInstall.Location = new Point(col1x, startY + labelHeight + 5);

            btnUninstall.Size = new Size(btnWidth, btnHeight);
            btnUninstall.Location = new Point(col1x, startY + labelHeight + 5 + btnHeight + spacing);

            btnInitService.Size = new Size(btnWidth, btnHeight);
            btnInitService.Location = new Point(col1x, startY + labelHeight + 5 + (btnHeight + spacing) * 2);

            label2.Size = new Size(btnWidth, btnHeight);
            label2.Location = new Point(col2x, startY);

            btnInstallAll.Size = new Size(btnWidth, btnHeight);
            btnInstallAll.Location = new Point(col2x, startY + labelHeight + 5);

            btnUninstallAll.Size = new Size(btnWidth, btnHeight);
            btnUninstallAll.Location = new Point(col2x, startY + labelHeight + 5 + btnHeight + spacing);

            btnInitAllServices.Size = new Size(btnWidth, btnHeight);
            btnInitAllServices.Location = new Point(col2x, startY + labelHeight + 5 + (btnHeight + spacing) * 2);

            btnReboot.Size = new Size(btnWidth, btnHeight);
            btnReboot.Location = new Point(panelActions.Width / 2 - btnWidth / 2, startY + blockHeight + separatorHeight + btnHeight + 5);

        }
        private void ResetButtonPositions()
        {
            foreach (Control c in new Control[] {
        btnInstall, btnUninstall, btnInstallAll,
        btnUninstallAll, btnReboot, label1, label2 })
            {
                c.Location = new Point(0, 0);
                c.Anchor = AnchorStyles.None;
            }
        }


        private void ServiceForm_Load(object sender, EventArgs e)
        {
            LoadServiceButtons();
            InitActionPanel();
        }
        private void ServiceForm_Resize(object sender, EventArgs e)
        {
            CenterServiceList();
        }

        private void InitActionPanel()
        {
            btnInstall.Enabled = false;
            btnUninstall.Enabled = false;
            btnReboot.Enabled = true;
            btnInstall.Size = new Size(200, 40);
            btnUninstall.Size = new Size(200, 40);
            btnInstallAll.Size = new Size(200, 40);
            btnUninstallAll.Size = new Size(200, 40);
            btnReboot.Size = new Size(200, 40);
        }
        private void LoadServiceButtons()
        {

            foreach (var service in _serviceNames)
            {
                var status = ServiceHandler.GetServiceStatus(service.Key);
                var panel = CreateServiceButton(service.Value.name, service.Key, status);
                panelServicos.Controls.Add(panel);
            }
        }
        private static string GetStatusText(ServiceStatus status) => status switch
        {
            ServiceStatus.Running => "● Rodando",
            ServiceStatus.Stopped => "● Parado",
            ServiceStatus.NotInstalled => "○ Não instalado",
            _ => ""
        };

        private static Color GetStatusColor(ServiceStatus status) => status switch
        {
            ServiceStatus.Running => Color.FromArgb(74, 222, 128),  // verde
            ServiceStatus.Stopped => Color.FromArgb(248, 113, 113), // vermelho
            ServiceStatus.NotInstalled => Color.FromArgb(100, 116, 139), // cinza
            _ => Color.White
        };

        private Panel CreateServiceButton(string serviceName, int option, ServiceStatus status)
        {
            var panel = new Panel
            {
                Width = panelServicos.Width - 4,
                Height = 56,
                BackColor = Color.FromArgb(30, 42, 56),
                Cursor = Cursors.Hand,
                Tag = option,
                Margin = new Padding(2)
            };

            var icon = new PictureBox
            {
                Size = new Size(32, 32),
                Location = new Point(12, 12),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Image = _serviceNames[option].Icone
            };

            var label = new Label
            {
                Text = serviceName,
                ForeColor = _colorText,
                Location = new Point(54, 17),
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 10f)
            };

            var statusLabel = new Label
            {
                Name = "statusLabel",
                Text = GetStatusText(status),
                ForeColor = GetStatusColor(status),
                Location = new Point(panel.Width - 100, 20),
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9f)
            };


            panel.Controls.Add(icon);
            panel.Controls.Add(label);
            panel.Controls.Add(statusLabel);

            foreach (Control c in new Control[] { panel, icon, label })
            {
                c.MouseEnter += ServiceBtn_MouseEnter;
                c.MouseLeave += ServiceBtn_MouseLeave;
                c.Click += ServiceBtn_Click;
            }



            return panel;
        }

        private void DisableAllButtons()
        {
            btnInstallAll.Enabled = false;
            btnUninstallAll.Enabled = false;
            btnInstall.Enabled = false;
            btnUninstall.Enabled = false;
            btnReboot.Enabled = false;
            btnInitAllServices.Enabled = false;
            btnInitService.Enabled = false;
        }

        private void EnableAllButtons()
        {
            btnInstallAll.Enabled = true;
            btnUninstallAll.Enabled = true;
            btnInstall.Enabled = _selectedService != -1;
            btnUninstall.Enabled = _selectedService != -1;
            btnReboot.Enabled = _selectedService != -1;
            btnInitAllServices.Enabled = true;
            btnInitService.Enabled = _selectedService != -1;
        }


        private Panel GetPanel(object sender) =>
            sender is Panel p ? p : (Panel)((Control)sender).Parent;

        private void ServiceBtn_MouseEnter(object sender, EventArgs e)
        {
            var panel = GetPanel(sender);
            if ((int)panel.Tag != _selectedService)
                panel.BackColor = Color.FromArgb(20, 50, 80);
        }

        private void ServiceBtn_MouseLeave(object sender, EventArgs e)
        {
            var panel = GetPanel(sender);
            if (!panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)))
                if ((int)panel.Tag != _selectedService)
                    panel.BackColor = _colorInactive;
        }

        private void ServiceBtn_Click(object sender, EventArgs e)
        {
            var panel = GetPanel(sender);
            int option = (int)panel.Tag;

            // deseleciona o anterior
            if (_selectedPanel != null)
                _selectedPanel.BackColor = _colorInactive;

            _selectedService = option;
            _selectedPanel = panel;
            panel.BackColor = _colorActive;
            btnInstall.Enabled = true;
            btnUninstall.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private async Task RefreshStatus()
        {
            foreach (Control ctrl in panelServicos.Controls)
            {
                if (ctrl is not Panel p) continue;
                int option = (int)p.Tag;

                ServiceStatus status = ServiceHandler.GetServiceStatus(option);

                var statuslabel = p.Controls.OfType<Label>()
                    .FirstOrDefault(l => l.Name == "statusLabel");

                if (statuslabel != null)
                {
                    statuslabel.Text = GetStatusText(status);
                    statuslabel.ForeColor = GetStatusColor(status);
                }
            }
        }

        private async void btnInstallAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja instalar TODOS os serviços? Esta ação pode levar alguns minutos e requer privilégios de administrador.", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            SetProcessing(true);
            btnInstallAll.Text = "Instalando...";
            DisableAllButtons();



            try
            {
                await ServiceHandler.ServiceInstallAll();
                MessageBox.Show("Todos os serviços foram instalados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception ex) when (ex.NativeErrorCode == 5) // Erro de Acesso Negado
            {
                MessageBox.Show("Acesso negado. Por favor, execute o painel de controle como administrador para instalar o serviço.", "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Win32Exception wEx)
            {
                MessageBox.Show($"Erro de sistema ao tentar instalar o serviço: {wEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar instalar o serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnInstallAll.Text = "Instalar Todos os Serviços";
            EnableAllButtons();
            SetProcessing(false);
            RefreshStatus();
        }

        private async void btnUninstallAll_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Tem certeza que deseja instalar TODOS os serviços? Esta ação pode levar alguns minutos e requer privilégios de administrador.", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            SetProcessing(true);
            DisableAllButtons();
            btnUninstallAll.Text = "Desinstalando...";

            try
            {
                await ServiceHandler.ServiceUninstallAll();
                MessageBox.Show("Todos os serviços foram desinstalados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception wEx)
            {
                MessageBox.Show($"Erro de sistema ao tentar desinstalar o serviço: {wEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar desinstalar o serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnUninstallAll.Text = "Desinstalar Todos os Serviços";
            EnableAllButtons();
            SetProcessing(false);
            RefreshStatus();
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            SetProcessing(true);
            DisableAllButtons();

            try
            {
                await ServiceHandler.ServiceInstaller(_selectedService);
                MessageBox.Show("Serviço instalado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception ex) when (ex.NativeErrorCode == 5) // Erro de Acesso Negado
            {
                MessageBox.Show("Acesso negado. Por favor, execute o painel de controle como administrador para instalar o serviço.", "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Win32Exception wEx)
            {
                MessageBox.Show($"Erro de sistema ao tentar instalar o serviço: {_serviceNames[_selectedService].name}. {wEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"correu um erro ao tentar instalar o serviço: {_serviceNames[_selectedService].name}. {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            EnableAllButtons();
            btnInstall.Text = "Instalar Serviço Selecionado";
            SetProcessing(false);
            RefreshStatus();
        }

        private async void btnUninstall_Click(object sender, EventArgs e)
        {
            SetProcessing(true);
            btnUninstall.Text = "Desinstalando...";
            btnInstallAll.Enabled = false;
            btnUninstallAll.Enabled = false;
            btnInstall.Enabled = false;
            btnUninstall.Enabled = false;
            btnReboot.Enabled = false;
            try
            {
                await ServiceHandler.ServiceUninstaller(_selectedService);
                MessageBox.Show("Serviço desinstalado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception wEx)
            {
                MessageBox.Show($"Erro de sistema ao tentar desinstalar o serviço: {_serviceNames[_selectedService].name}. {wEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar desinstalar o serviço: {_serviceNames[_selectedService].name}. {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            btnInstallAll.Enabled = true;
            btnUninstallAll.Enabled = true;
            btnInstall.Enabled = _selectedService != -1;
            btnUninstall.Enabled = _selectedService != -1;
            btnReboot.Enabled = _selectedService != -1;
            btnUninstall.Text = "Desinstalar Serviço Selecionado";
            SetProcessing(false);
            RefreshStatus();

        }

        private void panelServicos_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SetProcessing(true);
            DisableAllButtons();
            btnReboot.Text = "Reiniciando...";
            await Task.Run(() =>
            {
                try
                {
                    ServiceHandler.SetAllToRestart();
                    MessageBox.Show("Todos os serviços configurados para reiniciar em caso de falha.", "Configuração Aplicada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao tentar configurar os serviços: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            EnableAllButtons();
            btnReboot.Text = "Colocar serviços para reinicializar";
        }

        private void SetProcessing(bool value)
        {
            if (IsProcessing != value)
            {
                IsProcessing = value;
                ProcessingChanged?.Invoke(this, EventArgs.Empty);
            }
        }


        private void panelActions_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnInitService_Click(object sender, EventArgs e)
        {
            DisableAllButtons();
            btnInitService.Text = "Inicializando...";
            try
            {
                await ServiceHandler.InitServices(_selectedService);
                MessageBox.Show("Serviço inicializado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception wEx)
            {
                MessageBox.Show($"Erro de sistema ao tentar inicializar o serviço: {_serviceNames[_selectedService].name}. {wEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar inicializar o serviço: {_serviceNames[_selectedService].name}. {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnInitService.Text = "Inicializar Serviço Selecionado";
            EnableAllButtons();
            RefreshStatus();
        }

        private async void btnInitAllServices_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja inicializar TODOS os serviços? Esta ação pode levar alguns minutos e requer privilégios de administrador.", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            DisableAllButtons();
            btnInitAllServices.Text = "Inicializando...";
            try
            {
                await ServiceHandler.InitAllServices();
                MessageBox.Show("Todos os serviços inicializados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Win32Exception wEx)
            {
                MessageBox.Show($"Erro de sistema ao tentar inicializar os serviços: {wEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar inicializar os serviços: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnInitAllServices.Text = "Inicializar Todos os Serviços";
            EnableAllButtons();
            RefreshStatus();
        }
    }
}
