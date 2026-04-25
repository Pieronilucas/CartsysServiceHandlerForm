using NetFwTypeLib;
using System.Runtime.InteropServices;

namespace CartsysControlPanel.Handlers
{
    public static class FirewallHandler
    {
        private static Type type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        private static INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(type);

        public static void OpenFirebirdPort()
        {
            try
            {
                try
                {
                    fwPolicy2.Rules.Remove("Cartsys");
                }
                catch (COMException comEx)
                {
                    MessageBox.Show($"Falha ao acessar as políticas do Firewall. O serviço pode estar desativado. Erro: {comEx.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Type ruleType = Type.GetTypeFromProgID("HNetCfg.FWRule");

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

                MessageBox.Show("Portas 3050-3051 abertas com sucesso no firewall do Windows.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Acesso negado. O sistema precisa ser executado como Administrador para modificar o Firewall.", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (COMException comEx)
            {
                MessageBox.Show($"Erro de integração com o Firewall do Windows. (Código: {comEx.ErrorCode})\nDetalhe: {comEx.Message}", "Erro COM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro inesperado ao configurar o firewall: {ex.Message}", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
