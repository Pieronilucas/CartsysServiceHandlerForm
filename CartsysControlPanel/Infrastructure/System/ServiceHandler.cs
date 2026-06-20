using CartsysControlPanel.Logging;
using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;
using System.ServiceProcess;
using System.Xaml;

namespace CartsysControlPanel.Infrastructure.System
{
    public static class ServiceHandler
    {
        
        public enum ServiceStatus { Running, Stopped, NotInstalled }

        private static Dictionary<int, string> _executaveis = new Dictionary<int, string>
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
            {10, "Cartsys.Alertas.Servico.exe"},
            {11, "Cartsys.Alertas.Notas.Servico.exe"}
        };
        private static Dictionary<int, string> _serviceNames = new Dictionary<int, string>
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
            {10, "CartsysAlertas"},
            {11, "CartsysAlertasNotas"}
        };
        private static Dictionary<int, string> _getActiveServices(bool isImoveis)
        {
            return _serviceNames
                .Where(s => s.Key != (isImoveis ? 11 : 10))
                .ToDictionary(s => s.Key, s => s.Value);
        }

        // utiliza .Net InstallUtil para instalar os serviços.
        public static async Task ServiceInstaller(int option, bool isImoveis)
        {
            object? regValue;
            if (isImoveis)
            {
                regValue = Registry
                .GetValue("HKEY_CURRENT_USER\\Software\\SC Sistemas\\Atualiza", "Caminho", null);
            }
            else
            {
                regValue = Registry.GetValue("HKEY_CURRENT_USER\\Software\\CartSys\\Notas\\Atualiza", "Caminho", null);
            }
            

            if (regValue is null)
            {
                LoggingFile.Error("Registro de caminho para instalação do serviço não encontrado no Regedit. Verifique se o mesmo foi corretamente criado.");
                return;
            }

            string cartorioPath = regValue.ToString()!;
            string UtilPath = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe";
            string serviceExe = _executaveis[option];
            string fullPath = Path.Combine(cartorioPath, serviceExe);

            if (!File.Exists(fullPath))
            {
                LoggingFile.Error($"O executável de instalação do serviço não foi encontrado em {fullPath}");
                throw new ArgumentException("Não foi possivel encontrar o caminho da pasta cartório no regedit. Verifique se a mesma foi criada corretamente.");
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
                        LoggingFile.Error($"Falha ao instalar o serviço {_serviceNames[option]}. Código de saída: {process.ExitCode} | {output} | {error}");
                        throw new Exception(error);
                    }
                }
                LoggingFile.Info($"Serviço {_serviceNames[option]} instalado com sucesso.");
                ServiceRestartAtFailure(option);
                LoggingFile.Info($"Serviço {_serviceNames[option]} configurado para reiniciar em caso de falha.");
            }
            catch (Win32Exception ex) when (ex.NativeErrorCode == 5) // Erro de Acesso Negado
            {
                LoggingFile.Error($"Permissão negada ao tentar instalar o serviço {_serviceNames[option]}. Tente executar o programa como administrador. Detalhes: {ex.Message}", ex);
                throw;
            }
            catch (Win32Exception wEx)
            {
                LoggingFile.Error($"Erro de sistema ao iniciar instalador: {wEx.Message}", wEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Falha inesperada na instalação do serviço {_serviceNames[option]}. Erro: {ex.Message}", ex);
                throw;
            }

        }


        public static async Task ServiceInstallAll(bool isImoveis)
        {
            var failures = new List<string>();
            foreach (var service in _getActiveServices(isImoveis))
            {
                try
                {
                    ServiceInstaller(service.Key, isImoveis);
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
            string service = _serviceNames[option];
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
                        LoggingFile.Error($"Falha ao desinstalar o serviço {_serviceNames[option]}. Código de saída: {process.ExitCode}");
                        return;
                    }
                }
                LoggingFile.Info($"Serviço {_serviceNames[option]} desinstalado com sucesso.");
            }
            catch (Win32Exception wEx)
            {
                LoggingFile.Error($"Não foi possível executar o 'sc.exe': {wEx.Message}", wEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Erro inesperado na desinstalação do serviço {_serviceNames[option]}: {ex.Message}", ex);
                throw;
            }


        }

        public static async Task ServiceUninstallAll(bool isImoveis)
        {
            foreach (var service in _getActiveServices(isImoveis))
            {
                await ServiceUninstaller(service.Key);
            }
        }

        // setta os serviçs para reiniciar em caso de falha.
        public static void ServiceRestartAtFailure(int option)
        {

            string serviceName = _serviceNames[option];
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
                        LoggingFile.Error($"Falha ao configurar o serviço {_serviceNames[option]} para reinicializar. Código de saída: {process.ExitCode}");
                        return;
                    }
                }
                LoggingFile.Info($"Serviço {_serviceNames[option]} configurado para reinicializar em caso de falha.");
            }
            catch (Win32Exception wEx)
            {
                LoggingFile.Error($"Não foi possível executar o 'sc.exe' para configurar o serviço {_serviceNames[option]}: {wEx.Message}", wEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Falha ao configurar o serviço {_serviceNames[option]} para reinicializar. Erro: {ex.Message}", ex);
                throw;
            }

        }

        public static async Task InitServices(int option)
        {

            string serviceName = _serviceNames[option];
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
                        LoggingFile.Error($"Falha ao iniciar o serviço {_serviceNames[option]}. Código de saída: {process.ExitCode}");
                        return;
                    }
                }
                LoggingFile.Info($"Serviço {_serviceNames[option]} iniciado com sucesso.");
            }
            catch (Win32Exception wEx)
            {
                LoggingFile.Error($"Não foi possível executar o 'sc.exe' para iniciar o serviço {_serviceNames[option]}: {wEx.Message}", wEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Falha ao iniciar o serviço {_serviceNames[option]}. Erro: {ex.Message}", ex);
                throw;
            }

        }

        public static async Task InitAllServices(bool isImoveis)
        {
            var failures = new List<string>();
            foreach (var service in _getActiveServices(isImoveis))
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
            foreach (var service in _serviceNames)
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
                    var sc = new ServiceController(_serviceNames[option]);
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                }
                catch (Win32Exception Wex)
                {
                     LoggingFile.Error($"Erro ao tentar parar o serviço {_serviceNames[option]}: {Wex.Message}", Wex);
                }
                catch (Exception ex)
                {
                    LoggingFile.Error($"Erro inesperado ao tentar parar o serviço {_serviceNames[option]}: {ex.Message}", ex);  
                }

            });
            await task;
        }

        public async static Task StopAllServices(bool isImoveis)
        {
            var failures = new List<string>();
            foreach (var service in _getActiveServices(isImoveis))
            {
                try
                {
                    await ServiceStop(service.Key);
                }
                catch (Exception ex)
                {
                    LoggingFile.Error($"Falha ao parar {service.Value}", ex);
                    failures.Add(service.Value);
                }
            }
            if (failures.Any())
                throw new Exception($"{string.Join(", ", failures)}");
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
                using var sc = new ServiceController(_serviceNames[option]);
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

        public static int CartsysServicesInstalled(bool isImoveis)
        {
            int quantity = 0;
            foreach (var service in _getActiveServices(isImoveis))
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

        //Override para parar serviços especificos pelo nome do mesmo.
        public static async Task ServiceStop(string serviceName)
        {
            await Task.Run(() =>
            {
                try
                {
                    using var sc = new ServiceController(serviceName);
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                    }
                }
                catch (Exception ex)
                {
                    LoggingFile.Warning($"Não foi possível parar {serviceName}: {ex.Message}");
                }
            });
        }

        public static void DisableService(string service)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "sc.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            startInfo.ArgumentList.Add("config");
            startInfo.ArgumentList.Add(service);
            startInfo.ArgumentList.Add("start=");
            startInfo.ArgumentList.Add("disabled");

            using var process = Process.Start(startInfo);
            process?.WaitForExit();

            if (process?.ExitCode != 0)
                LoggingFile.Error($"Falha ao desabilitar {service}. Código: {process?.ExitCode}");
            else
                LoggingFile.Info($"Serviço {service} desabilitado com sucesso.");
        }
    }
}
