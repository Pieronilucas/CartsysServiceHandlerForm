using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace CartsysControlPanel
{
    public static class NetworkHandler
    {
        private static bool _isDhcpEnabled;
        private static string _ipAddress;
        public static string serverName;

        private static void GetNetworkInfo()
        {
            try
            {
                var interfaces = NetworkInterface.GetAllNetworkInterfaces()
                .Where(ni => ni.OperationalStatus == OperationalStatus.Up)

                .Where(ni => ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Where(ni => !ni.Description.Contains("Virtual", StringComparison.OrdinalIgnoreCase))
                .Where(ni => !ni.Description.Contains("VPN", StringComparison.OrdinalIgnoreCase))
                .Where(ni => !ni.Description.Contains("Pseudo", StringComparison.OrdinalIgnoreCase));

                foreach (var ni in interfaces)
                {
                    var props = ni.GetIPProperties();


                    var hasGateway = props.GatewayAddresses.Any();
                    if (!hasGateway) continue;
                    var ip = props.UnicastAddresses.FirstOrDefault(address =>
                        address.Address.AddressFamily == AddressFamily.InterNetwork);
                    _ipAddress = ip?.Address.ToString();

                    try
                    {
                        _isDhcpEnabled = props.GetIPv4Properties()?.IsDhcpEnabled ?? false;

                    }
                    catch (NetworkInformationException)
                    {
                        // Falha ao obter propriedades específicas de IPv4
                        _isDhcpEnabled = false;
                    }
                }
            }
            catch (NetworkInformationException netEx)
            {
                MessageBox.Show($"Erro ao acessar informações de rede: {netEx.Message}", "Erro de Rede", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha inesperada ao mapear rede: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static string ServerName()
        {
            GetNetworkInfo();
            if (_isDhcpEnabled)
            {
                return serverName = Dns.GetHostName();
            }
            return serverName = _ipAddress;
        }
    }
}
