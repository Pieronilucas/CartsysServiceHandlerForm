using CartsysControlPanel.Logging;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace CartsysControlPanel.Infrastructure.Network
{
    public static class NetworkHandler
    {
        private static bool _isDhcpEnabled;
        private static string _ipAddress;
        private readonly static string _DirectDownloadUrl = "https://ib-aid.com/download/hqbird/hqbirdwindows.zip";
        private readonly static string _downloadPageUrl = "https://ib-aid.com/br/hqbird-download/";
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(7)
        };

        private static void GetNetworkInfo()
        {
            var validInterface = NetworkInterface.GetAllNetworkInterfaces()
        .Where(ni => ni.OperationalStatus == OperationalStatus.Up)
        .Where(ni => ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
        .Where(ni => !ni.Description.Contains("Virtual", StringComparison.OrdinalIgnoreCase))
        .Where(ni => !ni.Description.Contains("VPN", StringComparison.OrdinalIgnoreCase))
        .Where(ni => !ni.Description.Contains("Pseudo", StringComparison.OrdinalIgnoreCase))
        .FirstOrDefault(ni => ni.GetIPProperties().GatewayAddresses.Any());

            if (validInterface == null)
            {
                LoggingFile.Warning("Nenhuma interface de rede válida encontrada.");
                return;
            }

            var props = validInterface.GetIPProperties();
            _ipAddress = props.UnicastAddresses
                .FirstOrDefault(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
                ?.Address.ToString();

            try
            {
                _isDhcpEnabled = props.GetIPv4Properties()?.IsDhcpEnabled ?? false;
            }
            catch (NetworkInformationException)
            {
                LoggingFile.Warning($"Não foi possível determinar DHCP para '{validInterface.Name}'. Assumindo desabilitado.");
                _isDhcpEnabled = false;
            }
        }


        public static string? ServerName()
        {
            GetNetworkInfo();
            if (_isDhcpEnabled)
            {
                return Dns.GetHostName();
            }

            if (_ipAddress == null)
            {
                LoggingFile.Warning("IP não determinado. Nenhuma interface válida com gateway encontrada.");
                return null;
            }
            return _ipAddress;
        }



        public static async Task<bool> IsLinkValid(string url)
        {
            using var client = _httpClient;

            try
            {

                client.Timeout = TimeSpan.FromSeconds(7);

                var request = new HttpRequestMessage(HttpMethod.Head, url);
                using var response = await client.SendAsync(request);

                return response.IsSuccessStatusCode;
            }
            catch
            {
                LoggingFile.Warning($"Falha ao validar o link: {url}");
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
                    LoggingFile.Error($"Falha ao abrir o link: {url}");
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
