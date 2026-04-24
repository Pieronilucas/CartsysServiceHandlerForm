using System.Management;
using System.Runtime.InteropServices;

namespace CartsysControlPanel
{
    public static class GetSerialHd
    {
        public static string GetHdSerial()
        {
            try
            {
                string drive = "C";
                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\"");
                disk.Get();
                return disk["VolumeSerialNumber"].ToString();
            }
            catch (ManagementException mEx)
            {
                // Erro específico do WMI (ex: repositório corrompido ou classe não encontrada)
                MessageBox.Show($"Erro no WMI ao obter serial: {mEx.Message}", "Erro de Gerenciamento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (COMException comEx)
            {
                // Erro de comunicação com os componentes do Windows
                MessageBox.Show($"Erro de comunicação COM: {comEx.Message}", "Erro de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException)
            {
                // Caso o acesso ao WMI esteja bloqueado por diretivas de segurança
                MessageBox.Show("Acesso negado ao tentar ler informações de hardware.", "Erro de Permissão", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha inesperada ao obter ID do disco: {ex.Message}", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;
        }
    }
}
