using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace CartsysControlPanel.Handlers
{
    public static class NetworkHandler
    {
        private static bool _isDhcpEnabled;
        private static string _ipAddress;
        public static string serverName;
        private readonly static string _DirectDownloadUrl = "https://ib-aid.com/download/hqbird/hqbirdwindows.zip";
        private readonly static string _downloadPageUrl = "https://ib-aid.com/br/hqbird-download/";

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

        

        public static async Task<bool> IsLinkValid(string url)
        {
            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(7);

                var request = new HttpRequestMessage(HttpMethod.Head, url);
                using var response = await client.SendAsync(request);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        private static async Task<bool> ValidateAndOpen(string url)
        {
            if (await IsLinkValid(url))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    return true;
                }
                catch (Win32Exception) 
                { 
                    return false;
                }
            }
            return false;
        }

        public static async Task<bool> RedirectToHqbird(bool isDirectDownload)
        {
            string url = isDirectDownload ? _DirectDownloadUrl : _downloadPageUrl;
            return await ValidateAndOpen(url);
        }
    }
}
