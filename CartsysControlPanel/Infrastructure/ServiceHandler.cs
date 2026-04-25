using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;

namespace CartsysControlPanel.Handlers
{
    public class ServiceHandler
    {
        private static Dictionary<int, string> executaveis = new Dictionary<int, string>
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
        private static Dictionary<int, string> serviceNames = new Dictionary<int, string>
        {
            {1, "CartsysExecuta"},
            {2, "CartsysGuardian"},
            {3, "CartsysNotificacao"},
            {4, "CartsysNFSe"},
            {5, "CartsysTarefas"},
            {6, "CartsysWhatsApp"},
            {7, "CartsysUpdate"},
            {8, "CartsysParcelaExpress"},
            {9, "CartsysSignalRCliente"},
            {10, "CartsysAlertas"}
        };

        // utiliza .Net InstallUtil para instalar os serviços.
        public static void ServiceInstaller(int option)
        {


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
            string serviceExe = executaveis[option];
            string fullPath = Path.Combine(cartorioPath, serviceExe);

            if (!File.Exists(fullPath))
            {
                MessageBox.Show($"O executável de instalação do serviço não foi encontrado em {fullPath}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = cartorioPath,
                FileName = UtilPath,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
            };
            startInfo.ArgumentList.Add("/install");
            startInfo.ArgumentList.Add("/LogFile=");
            startInfo.ArgumentList.Add(fullPath);
            try
            {
                using var process = Process.Start(startInfo);
                if (process != null)
                {
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        MessageBox.Show($"Falha ao instalar {serviceExe}. Código de saída: {process.ExitCode}",
                                "Erro na Instalação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Win32Exception ex) when (ex.NativeErrorCode == 5) // Erro de Acesso Negado
            {
                MessageBox.Show("Acesso negado ao executar o InstallUtil. O programa deve ser executado como Administrador.", "Erro de Permissão", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show($"Erro de sistema ao iniciar instalador: {ex.Message}", "Erro Win32", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha inesperada na instalação: {ex.Message}", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public static void ServiceInstallAll()
        {
            foreach (var service in serviceNames)
            {
                ServiceInstaller(service.Key);
            }
        }

        // Para os serviços e desinstala eles através do sc delete.
        public static void ServiceUninstaller(int option)
        {
            string service = serviceNames[option];
            ServiceStop(option);

            var startInfo = new ProcessStartInfo
            {
                FileName = "sc.exe",
                UseShellExecute = false,
                Arguments = $"delete \"{service}\"",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
            };
            try
            {
                using var process = Process.Start(startInfo);
                if (process != null)
                {
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        MessageBox.Show($"Falha ao desinstalar {service}. Código: {process.ExitCode}",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show($"Não foi possível executar o 'sc.exe': {ex.Message}", "Erro de Execução", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado na desinstalação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public static void ServiceUninstallAll()
        {
            foreach (var service in serviceNames)
            {
                ServiceUninstaller(service.Key);
            }
        }

        // setta os serviçs para reiniciar em caso de falha.
        public static void ServiceRestartAtFailure()
        {
            foreach (var service in serviceNames)
            {
                string serviceName = Path.GetFileNameWithoutExtension(serviceNames[service.Key]);
                var startInfo = new ProcessStartInfo
                {
                    FileName = "sc.exe",
                    Arguments = $"failure \"{serviceName}\" reset= 0 actions= restart/60000",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                };
                try
                {
                    using var process = Process.Start(startInfo);
                    if (process != null)
                    {
                        process.WaitForExit();
                        if (process.ExitCode != 0)
                        {
                            MessageBox.Show($"Falha ao colocar o serviço {service} para reinicializar. Código: {process.ExitCode}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Falha ao colocar o serviço {service} para reinicializar. Erro: {ex.Message}.", $"Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Tenta parar o serviço pelo Net stop. Se o mesmo se recusar a parar em 2 segundos, mata a tarefas.
        public static void ServiceStop(int option)
        {
            string serviceName = serviceNames[option];
            string exeName = executaveis[option];

            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "net",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                using (var process = Process.Start(startInfo))
                {
                    process?.WaitForExit(2000);
                }


                var killInfo = new ProcessStartInfo
                {
                    FileName = "taskkill.exe",
                    Arguments = $"/F /IM \"{exeName}\" /T",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                using (var p = Process.Start(killInfo))
                {
                    p?.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao parar o serviço {serviceName}. Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string GetExecutablePath(string serviceName)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    $"SELECT PathName FROM Win32_Service WHERE Name = '{serviceName}'");

                foreach (ManagementObject service in searcher.Get())
                {
                    string pathName = service["PathName"]?.ToString();
                    if (string.IsNullOrEmpty(pathName)) return null;

                    // O Regex abaixo pega tudo que está dentro de aspas OU até o primeiro espaço após o .exe
                    string pattern = @"^""?([^""]+\.exe)""?.*$";
                    var match = System.Text.RegularExpressions.Regex.Match(pathName, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                    return match.Success ? match.Groups[1].Value : pathName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return null;
            }
            return null;
        }
    }
}
