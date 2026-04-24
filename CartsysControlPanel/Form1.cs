using System.Diagnostics;
using System.Security.Principal;

namespace CartsysControlPanel;

public partial class Form1 : Form
{
    private bool _isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    private string _appPath = Process.GetCurrentProcess().MainModule?.FileName ?? string.Empty;
    private int _serviceSelected;
    private string _serialHd;
    private string _serverName;
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
        _serialHd = GetSerialHd.GetHdSerial();
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
        btnUninstallAll.Text = "Botão do geme meu nome";
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
        BtnInstallAll.Text = "AAAAAAAAAAAAAAAAAAAA";

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
}