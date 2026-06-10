using CartsysControlPanel.Logging;
using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.ServiceProcess;

namespace CartsysControlPanel.Infrastructure.System
{
    public static class ServiceHandler
    {
        public enum ServiceStatus { Running, Stopped, NotInstalled }

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
        public static async Task ServiceInstaller(int option)
        {
            object? regValue = Registry
                .GetValue("HKEY_CURRENT_USER\\Software\\SC Sistemas\\Atualiza", "Caminho", null);

            if (regValue is null)
            {
                LoggingFile.Error("Registro de caminho para instalação do serviço não encontrado no Regedit. Verifique se o mesmo foi corretamente criado.");
                return;
            }

            string cartorioPath = regValue.ToString()!;
            string UtilPath = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe";
            string serviceExe = executaveis[option];
            string fullPath = Path.Combine(cartorioPath, serviceExe);

            if (!File.Exists(fullPath))
            {
                LoggingFile.Error($"O executável de instalação do serviço não foi encontrado em {fullPath}");
                return;
            }

            UnblockFile(fullPath);

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
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    LoggingFile.Error(error);
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        LoggingFile.Error($"Falha ao instalar o serviço {serviceNames[option]}. Código de saída: {process.ExitCode} | {output} | {error}");
                        throw new Exception(error);
                    }
                }
                LoggingFile.Info($"Serviço {serviceNames[option]} instalado com sucesso.");
                ServiceRestartAtFailure(option);
                LoggingFile.Info($"Serviço {serviceNames[option]} configurado para reiniciar em caso de falha.");
            }
            catch (Win32Exception ex) when (ex.NativeErrorCode == 5) // Erro de Acesso Negado
            {
                LoggingFile.Error($"Permissão negada ao tentar instalar o serviço {serviceNames[option]}. Tente executar o programa como administrador. Detalhes: {ex.Message}", ex);
                throw;
            }
            catch (Win32Exception wEx)
            {
                LoggingFile.Error($"Erro de sistema ao iniciar instalador: {wEx.Message}", wEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Falha inesperada na instalação do serviço {serviceNames[option]}. Erro: {ex.Message}", ex);
                throw;
            }
            
        }


        public static async Task ServiceInstallAll()
        {
            var failures = new List<string>();
            foreach (var service in serviceNames)
            {
                try
                {
                    ServiceInstaller(service.Key);
                }
                catch (Exception ex)
                {
                    LoggingFile.Error($"Falha ao instalar {service.Value}", ex);
                    failures.Add(service.Value);
                }

            }
            if (failures.Any())
                throw new Exception($"{string.Join(", ", failures)}");
        }

        // Para os serviços e desinstala eles através do sc delete.
        public static async Task ServiceUninstaller(int option)
        {
            string service = serviceNames[option];
            await ServiceStop(option);

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
                        LoggingFile.Error($"Falha ao desinstalar o serviço {serviceNames[option]}. Código de saída: {process.ExitCode}");
                        return;
                    }
                }
                LoggingFile.Info($"Serviço {serviceNames[option]} desinstalado com sucesso.");
            }
            catch (Win32Exception wEx)
            {
                LoggingFile.Error($"Não foi possível executar o 'sc.exe': {wEx.Message}", wEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Erro inesperado na desinstalação do serviço {serviceNames[option]}: {ex.Message}", ex);
                throw;
            }


        }

        public static async Task ServiceUninstallAll()
        {
            foreach (var service in serviceNames)
            {
                await ServiceUninstaller(service.Key);
            }
        }

        // setta os serviçs para reiniciar em caso de falha.
        public static void ServiceRestartAtFailure(int option)
        {

            string serviceName = serviceNames[option];
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
                        LoggingFile.Error($"Falha ao configurar o serviço {serviceNames[option]} para reinicializar. Código de saída: {process.ExitCode}");
                        return;
                    }
                }
                LoggingFile.Info($"Serviço {serviceNames[option]} configurado para reinicializar em caso de falha.");
            }
            catch (Win32Exception wEx)
            {
                LoggingFile.Error($"Não foi possível executar o 'sc.exe' para configurar o serviço {serviceNames[option]}: {wEx.Message}", wEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Falha ao configurar o serviço {serviceNames[option]} para reinicializar. Erro: {ex.Message}", ex);
                throw;
            }

        }

        public static async Task InitServices(int option)
        {

            string serviceName = serviceNames[option];
            var startInfo = new ProcessStartInfo
            {
                FileName = "sc.exe",
                Arguments = $"start \"{serviceName}\"",
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
                        LoggingFile.Error($"Falha ao iniciar o serviço {serviceNames[option]}. Código de saída: {process.ExitCode}");
                        return;
                    }
                }
                LoggingFile.Info($"Serviço {serviceNames[option]} iniciado com sucesso.");
            }
            catch (Win32Exception wEx)
            {
                LoggingFile.Error($"Não foi possível executar o 'sc.exe' para iniciar o serviço {serviceNames[option]}: {wEx.Message}", wEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Falha ao iniciar o serviço {serviceNames[option]}. Erro: {ex.Message}", ex);
                throw;
            }

        }

        public static async Task InitAllServices()
        {
            var failures = new List<string>();
            foreach (var service in serviceNames)
            {
                try
                {
                    InitServices(service.Key);
                }
                catch (Exception ex)
                {
                    LoggingFile.Error($"Falha ao iniciar {service.Value}", ex);
                    failures.Add(service.Value);
                }

            }
            if (failures.Any())
            {
                throw new Exception($"{string.Join(", ", failures)}");
            }
        }

        public async static Task SetAllToRestart()
        {
            foreach (var service in serviceNames)
            {
                await Task.Run(() => ServiceRestartAtFailure(service.Key));
            }
        }

        public async static Task ServiceStop(int option)
        {
            var task = Task.Run(() =>
            {
                try
                {
                    var sc = new ServiceController(serviceNames[option]);
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(5));
                }
                catch
                {
                    LoggingFile.Warning($"Não foi possível parar o serviço {serviceNames[option]}. Ele pode não estar em execução ou pode ter sido desinstalado.");
                }

            });
            await task;
        }



        // Tenta pegar a pasta raiz do executável do serviço.
        // Metodo irá retornar null caso o serviço não seja encontrado ou ocorra algum erro durante a consulta WMI.
        public static string? GetServiceDirectory(string serviceName)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    $"SELECT PathName FROM Win32_Service WHERE Name = '{serviceName}'");

                using var collection = searcher.Get();
                var service = collection.Cast<ManagementObject>().FirstOrDefault();

                if (service == null) { LoggingFile.Error($"Serviço {serviceName} não encontrado via WMI."); return null; }

                string rawPath = service["PathName"]?.ToString();
                if (string.IsNullOrWhiteSpace(rawPath)) { LoggingFile.Error($"Caminho do serviço {serviceName} não encontrado via WMI."); return null; }

                // Limpeza de aspas e argumentos
                string cleanPath = rawPath.StartsWith("\"")
                    ? rawPath.Split('\"')[1]
                    : rawPath.Split(' ')[0];


                LoggingFile.Info($"Caminho do serviço {serviceName} obtido com sucesso via WMI: {cleanPath}");
                return Path.GetDirectoryName(cleanPath);

            }
            catch (ManagementException mEx)
            {
                LoggingFile.Error($"Erro de gerenciamento ao obter o caminho do serviço {serviceName} via WMI: {mEx.Message}", mEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Erro ao obter o caminho do serviço {serviceName} via WMI: {ex.Message}", ex);
                throw;
            }
        }

        public static bool IsServiceInstalled(string serviceName)
        {
            ServiceController ctl = ServiceController.GetServices()
            .FirstOrDefault(s => s.ServiceName == serviceName);
            if (ctl == null) { return false; }

            return true;
        }
        
        public static ServiceStatus GetServiceStatus(int option)
        {
            try
            {
                using var sc = new ServiceController(serviceNames[option]);
                var status = sc.Status; // Tenta acessar o status para verificar se o serviço existe
                return status == ServiceControllerStatus.Running
                    ?
                    ServiceStatus.Running :
                    ServiceStatus.Stopped;
            }
            catch (InvalidOperationException)
            {
                return ServiceStatus.NotInstalled;
            }
        }

        public static int CartsysServicesInstalled()
        {
            int quantity = 0;
            foreach (var service in serviceNames)
            {
                if (IsServiceInstalled(service.Value))
                {
                    quantity++;
                }
            }
            return quantity;
        }

        private static void UnblockFile(string filePath)
        {
            try
            {
                string streamPath = filePath + ":Zone.Identifier";
                if (File.Exists(streamPath))
                {
                    File.Delete(streamPath);
                    LoggingFile.Info($"Arquivo {Path.GetFileName(filePath)} desbloqueado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Erro ao tentar desbloquear o arquivo {Path.GetFileName(filePath)}: {ex.Message}", ex);
            }
        }
    }
}
