using Microsoft.Win32;
using System.Diagnostics;

namespace CartsysControlPanel
{
    public class ServiceInstaller
    {
        public static void CartsysInstaller(int option)
        {
            var executaveis = new Dictionary<int, string>
        {
            {1, "Cartsys.Registro.Executa.exe"},
            {2, "Cartsys.Guardian.exe"},
            {3, "Cartsys.Notificacao.Servico.exe"},
            {4, "Cartsys.NFSe.Servico.exe"},
            {5, "CartsysTarefas.exe"},
            {6, "Cartsys.WhatsApp.Servico.exe"},
            {7, "Cartsys.Update.Servico.exe"},
            {8, "Cartsys.ParcelaExpress.Servico.exe"},
            {9, "Cartsys.Registro.Cliente.Servico.exe"},
            {10, "Cartsys.Alertas.Servico.exe"}
        };

            object? regValue = Registry
                .GetValue("HKEY_CURRENT_USER\\Software\\SC Sistemas\\Atualiza", "Caminho", null);

            if (regValue is null)
            {
                MessageBox.Show("Não foi encontrado qualquer caminho no Regedit. Verifique se o mesmo foi corretamente criado.", 
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cartorioPath = regValue.ToString()!;

            string UtilPath = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe";
            string service = Path.Combine(cartorioPath, executaveis[option]);

            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = cartorioPath,
                FileName = UtilPath,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
            };
            startInfo.ArgumentList.Add(service);
            startInfo.ArgumentList.Add("/install");

            using var process = Process.Start(startInfo);

            if (process.HasExited || process is null || process.HasExited)
            {
                MessageBox.Show("Ocorreu um erro ao tentar instalar o serviço. Verifique se o caminho do serviço está correto e se você tem permissões suficientes para instalar serviços.", 
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            Console.WriteLine("output: " + output);
            Console.WriteLine("error: " + error);

            Console.WriteLine($"ExitCode: {process.ExitCode}");
            Console.ReadLine();
        }
    }
}
