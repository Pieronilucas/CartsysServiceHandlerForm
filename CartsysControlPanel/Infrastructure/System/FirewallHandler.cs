using CartsysControlPanel.Logging;
using NetFwTypeLib;
using System.Runtime.InteropServices;

namespace CartsysControlPanel.Infrastructure.System
{
    public static class FirewallHandler
    {
        private static Type type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        public static void OpenFirebirdPort()
        {
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(type);
            try
            {
                try
                {
                    fwPolicy2.Rules.Remove("Cartsys");
                }
                catch (COMException comEx)
                {
                    LoggingFile.Error($"Erro ao tentar remover regra de firewall existente. (Código: {comEx.ErrorCode})\nDetalhe: {comEx.Message}");
                }

                INetFwRule2 firewallRule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

                firewallRule.Name = "Cartsys";
                firewallRule.Description = "Permite o tráfego na porta 3050-3051 para o Firebird";
                firewallRule.Protocol = (int)NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;

                firewallRule.LocalPorts = "3050-3051";

                firewallRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                firewallRule.Enabled = true;
                firewallRule.InterfaceTypes = "All";

                fwPolicy2.Rules.Add(firewallRule);

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
                LoggingFile.Error($"Erro inesperado ao configurar o firewall. Detalhe: {ex.Message}", ex);
                throw;
            }
        }
    }
}
