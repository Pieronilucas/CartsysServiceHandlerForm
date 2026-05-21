using CartsysControlPanel.Infrastructure.System;
using CartsysControlPanel.Logging;
using System.ComponentModel;

namespace CartsysControlPanel.Views
{


    public partial class ServiceForm : Form
    {

        private Panel _selectedPanel;
        private int _selectedService = -1;
        private static readonly Color _colorInactive = Color.FromArgb(30, 42, 56);
        private static readonly Color _colorActive = Color.FromArgb(30, 58, 95);
        private static readonly Color _colorText = Color.FromArgb(226, 232, 240);





        private static readonly Dictionary<int, (string name, Image Icone)> _serviceNames = new()
    {
        {1, ("Executa", Properties.Resources.cartsysIco)},
        {2, ("Guardian", Properties.Resources.guardian)},
        {3, ("Notificação", Properties.Resources.notificacao)},
        {4, ("NFS-e", Properties.Resources.nfs)},
        {5, ("Tarefas", Properties.Resources.tarefas)},
        {6, ("WhatsApp", Properties.Resources.cartsysIco)},
        {7, ("Update", Properties.Resources.cartsysIco)},
        {8, ("Parcela Express", Properties.Resources.cartsysIco)},
        {9, ("SignalR Cliente", Properties.Resources.signalr)},
        {10, ("Alertas", Properties.Resources.cartsysIco)}
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

        private void CenterActionButtons()
        {
            int centerX = panelActions.Width / 2;
            int centerY = panelActions.Height / 2;

            int btnWidth = 200;
            int btnHeight = 40;
            int spacing = 10;
            int separatorHeight = 20;

            // bloco individual (instalar + desinstalar)
            int individualBlockHeight = (btnHeight * 2) + spacing;
            // bloco todos (instalar todos + desinstalar todos)  
            int todosBlockHeight = (btnHeight * 2) + spacing;
            // altura total incluindo separador
            int totalHeight = individualBlockHeight + separatorHeight + todosBlockHeight;

            int startY = centerY - (totalHeight / 2);

            btnInstall.Size = new Size(btnWidth, btnHeight);
            btnInstall.Location = new Point(centerX - btnWidth / 2, startY);

            btnUninstall.Size = new Size(btnWidth, btnHeight);
            btnUninstall.Location = new Point(centerX - btnWidth / 2, startY + btnHeight + spacing);

            btnInstallAll.Size = new Size(btnWidth, btnHeight);
            btnInstallAll.Location = new Point(centerX - btnWidth / 2, startY + individualBlockHeight + separatorHeight);

            btnUninstallAll.Size = new Size(btnWidth, btnHeight);
            btnUninstallAll.Location = new Point(centerX - btnWidth / 2, startY + individualBlockHeight + separatorHeight + btnHeight + spacing);
        }


        private void ServiceForm_Load(object sender, EventArgs e)
        {
            LoadServiceButtons();
            InitActionPanel();
        }

        private void ServiceForm_Shown(object sender, EventArgs e)
        {
            CenterServiceList();
            CenterActionButtons();
        }

        private void ServiceForm_Resize(object sender, EventArgs e)
        {
            CenterServiceList();
        }

        private void InitActionPanel()
        {
            btnInstall.Enabled = false;
            btnUninstall.Enabled = false;
            btnInstall.Size = new Size(200, 40);
            btnUninstall.Size = new Size(200, 40);
            btnInstallAll.Size = new Size(200, 40);
            btnUninstallAll.Size = new Size(200, 40);
        }
        private void LoadServiceButtons()
        {

            foreach (var service in _serviceNames)
            {
                var panel = CreateServiceButton(service.Value.name, service.Key);
                panelServicos.Controls.Add(panel);
            }
        }

        private Panel CreateServiceButton(string serviceName, int option)
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

            panel.Controls.Add(icon);
            panel.Controls.Add(label);

            foreach (Control c in new Control[] { panel, icon, label })
            {
                c.MouseEnter += ServiceBtn_MouseEnter;
                c.MouseLeave += ServiceBtn_MouseLeave;
                c.Click += ServiceBtn_Click;
            }

            return panel;
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

        private void panelActions_Resize(object sender, EventArgs e)
        {
            CenterActionButtons();
        }

        private async void btnInstallAll_Click(object sender, EventArgs e)
        {
            btnInstallAll.Text = "Instalando...";
            btnInstallAll.Enabled = false;
            await Task.Run(() =>
            {

                try
                {
                    ServiceHandler.ServiceInstallAll();
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
            });

            btnInstallAll.Text = "Instalar Todos";
            btnInstallAll.Enabled = true;
        }

        private async void btnUninstallAll_Click(object sender, EventArgs e)
        {
            btnUninstallAll.Text = "Desinstalando...";
            btnUninstallAll.Enabled = false;

            await Task.Run(() =>
            {
                try
                {
                    ServiceHandler.ServiceUninstallAll();
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
            });
            btnUninstallAll.Enabled = true;
            btnUninstallAll.Text = "Desinstalar Todos";
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            btnInstall.Text = "Instalando...";
            btnInstall.Enabled = false;
            await Task.Run(() =>
            {
                try
                {
                    ServiceHandler.ServiceInstaller(_selectedService);
                    MessageBox.Show("Serviço instalado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            });
            btnInstall.Enabled = true;
            btnInstall.Text = "Instalar Serviço";

        }

        private async void btnUninstall_Click(object sender, EventArgs e)
        {
            btnUninstall.Text = "Desinstalando...";
            btnUninstall.Enabled = false;
            await Task.Run(() =>
            {
                try
                {
                    ServiceHandler.ServiceUninstaller(_selectedService);
                    MessageBox.Show("Serviço desinstalado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Win32Exception wEx)
                {
                    MessageBox.Show($"Erro de sistema ao tentar desinstalar o serviço: {wEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao tentar desinstalar o serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            btnUninstall.Enabled = true;
            btnUninstall.Text = "Desinstalar Serviço";

        }

        private void panelServicos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
