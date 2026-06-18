using CartsysControlPanel.Domain;
using CartsysControlPanel.Logging;
using static System.Net.WebRequestMethods;

namespace CartsysControlPanel.Views
{
    public partial class BackupRestore : Form
    {
        private Lazy<CredentialForm> _credentialForm =
            new Lazy<CredentialForm>(() => new CredentialForm(), LazyThreadSafetyMode.None);
        private string _bancoEntrada;
        private string _bancoSaidaFBK;
        private string _bancoSaidaFDB;
        private List<int> _paginations = new List<int> { 4096, 8192, 16384 };
        private int _selectedPagination = 4096;

        public BackupRestore()
        {
            InitializeComponent();
        }

        private bool EnsureCredential()
        {
            return _credentialForm.Value.ShowDialog() == DialogResult.OK;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_bancoEntrada))
            {
                MessageBox.Show("Selecione o arquivo antes de continuar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EnsureCredential())
            {
                LoggingFile.Warning("Procedimento cancelado — credenciais não informadas.");
                return;
            }
            string diretorio = Path.GetDirectoryName(_bancoEntrada)!;
            string nomeBase = Path.GetFileNameWithoutExtension(_bancoEntrada);
            _bancoSaidaFBK = Path.Combine(diretorio, $"{nomeBase}_backup.FBK");
            _bancoSaidaFDB = Path.Combine(diretorio, $"{nomeBase}_restaurado.FDB");
            string user = _credentialForm.Value.Username;
            string password = _credentialForm.Value.Password;
            bool crypt = tgCrypt.Checked;
            bool restore = radioRestore.Checked;
            _selectedPagination = cbPagination.SelectedItem is int c ? c : 4096;

            btnStart.Enabled = false;
            btnStart.Text = "Executando...";

            try
            {
                if (restore && !crypt)
                {
                    LoggingFile.Info("Iniciando restore sem criptografia.");
                    await Restore.RestoreSemCrypt(_bancoEntrada, _bancoSaidaFDB, user, password, _selectedPagination);
                    LoggingFile.Info($"Restore com criptografia concluído. Paginação utilizada: {_selectedPagination}");
                }
                else if (restore && crypt)
                {
                    var result = MessageBox.Show("O backup selecionado será criptografado. Deseja continuar com o restore?\n Aviso: Caso realize o procedimento em um banco não criptografado, o processo pode falhar ou causar danos aos dados.",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        LoggingFile.Info("Procedimento cancelado — restore com criptografia.");
                        return;
                    }
                    LoggingFile.Info("Iniciando restore com criptografia.");
                    await Restore.RestoreComCrypt(_bancoEntrada, _bancoSaidaFDB, user, password, _selectedPagination);
                    LoggingFile.Info($"Restore com criptografia concluído. Paginação utilizada: {_selectedPagination}");
                }
                else if (!restore && !crypt)
                {
                    LoggingFile.Info("Iniciando backup sem criptografia.");
                    await Backup.BackupSemCrypt(_bancoEntrada, _bancoSaidaFBK, user, password);
                }
                else
                {
                    var result = MessageBox.Show("O banco selecionado será criptografado. Deseja continuar com o backup?\n Aviso: Caso realize o procedimento em um banco não criptografado, o processo pode falhar ou causar danos aos dados.",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        LoggingFile.Info("Procedimento cancelado — backup com criptografia.");
                        return;
                    }
                    LoggingFile.Info("Iniciando backup com criptografia.");
                    await Backup.BackupComCrypt(_bancoEntrada, _bancoSaidaFBK, user, password);
                }

                LoggingFile.Info($"Procedimento concluído com sucesso. Banco gerado em {_bancoSaidaFDB}");
                MessageBox.Show("Procedimento concluído com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LoggingFile.Error("Falha durante o procedimento de backup/restore.", ex);
                MessageBox.Show($"Ocorreu um erro durante o procedimento:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnStart.Enabled = true;
                btnStart.Text = "Iniciar";
            }
        }

        private void btnDbpath_Click(object sender, EventArgs e)
        {
            using var file = new OpenFileDialog();
            file.Filter = "Arquivos FBK (*.fbk)|*.fbk|Banco Firebird (*.fdb)|*.fdb|Todos (*.*)|*.*";
            file.FilterIndex = 2;
            if (radioRestore.Checked) { file.FilterIndex = 0;}         
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                _bancoEntrada = file.FileName;
                tbDbPath.Text = file.FileName;
            }
        }

        private void BackupRestore_Load(object sender, EventArgs e)
        {
            cbPagination.Visible = false;
            label4.Visible = false;
            foreach (var cb in new[] { cbPagination })
            {
                cb.DataSource = new List<int>(_paginations);
            }
        }

        private void radioRestore_CheckedChanged(object sender, EventArgs e)
        {
            cbPagination.Visible = radioRestore.Checked;
            label4.Visible = radioRestore.Checked;
        }
    }
}
