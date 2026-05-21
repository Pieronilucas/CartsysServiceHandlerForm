using CartsysControlPanel.Infrastructure.Network;
using CartsysControlPanel.Logging;
using Microsoft.Win32;
using System.Security;

namespace CartsysControlPanel.Infrastructure.System
{
    public static class RegistryHandler
    {
        private readonly static string _userRoot = "HKEY_CURRENT_USER\\Software\\";
        public static void CreateRegistryKey(string dbPath, string? cartorioPath = null)
        {
            try
            {
                string _serverName = NetworkHandler.ServerName();

                if (_serverName == null)
                {
                    LoggingFile.Error("Não foi possível obter o nome do servidor. Verifique a conexão de rede e as configurações do sistema.");
                }

                string scSistema = _userRoot + @"SC Sistemas\";

                // ACESSO
                Registry.SetValue(scSistema + "ACESSO", "Porta", "3051");
                Registry.SetValue(scSistema + "ACESSO", "ATIVADO", "0");

                // ARISP
                string arispKey = scSistema + @"ARISP\Enviar";
                Registry.SetValue(arispKey, "Intervalo", 1000, RegistryValueKind.DWord);
                Registry.SetValue(arispKey, "Tentativas", 60, RegistryValueKind.DWord);

                string arispRetorno = scSistema + @"ARISP\RetornoIndisponibilidade";
                Registry.SetValue(arispRetorno, "Intervalo", 1000, RegistryValueKind.DWord);
                Registry.SetValue(arispRetorno, "Tentativas", 60, RegistryValueKind.DWord);

                // Atualiza e BDS
                Registry.SetValue(scSistema + "Atualiza", "Caminho", cartorioPath);
                Registry.SetValue(scSistema + "BDS", "CaminhoSaidaArquivo", $@"\\{_serverName}\cartorio\BDS\");

                // Biometria, Certificado, DAP
                Registry.SetValue(scSistema + "BIOMETRIA", "ATIVADO", "0");
                Registry.SetValue(scSistema + "Certificado", "StoreLocation", "CURRENT");
                Registry.SetValue(scSistema + "CNBDI", "CaminhoSaidaXML", "");
                Registry.SetValue(scSistema + "DAP", "CaminhoSaidaXML", @"C:\Users\Cartorio\Desktop");
                // Dicionario
                string dicKey = scSistema + @"Dicionario\Cartorio";
                Registry.SetValue(dicKey, "_FirstRun", "+");
                Registry.SetValue(dicKey, "_Main_count", "1");
                Registry.SetValue(dicKey, "_Main_0", $"\\\\{_serverName}\\cartorio\\Dicionario.adm");
                Registry.SetValue(dicKey, "_Custom_count", "1");
                Registry.SetValue(dicKey, "_Custom_0", $"\\\\{_serverName}\\cartorio\\DicPersonal.adu");
                Registry.SetValue(dicKey, "_MSWordCustom_count", "0");
                Registry.SetValue(dicKey, "_ActiveCustom", $"\\\\{_serverName}\\cartorio\\DicPersonal.adu");
                Registry.SetValue(dicKey, "_soUpcase", "-");
                Registry.SetValue(dicKey, "_soNumbers", "-");
                Registry.SetValue(dicKey, "_soHTML", "-");
                Registry.SetValue(dicKey, "_soInternet", "+");
                Registry.SetValue(dicKey, "_soQuoted", "-");
                Registry.SetValue(dicKey, "_soAbbreviations", "+");
                Registry.SetValue(dicKey, "_soPrimaryOnly", "-");
                Registry.SetValue(dicKey, "_soRepeated", "+");
                Registry.SetValue(dicKey, "_soDUalCaps", "-");
                Registry.SetValue(dicKey, "_soLiveSpelling", "+");
                Registry.SetValue(dicKey, "_soLiveCorrect", "+");
                Registry.SetValue(dicKey, "_soUser1", "-");
                Registry.SetValue(dicKey, "_soUser2", "-");
                Registry.SetValue(dicKey, "_soUser3", "-");
                Registry.SetValue(dicKey, "_soUser4", "-");
                Registry.SetValue(dicKey, "_DialogX", "1005");
                Registry.SetValue(dicKey, "_DialogY", "404");
                Registry.SetValue(dicKey, "_NewPaths_count", "0");
                Registry.SetValue(dicKey, "_UserData_count", "0");

                // Digitalização
                string digKey = scSistema + "DIGITALIZACAO";
                Registry.SetValue(digKey, "ScannerPadrao", "WIA-Brother ADS-1000W");
                Registry.SetValue(digKey, "RESOLUCAO_DIGITALIZACAO", "200");

                // INTERBASE (Configurações de Banco de Dados)
                string ibKey = scSistema + "INTERBASE";
                Registry.SetValue(ibKey, "Conexao", 2, RegistryValueKind.DWord);
                Registry.SetValue(ibKey, "Protocolo", 2, RegistryValueKind.DWord);
                Registry.SetValue(ibKey, "Servidor", _serverName);
                Registry.SetValue(ibKey, "DBCartorio", dbPath);
                Registry.SetValue(ibKey, "TipoBanco", "F");
                Registry.SetValue(ibKey, "Usuario", "SYSDBA");
                Registry.SetValue(ibKey, "Senha", "?3!&7 97+");

                // Notificação e SeloE
                Registry.SetValue(scSistema + "Notificacao", "ExibirNotificacao", 1, RegistryValueKind.DWord);
                Registry.SetValue(scSistema + "SeloE", "CaminhoSaidaXML", $@"\\{_serverName}\cartorio\LOG_SELOE\");

                LoggingFile.Info("Chaves de registro criadas/atualizadas com sucesso.");
            }
            catch (SecurityException sEx)
            {
                LoggingFile.Error($"Permissões insuficientes para gravar no Registro do Windows. {sEx.Message}", sEx);
                throw;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                LoggingFile.Error($"Acesso negado ao tentar gravar no Registro do Windows. {uaEx.Message}", uaEx);
                throw;
            }
            catch (IOException ioEx)
            {
                LoggingFile.Error($"Erro de I/O ao tentar gravar no Registro do Windows. {ioEx.Message}", ioEx);
                throw;
            }
            catch (ArgumentException argEx)
            {
                LoggingFile.Error($"Argumento inválido ao tentar gravar no Registro do Windows. {argEx.Message}", argEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Erro inesperado ao tentar gravar no Registro do Windows. {ex.Message}", ex);
                throw;
            }
        }
    }
}
