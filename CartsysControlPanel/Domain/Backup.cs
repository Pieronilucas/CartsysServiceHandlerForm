using CartsysControlPanel.Infrastructure.System;
using CartsysControlPanel.Logging;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CartsysControlPanel.Domain
{
    public static class Backup
    {
        private static string _caminhoGbak = ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3") + @"\gbak.exe";
        private static string _caminhoGbakCrypt = ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3") + @"\backup" + @"\gbak.exe";

        public static async Task BackupSemCrypt(string caminhoBanco, string caminhoSaida, string user, string password)
        {
            LoggingFile.Info($"Iniciando backup sem criptografia: '{caminhoBanco}' → '{caminhoSaida}'");

            string comando = $"{_caminhoGbak} -user {user} -pas {password} -b -g \"localhost:{caminhoBanco}\" \"{caminhoSaida}\"";
 

            var processo = new Process();
            processo.StartInfo.FileName = "cmd.exe";
            processo.StartInfo.Arguments = $"/c {comando}";
            processo.StartInfo.RedirectStandardOutput = true;
            processo.StartInfo.RedirectStandardError = true;
            processo.StartInfo.UseShellExecute = false;
            processo.StartInfo.CreateNoWindow = true;

            processo.Start();

            string output = await processo.StandardOutput.ReadToEndAsync();
            string error = await processo.StandardError.ReadToEndAsync();


            await processo.WaitForExitAsync();
            if (processo.ExitCode != 0 && processo.ExitCode != -1073741819)
                throw new Exception($"Backup falhou. Código de saída: {processo.ExitCode}. \n erro: {error}");
            if (processo.ExitCode == -1073741819)
                throw new Exception($"Backup falhou. Código de saída: {processo.ExitCode}. Verifique se o banco não está criptografado.");

            LoggingFile.Info("Backup sem criptografia concluído com sucesso.");
        }

        public static async Task BackupComCrypt(string caminhoBanco, string caminhoSaida, string user, string password)
        {
            LoggingFile.Info($"Iniciando backup com criptografia: '{caminhoBanco}' → '{caminhoSaida}'");

            string utf8Key = ConversaoUTF8.Instance.ValorD;
            string[] partes = utf8Key.Split(':');
            string keyName = partes[0].Trim();
            string keyValue = partes[1].Trim().TrimEnd(',');

            string comando = $"{_caminhoGbakCrypt} -keyname {keyName} -key \"{keyValue}\", -user {user} -pas {password} -b -g \"localhost:{caminhoBanco}\" \"{caminhoSaida}\"";

            var processo = new Process();
            processo.StartInfo.FileName = "cmd.exe";
            processo.StartInfo.Arguments = $"/c {comando}";
            processo.StartInfo.RedirectStandardOutput = true;
            processo.StartInfo.RedirectStandardError = true;
            processo.StartInfo.UseShellExecute = false;
            processo.StartInfo.CreateNoWindow = true;

            processo.Start();

            string output = await processo.StandardOutput.ReadToEndAsync();
            string error = await processo.StandardError.ReadToEndAsync();


            await processo.WaitForExitAsync();


            if (processo.ExitCode != 0)
                throw new Exception($"Backup com criptografia falhou. Código de saída: {processo.ExitCode}. \n erro: {error}");

            LoggingFile.Info("Backup com criptografia concluído com sucesso.");
        }
    }
}