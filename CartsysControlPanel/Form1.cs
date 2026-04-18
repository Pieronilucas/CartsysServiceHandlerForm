using System.Management;
using System.Diagnostics;
using System.Security.Principal;

namespace CartsysControlPanel;

public partial class Form1 : Form
{
    private bool _isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    private string _appPath = Process.GetCurrentProcess().MainModule?.FileName ?? string.Empty;
    private int _serviceSelected;
    private string _serialHd;
    public Form1()
    {
        InitializeComponent();
        this.ActiveControl = button1;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        if (!_isAdmin)
        {
            var elevated = new ProcessStartInfo
            {
                FileName = _appPath,
                UseShellExecute = true,
                Verb = "runas"
            };

            try
            {
                Process.Start(elevated);
                Application.Exit();
            }
            catch
            {
                MessageBox.Show("Este aplicativo requer privilégios de administrador para funcionar corretamente.", "Permissão Negada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            return;
        }
        GetHdSerial();
    }

    private void GetHdSerial()
    {
        try
        {
            string drive = "C";
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
            disk.Get();
            SeriaHdTb.Text = disk["VolumeSerialNumber"].ToString();
        }
        catch(Exception e)
        {
            MessageBox.Show($"Ocorreu um erro ao tentar obter o serial do HD: {e.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            ServiceInstaller.CartsysInstaller(_serviceSelected);
            MessageBox.Show("Serviço instalado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocorreu um erro ao tentar instalar o serviço: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
       
    }
}