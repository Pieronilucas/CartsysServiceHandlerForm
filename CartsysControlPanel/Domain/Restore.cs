using CartsysControlPanel.Infrastructure.System;
using CartsysControlPanel.Logging;
using System.Diagnostics;

namespace CartsysControlPanel.Domain
{
    public static class Restore
    {
        private static string _caminhoGbak = ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3") + @"\gbak.exe";
        private static string _caminhoGbakCrypt = ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3") + @"\backup" + @"\gbak.exe";

        public static async Task RestoreSemCrypt(string caminhoBanco, string caminhoSaida, string user, string password, int pagination)
        {
            LoggingFile.Info($"Iniciando restore sem criptografia: '{caminhoBanco}' → '{caminhoSaida}'");

            string comando = $"{_caminhoGbak} -user {user} -pas {password} -c -v -page_size {pagination} \"{caminhoBanco}\" \"localhost:{caminhoSaida}\"";
            

            var processo = new Process();
            processo.StartInfo.FileName = "cmd.exe";
            processo.StartInfo.Arguments = $"/c {comando}";
            processo.StartInfo.UseShellExecute = true;

            processo.Start();
            await Task.Run(() => processo.WaitForExit());

            if (processo.ExitCode != 0)
                throw new Exception($"Restore falhou. Código de saída: {processo.ExitCode}");

            LoggingFile.Info("Restore sem criptografia concluído com sucesso.");
        }

        public static async Task RestoreComCrypt(string caminhoBanco, string caminhoSaida, string user, string password, int pagination)
        {
            LoggingFile.Info($"Iniciando restore com criptografia: '{caminhoBanco}' → '{caminhoSaida}'");

            string utf8Key = ConversaoUTF8.Instance.ValorD;
            string[] partes = utf8Key.Split(':');
  

            string comando = $"{_caminhoGbakCrypt} -keyname {partes[0]} -key \"{partes[1]}\", -user {user} -pas {password} -c -v -page_size {pagination} \"{caminhoBanco}\" \"localhost:{caminhoSaida}\"";


            var processo = new Process();
            processo.StartInfo.FileName = "cmd.exe";
            processo.StartInfo.Arguments = $"/c {comando}";
            processo.StartInfo.UseShellExecute = true;

            processo.Start();
            await Task.Run(() => processo.WaitForExit());

            if (processo.ExitCode != 0)
                throw new Exception($"Restore com criptografia falhou. Código de saída: {processo.ExitCode}");

            LoggingFile.Info("Restore com criptografia concluído com sucesso.");
        }
    }
}