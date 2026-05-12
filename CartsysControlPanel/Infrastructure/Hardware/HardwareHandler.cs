using CartsysControlPanel.Logging;
using System.Management;
using System.Runtime.InteropServices;

namespace CartsysControlPanel.Infrastructure.Hardware
{
    public static class HardwareHandler
    {
        public static string GetHdSerial()
        {
            try
            {
                string drive = "C";
                using (var disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive + ":\""))
                {
                    disk.Get();
                    return disk["VolumeSerialNumber"].ToString();
                }
                    
            }
            catch (ManagementException mEx)
            {
                // Erro específico do WMI (ex: repositório corrompido ou classe não encontrada)
                LoggingFile.Error("Erro de gerenciamento ao acessar informações de hardware.", mEx);
                throw;
            }
            catch (COMException comEx)
            {
                // Erro de comunicação com os componentes do Windows
                LoggingFile.Error("Erro de comunicação ao acessar informações de hardware.", comEx);
                throw;
            }
            catch (UnauthorizedAccessException uEx)
            {
                // Caso o acesso ao WMI esteja bloqueado por diretivas de segurança
                LoggingFile.Error("Acesso negado ao obter informações de hardware. Verifique as permissões do aplicativo.", uEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error("Erro inesperado ao obter informações de hardware.", ex);
                throw;
            }
        }
    }
}
