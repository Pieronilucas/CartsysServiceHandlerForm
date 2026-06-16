using CartsysControlPanel.Domain;
using CartsysControlPanel.Infrastructure.FileSystem;
using CartsysControlPanel.Infrastructure.System;
using CartsysControlPanel.Logging;

namespace CartsysControlPanel.Views
{
    public partial class HqbirdCalculatorForm : Form
    {
        private readonly string _hqbirdDbconf = Path.Combine(HqbirdPath, "databases.conf");
        private string _selectedPath;
        private Dictionary<string, long?>? _results;
        private Dictionary<string, TextBox> _resultTextBoxes;
        private List<int> Paginations = new List<int> { 4096, 8192, 16384 };
        public static int cartorioPageSize;
        public static int arquivosPageSize;
        public static int auditoriaPageSize;
        public static int indisponibilidadePageSize;
        public static int notaFiscalPageSize;


        public HqbirdCalculatorForm()
        {
            InitializeComponent();
            btnApply.Enabled = false;
        }

        private void HqbirdCalculatorForm_Load(object sender, EventArgs e)
        {
            _resultTextBoxes = new Dictionary<string, TextBox>
            {
                { "CARTORIO.FDB",          tbCartorio },
                { "ARQUIVOS.FDB",          tbArquivos },
                { "AUDITORIA.FDB",         tbAuditoria },
                { "INDISPONIBILIDADE.FDB", tbIndisponibilidade },
                { "NOTAFISCALDB.FDB",      tbNotaFiscal }
            };

            var (totalRAM, safeLimit) = DatabaseConfigCalculator.GetMemoryInfo();
            tbRamDisponivel.Text = $"{totalRAM / 1024.0 / 1024.0:F1} GB";
            tbSafeLimit.Text = $"{safeLimit / 1024.0 / 1024.0:F1} GB";
            foreach (var cb in new[] { cbCartorio, cbArquivos, cbAuditoria, cbIndisponibilidade, cbNotaFiscal })
            {
                cb.DataSource = new List<int>(Paginations);
            }
        }

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            btnCalculate.Enabled = false;
            Dictionary<string, long?> results = null;

            if (_selectedPath == null)
            {
                tbErroCaminhoBancos.Text = "Por favor, selecione o caminho dos bancos de dados antes de calcular.";
                tbErroCaminhoBancos.Visible = true;
                tbDbPath.Focus();
                btnCalculate.Enabled = true;
                return;
            }

            var config = new PageSizeConfig(
            Cartorio: cbCartorio.SelectedItem is int c ? c : 4096,
            Arquivos: cbArquivos.SelectedItem is int a ? a : 4096,
            Auditoria: cbAuditoria.SelectedItem is int au ? au : 4096,
            Indisponibilidade: cbIndisponibilidade.SelectedItem is int i ? i : 4096,
            NotaFiscal: cbNotaFiscal.SelectedItem is int n ? n : 4096
            );


            _results = await Task.Run(() => results = DatabaseConfigCalculator.CalculateAll(_selectedPath, config));

            // exibe preview
            foreach (var r in _results)
            {
                if (_resultTextBoxes.TryGetValue(r.Key, out TextBox tb))
                    tb.Text = r.Value.HasValue ? $"{r.Value} páginas" : "Não encontrado";
                LoggingFile.Info($"{r.Key} → {r.Value} páginas");

            }
            

            btnCalculate.Enabled = true;
            btnApply.Enabled = _results != null && _results.Any();
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            btnApply.Enabled = false;
            string conf = DatabaseConfigCalculator.GenerateDbConf(_results, _selectedPath);

            await Task.Run(() => FileHandler.AppendTextToFile(_hqbirdDbconf, conf));

            MessageBox.Show("databases.conf atualizado com sucesso.");

        }


        private string GetFileSizeText(string path)
        {
            try
            {
                long size = FileHandler.FileSizeCalculator(path);
                return $"{size / 1024.0 / 1024.0 / 1024:F2} GB";
            }
            catch (FileNotFoundException)
            {
                return "Não encontrado";
            }
            catch (Exception)
            {
                return "Erro ao ler";
            }
        }


        private void btnDbpath_Click(object sender, EventArgs e)
        {
            using (var fdb = new FolderBrowserDialog())
            {
                fdb.InitialDirectory = @"C:\";
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    _selectedPath = fdb.SelectedPath;
                    tbDbPath.Text = _selectedPath;

                    tbSizeCartorio.Text = GetFileSizeText(Path.Combine(_selectedPath, "CARTORIO.FDB"));
                    tbSizeArquivos.Text = GetFileSizeText(Path.Combine(_selectedPath, "ARQUIVOS.FDB"));
                    tbSizeAuditoria.Text = GetFileSizeText(Path.Combine(_selectedPath, "AUDITORIA.FDB"));
                    tbSizeIndisponibilidade.Text = GetFileSizeText(Path.Combine(_selectedPath, "INDISPONIBILIDADE.FDB"));
                    tbSizeNotaFiscal.Text = GetFileSizeText(Path.Combine(_selectedPath, "NOTAFISCALDB.FDB"));

                }
            }
        }



        private static string HqbirdPath
        {
            get
            {
                string? path = ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3");
                if (path == null)
                {
                    LoggingFile.Error("Diretório do HQBird não encontrado. O serviço 'FirebirdServerHQBirdInstanceFB3' está instalado?");
                    throw new InvalidOperationException("Diretório do HQBird não encontrado.");
                }
                return path;
            }
        }
    }
}
