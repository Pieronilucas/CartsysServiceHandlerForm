using Microsoft.Win32;
using System.Numerics;

namespace CartsysControlPanel
{
    public static class RegeditHandler
    {
        private readonly static string _userRoot = "HKEY_CURRENT_USER\\Software\\";
        public static void CreateRegistryKey(string serverName, string dbPath)
        {
            try {
   

                    // ACESSO
                    Registry.SetValue(_userRoot + "SC Sistemas\\ACESSO", "Porta", "3051");
                    Registry.SetValue(_userRoot + "SC Sistemas\\ACESSO", "ATIVADO", "0");

                    // ARISP
                    Registry.SetValue(_userRoot + "SC Sistemas\\ARISP\\Enviar", "Intervalo", 1000, RegistryValueKind.DWord);
                    Registry.SetValue(_userRoot + "SC Sistemas\\ARISP\\Enviar", "Tentativas", 60, RegistryValueKind.DWord);

                    Registry.SetValue(_userRoot + "SC Sistemas\\ARISP\\RetornoIndisponibilidade", "Intervalo", 1000, RegistryValueKind.DWord);
                    Registry.SetValue(_userRoot + "SC Sistemas\\ARISP\\RetornoIndisponibilidade", "Tentativas", 60, RegistryValueKind.DWord);

                    // Atualiza
                    Registry.SetValue(_userRoot + "SC Sistemas\\Atualiza", "Caminho", $"\\\\{serverName}\\cartorio\\");
                    Registry.SetValue(_userRoot + "SC Sistemas\\BDS", "CaminhoSaidaArquivo", $"\\\\{serverName}\\cartorio\\BDS\\");

                    // Caminhos (Certificado, CNBDI, DAP)
                    Registry.SetValue(_userRoot + "SC Sistemas\\BIOMETRIA", "ATIVADO", "0");

                    Registry.SetValue(_userRoot + "SC Sistemas\\Certificado", "StoreLocation", "CURRENT");

                    Registry.SetValue(_userRoot + "SC Sistemas\\CNBDI", "CaminhoSaidaXML", "");

                    Registry.SetValue(_userRoot + "SC Sistemas\\DAP", "CaminhoSaidaXML", @"C:\Users\Cartorio\Desktop");

                    // Dicionario
                    string dicKey = Path.Combine(_userRoot, "SC Sistemas\\Dicionario\\%AppName%\\Cartorio");
                    Registry.SetValue(dicKey, "_FirstRun", "+");
                    Registry.SetValue(dicKey, "_Main_count", "1");
                    Registry.SetValue(dicKey, "_Main_0", $"\\\\{serverName}\\cartorio\\Dicionario.adm");
                    Registry.SetValue(dicKey, "_Custom_count", "1");
                    Registry.SetValue(dicKey, "_Custom_0", $"\\\\{serverName}\\cartorio\\DicPersonal.adu");
                    Registry.SetValue(dicKey, "_MSWordCustom_count", "0");
                    Registry.SetValue(dicKey, "_ActiveCustom", $"\\\\{serverName}\\cartorio\\DicPersonal.adu");
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
                    string digKey = _userRoot + "SC Sistemas\\DIGITALIZACAO";
                    Registry.SetValue(digKey, "ScannerPadrao", "WIA-Brother ADS-1000W");
                    Registry.SetValue(digKey, "CORES", "ieap8BitGrayScale");
                    Registry.SetValue(digKey, "ORIENTACAO", "ieaoPortrait");
                    Registry.SetValue(digKey, "ROTACAO", "iearNone");
                    Registry.SetValue(digKey, "CONTRASTE", "0");
                    Registry.SetValue(digKey, "BRILHO", "0");
                    Registry.SetValue(digKey, "LIMIAR", "0");
                    Registry.SetValue(digKey, "ASSISTENTE_DIGITALIZACAO", "-1");
                    Registry.SetValue(digKey, "FRENTE_VERSO_DIGITALIZACAO", "0");
                    Registry.SetValue(digKey, "SEL_SCANNER_DIGITALIZACAO", "-1");
                    Registry.SetValue(digKey, "CONVERTEJPEGTOTIF", "0");
                    Registry.SetValue(digKey, "RESOLUCAO_DIGITALIZACAO", "200");

                    // INTERBASE (Configurações de Banco de Dados)
                    Registry.SetValue(_userRoot + "SC Sistemas\\INTERBASE", "Conexao", 2, RegistryValueKind.DWord);
                    Registry.SetValue(_userRoot + "SC Sistemas\\INTERBASE", "Protocolo", 2, RegistryValueKind.DWord);
                    Registry.SetValue(_userRoot + "SC Sistemas\\INTERBASE", "Servidor", serverName);
                    Registry.SetValue(_userRoot + "SC Sistemas\\INTERBASE", "DBCartorio", dbPath);
                    Registry.SetValue(_userRoot + "SC Sistemas\\INTERBASE", "TipoBanco", "F");
                    Registry.SetValue(_userRoot + "SC Sistemas\\INTERBASE", "Usuario", "SYSDBA");
                    Registry.SetValue(_userRoot + "SC Sistemas\\INTERBASE", "Senha", "?3!&7 97+");

                    // Notificação e SeloE
                    Registry.SetValue(_userRoot + "SC Sistemas\\Notificacao", "ExibirNotificacao", 1, RegistryValueKind.DWord);
                    Registry.SetValue(_userRoot + "SC Sistemas\\SeloE", "CaminhoSaidaXML", $"\\\\{serverName}\\cartorio\\LOG_SELOE\\");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao tentar criar as chaves de registro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
