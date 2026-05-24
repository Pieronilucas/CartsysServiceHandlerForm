using CartsysControlPanel.Domain;
using CartsysControlPanel.Infrastructure.FileSystem;
using CartsysControlPanel.Infrastructure.System;
using CartsysControlPanel.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CartsysControlPanel.Views
{
    public partial class HqbirdCalculatorForm : Form
    {
        private readonly string _hqbirdDbconf = Path.Combine(HqbirdPath, "databases.conf");
        private string _selectedPath;
        private Dictionary<string, long?>? _results;
        private Dictionary<string, TextBox> _resultTextBoxes;

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

        }

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            btnCalculate.Enabled = false;
            Dictionary<string, long?> results = null;

            _results = await Task.Run(() => results = DatabaseConfigCalculator.CalculateAll(_selectedPath));

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
            btnApply.Enabled = true;
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
