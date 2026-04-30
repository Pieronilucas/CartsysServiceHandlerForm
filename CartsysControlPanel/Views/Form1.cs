using CartsysControlPanel.Handlers;
using CartsysControlPanel.Infrastructure;
using System.Management;

namespace CartsysControlPanel;

public partial class Form1 : Form
{
    private int _serviceSelected;
    private string _serialHd;
    private string _serverName;
    private string _selectedPath;
    private string _finalPath;
    public Form1()
    {
        InitializeComponent();
        this.ActiveControl = button1;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        setHdSerial();
    }
    private void setHdSerial()
    {
        _serialHd = HardwareHandler.GetHdSerial();
        SeriaHdTb.Text = _serialHd;
    }



    private void RadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is RadioButton rb && rb.Checked)
        {

            if (int.TryParse(rb.Tag?.ToString(), out int value))
            {
                _serviceSelected = value;
            }
        }
    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {

    }

    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Text = "Instalando...";
        button1.Enabled = false;
        await Task.Run(() =>
         {
             try
             {
                 ServiceHandler.ServiceInstaller(_serviceSelected);
                 MessageBox.Show("Serviço instalado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Ocorreu um erro ao tentar instalar o serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         });
        button1.Enabled = true;
        button1.Text = "Instalar";
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            _serverName = NetworkHandler.ServerName();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocorreu um erro ao tentar recuperar as informações de DNS do servidor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
        }

        RegeditHandler.CreateRegistryKey(_serverName, "C:\\CARTSYSDADOS\\CARTORIO.FDB");
    }

    private async void button3_Click(object sender, EventArgs e)
    {
        button3.Text = "Desinstalando...";
        button3.Enabled = false;
        await Task.Run(() =>
        {
            try
            {
                ServiceHandler.ServiceUninstaller(_serviceSelected);
                MessageBox.Show("Serviço desinstalado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar desinstalar os serviços: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        });
        button3.Enabled = true;
        button3.Text = "Desinstalar";

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
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar desinstalar os serviços: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        });
        btnUninstallAll.Enabled = true;
        btnUninstallAll.Text = "Desinstalar Todos";
    }

    private async void BtnInstallAll_Click(object sender, EventArgs e)
    {
        BtnInstallAll.Text = "Instalando...";
        BtnInstallAll.Enabled = false;
        await Task.Run(() =>
         {
             try
             {
                 ServiceHandler.ServiceInstallAll();
                 MessageBox.Show("Todos os serviços foram instalados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Ocorreu um erro ao tentar instalar os serviços: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         });
        BtnInstallAll.Enabled = true;
        BtnInstallAll.Text = "Instalar Todos";

    }

    private void button6_Click(object sender, EventArgs e)
    {
        try
        {
            ServiceHandler.ServiceRestartAtFailure();
            MessageBox.Show("A configuração de reinicialização automática do serviço foi aplicada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocorreu um erro ao tentar configurar a reinicialização automática do serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnFirewall_Click(object sender, EventArgs e)
    {
        btnFirewall.Enabled = false;
        await Task.Run(() =>
        {
            FirewallHandler.OpenFirebirdPort();
        });
        btnFirewall.Enabled = true;
    }

    private async void btnOpenHqBirdPage_Click(object sender, EventArgs e)
    {
        bool sucess = await NetworkHandler.RedirectToHqbird(isDirectDownload: false);

        if (!sucess)
        {
            MessageBox.Show("Não foi possível acessar a página de download. Verifique sua conexão com a internet.",
                "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private async void btnHqBirdDirectDownload_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show(
        "O download direto será iniciado no seu navegador.\n\n" +
        "Atenção: Firewalls podem bloquear o download automático.",
        "Confirmar Download", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            btnHqBirdDirectDownload.Enabled = false;

            bool sucess = await NetworkHandler.RedirectToHqbird(isDirectDownload: true);

            if (!sucess)
            {
                MessageBox.Show("O link direto está inacessível ou foi bloqueado pela rede do cartório. " +
                            "Tente usar o botão de 'Página de Download'.",
                            "Falha no Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnHqBirdDirectDownload.Enabled = true;

        }
    }

    private void button4_Click(object sender, EventArgs e)
    {

    }

    private void button5_Click(object sender, EventArgs e)
    {
        using (var fdb = new FolderBrowserDialog())
        {
            fdb.Description = "Selecione a pasta onde o banco de dados do cartório está localizado.";
            fdb.RootFolder = Environment.SpecialFolder.MyComputer;
            fdb.ShowNewFolderButton = false;
            if (fdb.ShowDialog() == DialogResult.OK)
            {
                _selectedPath = fdb.SelectedPath;
            }

        }


        _finalPath = Path.Combine(_selectedPath, "CARTORIO.FDB");

        long fileSize = FileHandler.FileSizeCalculator(_finalPath);
        long? pages = HqbirdHandler.DefaultDbCacheCalc(fileSize, 16384);

        string message = $"CARTORIO = {_finalPath}\n" +
            "{\n" +
            $"DefaultDBCachePages = {pages}\n"+
            "}";
        
        File.AppendAllText("C:\\HQbird\\Firebird30\\databases.conf", message);
    }
}