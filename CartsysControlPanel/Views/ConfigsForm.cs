using CartsysControlPanel.Infrastructure.System;
using CartsysControlPanel.Logging;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Security;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace CartsysControlPanel.Views
{
    public partial class ConfigsForm : Form
    {
        private static string _cartorioPath;
        private static string _dbPath;
        public ConfigsForm()
        {
            InitializeComponent();
        }

        private void btnCreateRegistry_Click(object sender, EventArgs e)
        {
            
            if (!validatePaths())
            {
                return;
            }

            try
                { 
                    RegistryHandler.CreateRegistryKey(_dbPath, _cartorioPath);
                    MessageBox.Show("Configurações salvas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SecurityException sEx)
                {
                    MessageBox.Show("Permissão negada. Por favor, execute o aplicativo como administrador para salvar as configurações.", "Erro de Permissão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException uaEx)
                {
                    MessageBox.Show("Acesso negado. Por favor, execute o aplicativo como administrador para salvar as configurações.", "Erro de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ioEx)
                {
                    MessageBox.Show("Erro de I/O ao tentar gravar no Registro do Windows. Verifique se o caminho do banco de dados é válido e se você tem permissão para acessar o Registro.", "Erro de I/O", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException argEx)
                {
                    MessageBox.Show($"Erro de argumento: {argEx.Message}. Verifique se os caminhos fornecidos são válidos.", "Erro de Argumento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private bool validatePaths()
        {
            if(string.IsNullOrEmpty(_cartorioPath) && string.IsNullOrEmpty(_dbPath))
            {
                tbErroCaminhoCartorio.Text = "Por favor, selecione o caminho do cartório antes de salvar.";
                tbErroCaminhoCartorio.Visible = true;
                tbErroCaminhoBanco.Text = "Por favor, selecione o caminho do banco de dados antes de salvar.";
                tbErroCaminhoBanco.Visible = true;
                textBox1.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(_cartorioPath))
            {
                tbErroCaminhoCartorio.Text = "Por favor, selecione o caminho do cartório antes de salvar.";
                tbErroCaminhoCartorio.Visible = true;
                textBox1.Focus();
                return false;
            }
            else
            {
                tbErroCaminhoCartorio.Visible = false;
            }
            if (string.IsNullOrEmpty(_dbPath))
            {
                tbErroCaminhoBanco.Text = "Por favor, selecione o caminho do banco de dados antes de salvar.";
                tbErroCaminhoBanco.Visible = true;
                textBox2.Focus();
                return false;
            }
            else
            {
                tbErroCaminhoBanco.Visible = false;
            }

            tbErroCaminhoBanco.Visible = false;
            tbErroCaminhoCartorio.Visible = false;
            return true;
        }

        private void btnFbdCartorio_Click(object sender, EventArgs e)
        {
            using (var fdb = new FolderBrowserDialog())
            {
                fdb.InitialDirectory = @"C:\";
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = fdb.SelectedPath;
                    _cartorioPath = fdb.SelectedPath;
                }
            }

        }

        private void btnFbdDb_Click(object sender, EventArgs e)
        {
            using (var fdb = new OpenFileDialog())
            {
                fdb.InitialDirectory = @"C:\";
                fdb.Filter = "Banco de dados Firebird (*.fdb)|*.fdb";
                fdb.FilterIndex = 2;
                fdb.RestoreDirectory = true;
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = fdb.FileName;
                    _dbPath = fdb.FileName;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void btnFirewall_Click_1(object sender, EventArgs e)
        {
            btnFirewall.Enabled = false;
            btnFirewall.Text = "Configurando Firewall...";
            await Task.Run(() =>
             {

                 try
                 {
                     int port;
                     int auxPort;
                     if (string.IsNullOrWhiteSpace(tbPort.Text) || string.IsNullOrWhiteSpace(tbAuxPort.Text))
                     {
                         var result = MessageBox.Show("Nenhuma porta foi informada, então será utilizada as portas padrões (3050 e 3051).", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                         if (result == DialogResult.No)
                         {
                             return;
                         }
                         port = 3050;
                         auxPort = 3051;
                     }
                     else
                     {
                         port = int.Parse(tbPort.Text);
                         auxPort = int.Parse(tbAuxPort.Text);
                     }

                     FirewallHandler.OpenFirebirdPort(int.Parse(port.ToString()), int.Parse(auxPort.ToString()));
                     MessageBox.Show("Porta do Firebird configurada com sucesso no firewall do Windows!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 catch (UnauthorizedAccessException)
                 {
                     MessageBox.Show("Acesso negado. Por favor, execute o aplicativo como administrador para configurar o firewall.", "Erro de Acesso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 catch (COMException comEx)
                 {
                     MessageBox.Show($"Erro ao acessar o serviço de firewall: {comEx.Message}. Verifique se o serviço de firewall está em execução e se você tem permissão para acessá-lo.", "Erro de COM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show($"Ocorreu um erro inesperado ao configurar o firewall: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             });
            btnFirewall.Enabled = true;
            btnFirewall.Text = "Liberar portas 3050-3051";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            tbPort.MaxLength = 5;
        }

        private void tbAuxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            tbAuxPort.MaxLength = 5;
        }


    }
}
