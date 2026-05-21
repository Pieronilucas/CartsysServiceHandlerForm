using CartsysControlPanel.Infrastructure.System;
using CartsysControlPanel.Logging;
using Microsoft.Win32;
using System.Security;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace CartsysControlPanel.Views
{
    public partial class RegeditForm : Form
    {
        private static string _cartorioPath;
        private static string _dbPath;
        public RegeditForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (string.IsNullOrEmpty(_dbPath))
                {
                    MessageBox.Show("Por favor, selecione o caminho do banco de dados antes de salvar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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
                fdb.Filter =  "Banco de dados Firebird (*.fdb)|*.fdb";
                fdb.FilterIndex = 2;
                fdb.RestoreDirectory = true;
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = fdb.FileName;
                    _dbPath = fdb.FileName;
                }
            }
        }
    }
}
