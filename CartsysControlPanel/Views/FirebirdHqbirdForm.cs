using CartsysControlPanel.Domain;
using CartsysControlPanel.Infrastructure.Network;
using CartsysControlPanel.Logging;
using System.ComponentModel;

namespace CartsysControlPanel.Views
{
    public partial class FirebirdHqbirdForm : Form
    {
        public FirebirdHqbirdForm()
        {
            InitializeComponent();
        }

        private async void btnDirectDownload_Click(object sender, EventArgs e)
        {
            LoggingFile.Info("Iniciando redirecionamento para o link de download direto do Hqbird.");
            btnDirectDownload.Enabled = false;
            bool success = await NetworkHandler.RedirectToHqbird(isDirectDownload: true);
            if (!success)
            {
                LoggingFile.Info("Falha ao redirecionar para o link de download direto do Hqbird.");
                MessageBox.Show("Falha ao abrir o link de download direto do Hqbird.");
            }
            else LoggingFile.Info("Redirecionamento para o link de download direto do Hqbird realizado com sucesso.");
            btnDirectDownload.Enabled = true;

        }

        private async void btnHqbirdPage_Click(object sender, EventArgs e)
        {
            LoggingFile.Info("Iniciando redirecionamento para o link da pagína de download do Hqbird.");
            btnHqbirdPage.Enabled = false;
            bool success = await NetworkHandler.RedirectToHqbird(isDirectDownload: false);
            if (!success)
            {
                LoggingFile.Info("Falha ao redirecionar para o link da pagína de download do Hqbird.");
                MessageBox.Show("Falha ao abrir o link da página de download do Hqbird.");
            }
            else LoggingFile.Info("Redirecionamento para o link da página de download do Hqbird realizado com sucesso.");

            btnHqbirdPage.Enabled = true;
        }

        private async void btnFirebirdInstall_Click(object sender, EventArgs e)
        {
            LoggingFile.Info("Iniciando instalação do Firebird.");
            btnFirebirdInstall.Enabled = false;
            btnFirebirdInstall.Text = "Instalando...";
            await Task.Run(() => DependencyManager.InstallFirebird());
            btnFirebirdInstall.Enabled = true;
            btnFirebirdInstall.Text = "Instalar Firebird";
        }

        private async void btnFirebirdConfig_Click(object sender, EventArgs e)
        {
            LoggingFile.Info("Iniciando configuração do 'firebird.conf'.");
            btnFirebirdConfig.Enabled = false;
            btnFirebirdConfig.Text = "Configurando...";
            await Task.Run((() =>
            {
                try
                {
                    DependencyManager.SetFirebirdConfig();
                    LoggingFile.Info("Configuração do 'firebird.conf' concluída com sucesso.");
                    Invoke(() =>
                   MessageBox.Show("Configuração do 'firebird.conf' concluída com sucesso."));
                }
                catch (IOException iEx)
                {
                    Invoke(() =>
                   MessageBox.Show($"Falha de I/O ao configurar 'firebird.conf'. Detalhes: {iEx.Message}"));
                }
                catch (Exception ex)
                {
                    Invoke(() =>
                   MessageBox.Show($"Erro ao configurar 'firebird.conf': {ex.Message}"));
                }
            }));
            btnFirebirdConfig.Enabled = true;
            btnFirebirdConfig.Text = "Aplicar Firebird.conf";
        }

        private async void btnDbcrypt_Click(object sender, EventArgs e)
        {
            LoggingFile.Info("Iniciando configuração do 'DbCrypt.conf'.");
            btnDbcrypt.Enabled = false;
            btnDbcrypt.Text = "Configurando...";
            await Task.Run((() =>
            {
                try
                {
                    DependencyManager.SetDbCrypt();
                    LoggingFile.Info("Configuração do 'DbCrypt.conf' concluída com sucesso.");
                    Invoke(() =>
                   MessageBox.Show("Configuração do DbCrypt concluída com sucesso."));
                }
                catch (IOException iEx)
                {
                    Invoke(() =>
                   MessageBox.Show($"Falha de I/O ao configurar 'DbCrypt.conf'. Detalhes: {iEx.Message}"));
                }
                catch (Exception ex)
                {
                    Invoke(() =>
                   MessageBox.Show($"Erro ao configurar 'DbCrypt.conf': {ex.Message}"));
                }
            }));
            btnDbcrypt.Enabled = true;
            btnDbcrypt.Text = "Aplicar DbCrypt.conf";

        }

        private async void btnBackupFolder_Click(object sender, EventArgs e)
        {
            LoggingFile.Info("Iniciando configuração da pasta de backup.");
            btnBackupFolder.Enabled = false;
            btnBackupFolder.Text = "Configurando...";
            await Task.Run((() =>
            {
                try
                {
                    DependencyManager.SetBackupFolder();
                    LoggingFile.Info("Configuração da pasta de backup concluída com sucesso.");
                    Invoke(() =>
                   MessageBox.Show("Configuração da pasta de backup concluída com sucesso."));
                }
                catch (IOException iEx)
                {
                    Invoke(() =>
                   MessageBox.Show($"Falha de I/O ao configurar a pasta de backup. Detalhes: {iEx.Message}"));
                }
                catch (Exception ex)
                {
                    Invoke(() =>
                   MessageBox.Show($"Erro ao configurar a pasta de backup: {ex.Message}"));
                }
            }));
            btnBackupFolder.Enabled = true;
            btnBackupFolder.Text = "Configurar Pasta de Backup";
        }

        private async void btnUdr_Click(object sender, EventArgs e)
        {
            LoggingFile.Info("Iniciando configuração do UDR.");
            btnUdr.Enabled = false;
            btnUdr.Text = "Configurando...";
            await Task.Run((() =>
            {
                try
                {
                    DependencyManager.SetUdrDll();
                    LoggingFile.Info("Configuração do UDR concluída com sucesso.");
                    Invoke(() =>
                   MessageBox.Show("Configuração do UDR concluída com sucesso."));  
                }
                catch (IOException iEx)
                {
                    Invoke(() =>
                   MessageBox.Show($"Falha de I/O ao configurar o UDR. Detalhes: {iEx.Message}"));
                }
                catch (Exception ex)
                {
                    Invoke(() =>
                   MessageBox.Show($"Erro ao configurar o UDR: {ex.Message}"));
                }
            }));
            btnUdr.Enabled = true;
            btnUdr.Text = "Configurar UDR_SC.dll";
        }

        private async void btnAllConfig_Click(object sender, EventArgs e)
        {
            LoggingFile.Info("Iniciando configuração de todas as dependências.");
            btnAllConfig.Enabled = false;
            btnAllConfig.Text = "Configurando...";
            await Task.Run((() =>
            {
                try
                {
                    DependencyManager.SetFirebirdConfig();
                    DependencyManager.SetDbCrypt();
                    DependencyManager.SetBackupFolder();
                    DependencyManager.SetUdrDll();
                    LoggingFile.Info("Configuração de todas as dependências concluída com sucesso.");
                    Invoke(() =>
                   MessageBox.Show("Configuração de todas as dependências concluída com sucesso."));
                }
                catch (Exception ex)
                {
                    LoggingFile.Error("Configuração completa interrompida.", ex);
                    Invoke(() => MessageBox.Show(
                        $"Ocorreu um erro durante a configuração: {ex.Message}\n\nVerifique o log para mais detalhes.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
            }));
            btnAllConfig.Enabled = true;
            btnAllConfig.Text = "Aplicar Todas as Configurações";
        }

        private void FirebirdHqbirdForm_Load(object sender, EventArgs e)
        {

        }
    }
}

