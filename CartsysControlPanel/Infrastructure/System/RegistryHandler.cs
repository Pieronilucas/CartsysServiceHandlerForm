using Microsoft.Win32;
using System.Security;

namespace CartsysControlPanel.Infrastructure.System
{
    public static class RegistryHandler
    {
        private readonly static string _userRoot = "HKEY_CURRENT_USER\\Software\\";
        public static void CreateRegistryKey(string serverName, string dbPath)
        {
            try
            {
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
                Registry.SetValue(scSistema + "Atualiza", "Caminho", $@"\\{serverName}\cartorio\");
                Registry.SetValue(scSistema + "BDS", "CaminhoSaidaArquivo", $@"\\{serverName}\cartorio\BDS\");

                // Biometria, Certificado, DAP
                Registry.SetValue(scSistema + "BIOMETRIA", "ATIVADO", "0");
                Registry.SetValue(scSistema + "Certificado", "StoreLocation", "CURRENT");
                Registry.SetValue(scSistema + "CNBDI", "CaminhoSaidaXML", "");
                Registry.SetValue(scSistema + "DAP", "CaminhoSaidaXML", @"C:\Users\Cartorio\Desktop");
                // Dicionario
                string dicKey = scSistema + @"Dicionario\Cartorio";
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
                string digKey = scSistema + "DIGITALIZACAO";
                Registry.SetValue(digKey, "ScannerPadrao", "WIA-Brother ADS-1000W");
                Registry.SetValue(digKey, "RESOLUCAO_DIGITALIZACAO", "200");

                // INTERBASE (Configurações de Banco de Dados)
                string ibKey = scSistema + "INTERBASE";
                Registry.SetValue(ibKey, "Conexao", 2, RegistryValueKind.DWord);
                Registry.SetValue(ibKey, "Protocolo", 2, RegistryValueKind.DWord);
                Registry.SetValue(ibKey, "Servidor", serverName);
                Registry.SetValue(ibKey, "DBCartorio", dbPath);
                Registry.SetValue(ibKey, "TipoBanco", "F");
                Registry.SetValue(ibKey, "Usuario", "SYSDBA");
                Registry.SetValue(ibKey, "Senha", "?3!&7 97+");

                // Notificação e SeloE
                Registry.SetValue(scSistema + "Notificacao", "ExibirNotificacao", 1, RegistryValueKind.DWord);
                Registry.SetValue(scSistema + "SeloE", "CaminhoSaidaXML", $@"\\{serverName}\cartorio\LOG_SELOE\");

                MessageBox.Show("Configurações de registro aplicadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SecurityException)
            {
                MessageBox.Show("O usuário atual não possui permissões suficientes para gravar no Registro do Windows.", "Erro de Segurança", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Acesso negado ao tentar gravar as chaves. Certifique-se de que o programa está rodando como Administrador.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Erro de I/O ao acessar o Registro: {ioEx.Message}", "Erro de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show($"Erro de argumento (Caminho do registro inválido): {argEx.Message}", "Erro de Parâmetro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro inesperado ao gravar no registro: {ex.Message}", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
