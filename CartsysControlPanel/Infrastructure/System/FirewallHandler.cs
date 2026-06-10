using CartsysControlPanel.Logging;
using System.Runtime.InteropServices;

namespace CartsysControlPanel.Infrastructure.System
{
    public static class FirewallHandler
    {
        public static void OpenFirebirdPort(int port, int auxPort)
        {
            try
            {
                Type fwPolicyType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                dynamic fwPolicy = Activator.CreateInstance(fwPolicyType);

                try
                {
                    fwPolicy.Rules.Remove("Cartsys");
                    LoggingFile.Info("Regra de firewall anterior removida.");
                }
                catch (COMException comEx)
                {
                    LoggingFile.Warning($"Não foi possível remover regra anterior — pode não existir. (Código: {comEx.ErrorCode})");
                }

                dynamic rule = Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

                rule.Name = "Cartsys";
                rule.Description = $"Permite o tráfego na porta {port},{auxPort} para o Firebird";
                rule.Protocol = 6;    // TCP
                rule.LocalPorts = $"{port},{auxPort}";
                rule.Direction = 1;   // Inbound
                rule.Action = 1;      // Allow
                rule.Enabled = true;
                rule.InterfaceTypes = "All";

                fwPolicy.Rules.Add(rule);
                LoggingFile.Info("Regra de firewall para o Firebird configurada com sucesso.");
            }
            catch (UnauthorizedAccessException)
            {
                LoggingFile.Error("Permissão negada ao tentar configurar o firewall. Execute o aplicativo como administrador.");
                throw;
            }
            catch (COMException comEx)
            {
                LoggingFile.Error($"Erro ao configurar o firewall (Código: {comEx.ErrorCode}). Detalhe: {comEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Erro inesperado ao configurar o firewall.", ex);
                throw;
            }
        }
    }
}