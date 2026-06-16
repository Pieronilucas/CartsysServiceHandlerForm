using CartsysControlPanel.Infrastructure.System;
using CartsysControlPanel.Logging;
using System.Diagnostics;

namespace CartsysControlPanel.Domain
{
    public static class Backup
    {
        private static string _caminhoGbak = ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3") + @"\gbak.exe";
        private static string _caminhoGbakCrypt = ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3") + @"\backup" + @"\gbak.exe";

        public static async Task BackupSemCrypt(string caminhoBanco, string caminhoSaida, string user, string password)
        {
            LoggingFile.Info($"Iniciando backup sem criptografia: '{caminhoBanco}' → '{caminhoSaida}'");

            string comando = $"{_caminhoGbak} -user {user} -pas {password} -b -g -v \"localhost:{caminhoBanco}\" \"{caminhoSaida}\"";
 

            var processo = new Process();
            processo.StartInfo.FileName = "cmd.exe";
            processo.StartInfo.Arguments = $"/c {comando}";
            processo.StartInfo.UseShellExecute = true;

            processo.Start();
            await Task.Run(() => processo.WaitForExit());

            if (processo.ExitCode != 0)
                throw new Exception($"Backup falhou. Código de saída: {processo.ExitCode}");

            LoggingFile.Info("Backup sem criptografia concluído com sucesso.");
        }

        public static async Task BackupComCrypt(string caminhoBanco, string caminhoSaida, string user, string password)
        {
            LoggingFile.Info($"Iniciando backup com criptografia: '{caminhoBanco}' → '{caminhoSaida}'");

            string utf8Key = ConversaoUTF8.Instance.ValorD;
            string[] partes = utf8Key.Split(':');
            string keyName = partes[0].Trim();
            string keyValue = partes[1].Trim().TrimEnd(',');

            string comando = $"{_caminhoGbakCrypt} -keyname {keyName} -key \"{keyValue}\", -user {user} -pas {password} -b -g -v \"localhost:{caminhoBanco}\" \"{caminhoSaida}\"";

            var processo = new Process();
            processo.StartInfo.FileName = "cmd.exe";
            processo.StartInfo.Arguments = $"/c {comando}";
            processo.StartInfo.UseShellExecute = true;

            processo.Start();
            await Task.Run(() => processo.WaitForExit());

            if (processo.ExitCode != 0)
                throw new Exception($"Backup com criptografia falhou. Código de saída: {processo.ExitCode}");

            LoggingFile.Info("Backup com criptografia concluído com sucesso.");
        }
    }
}