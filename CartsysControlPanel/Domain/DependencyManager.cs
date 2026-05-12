using CartsysControlPanel.Infrastructure.System;
using CartsysControlPanel.Logging;
using System.Diagnostics;
using System.Reflection;

namespace CartsysControlPanel.Domain
{

    public static class DependencyManager
    {
        private static readonly String _firebirdDependency = "CartsysControlPanel.Assets.Firebird.exe";

        public static void InstallFirebird()
        {
            string tempPath = Path.Combine(Path.GetTempPath(), _firebirdDependency);
            if (!File.Exists(tempPath))
            {
                using Stream? resourceStream = Assembly
                    .GetExecutingAssembly()
                    .GetManifestResourceStream(_firebirdDependency);

                if (resourceStream == null)
                {
                    throw new FileNotFoundException($"O recurso incorporado '{_firebirdDependency}' não foi encontrado.");
                }

                using FileStream fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write);
                resourceStream.CopyTo(fileStream);
                LoggingFile.Info($"O recurso '{_firebirdDependency}' foi extraído para '{tempPath}'.");
            }
            

            var process = new ProcessStartInfo
            {
                FileName = tempPath,
                Arguments = "/quiet /norestart",
                UseShellExecute = true,
                Verb = "runas"
            };

            using (var p = Process.Start(process))
            {
                p?.WaitForExit();
                int? exitCode = p?.ExitCode;
                if (exitCode != 0)
                    LoggingFile.Warning($"Instalação do Firebird concluída com código de saída inesperado: {exitCode}.");
                else
                    LoggingFile.Info("Instalação do Firebird concluída com sucesso.");
            }
            TryDeleteFile(tempPath);
        }

        public static void SetUdrDll()
        {

            string targetPath = Path.Combine(HqbirdPath, "plugins", "udr", "UDR_SC.dll");

            if (!File.Exists(targetPath))
            {
                try
                {
                    using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CartsysControlPanel.Assets.UDR_SC.dll"))
                    {
                        if (resourceStream == null)
                        {
                            throw new FileNotFoundException("O recurso incorporado 'UDR_SC.dll' não foi encontrado.");
                        }
                        LoggingFile.Info($"Extraindo 'UDR_SC.dll' para '{targetPath}'...");
                        using (var fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                        {
                            resourceStream.CopyTo(fileStream);
                        }
                        LoggingFile.Info($"Extração de 'UDR_SC.dll' concluída com sucesso.");
                    }
                }
                catch (IOException iEx)
                {
                    LoggingFile.Error($"Falha de I/O ao extrair UDR_SC.dll. Detalhes: {iEx.Message}", iEx);
                    throw;
                }
                catch (Exception ex)
                {
                    LoggingFile.Error($"Erro inesperado ao extrair UDR_SC.dll. Detalhes: {ex.Message}", ex);
                    throw;
                }
            }

        }

        public static void SetFirebirdConfig()
        {
            string targetPath = Path.Combine(HqbirdPath, "firebird.conf");

            try
            {
                using (var ResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CartsysControlPanel.Assets.firebird.conf"))
                {
                    if (ResourceStream == null)
                    {
                        throw new FileNotFoundException("O recurso incorporado 'firebird.conf' não foi encontrado.");
                    }
                    LoggingFile.Info($"Extraindo 'firebird.conf' para '{targetPath}'...");
                    using (var fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                    {
                        ResourceStream.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    LoggingFile.Info($"Extração de 'firebird.conf' concluída com sucesso.");
                }
            }
            catch (IOException iEx)
            {
                LoggingFile.Error($"Falha de I/O ao configurar 'firebird.conf'. Detalhes: {iEx.Message}", iEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Erro ao configurar 'firebird.conf'. Detalhes: {ex.Message}", ex);
                throw;
            }


        }

        public static void SetDbCrypt()
        {
            string targetPath = Path.Combine(HqbirdPath, "plugins", "DbCrypt.conf");

            try
            {
                using (var ResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CartsysControlPanel.Assets.DbCrypt.conf"))
                {
                    if (ResourceStream == null)
                    {
                        throw new FileNotFoundException("O recurso incorporado 'DbCrypt.conf' não foi encontrado.");
                    }
                    LoggingFile.Info($"Extraindo 'DbCrypt.conf' para '{targetPath}'...");
                    using (var fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                    {
                        ResourceStream.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    LoggingFile.Info($"Configuração de 'DbCrypt.conf' concluída com sucesso.");
                }
            }
            catch (IOException iEx)
            {
                LoggingFile.Error($"Falha de I/O ao configurar 'DbCrypt.conf'. Detalhes: {iEx.Message}", iEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Erro ao configurar 'DbCrypt.conf'. Detalhes: {ex.Message}", ex);
                throw;
            }


        }

        public static void SetBackupFolder()
        {

            string backupFolderPath = Path.Combine(HqbirdPath, "backup");
            string backupFolderZipPath = Path.Combine(HqbirdPath, "backup.zip");

            if (Directory.Exists(backupFolderPath)) { return; }

            try
            {
                using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CartsysControlPanel.Assets.backup.zip"))
                {
                    if (resourceStream == null)
                    {
                        throw new FileNotFoundException("A pasta de backups não foi encontrada não foi encontrado nos arquivos acoplados.");
                    }
                    using (var fileStream = new FileStream(backupFolderZipPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        resourceStream.CopyTo(fileStream);
                    }
                    LoggingFile.Info($"A pasta de backup foi copiada para '{backupFolderZipPath}'.");
                }
                if (File.Exists(backupFolderZipPath))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(backupFolderZipPath, HqbirdPath);
                    LoggingFile.Info($"A pasta de backup foi extraída para '{HqbirdPath}'.");
                    TryDeleteFile(backupFolderZipPath);
                }


            }
            catch (IOException iEx)
            {
                LoggingFile.Error($"Falha de I/O ao configurar a pasta de backup. Detalhes: {iEx.Message}", iEx);
                throw;
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Erro ao configurar a pasta de backup. Detalhes: {ex.Message}", ex);
                throw;
            }

        }

        private static void TryDeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch(IOException iEx)
            {
                LoggingFile.Error($"Falha de I/O ao tentar excluir o arquivo temporário '{filePath}'. Detalhes: {iEx.Message}", iEx);      
            }
            catch (Exception ex)
            {
                LoggingFile.Error($"Erro inesperado ao tentar excluir o arquivo temporário '{filePath}'. Detalhes: {ex.Message}", ex);
            }
        }
        private static string HqbirdPath =>
            ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3")
            ?? throw new InvalidOperationException(
            "Diretório do HQBird não encontrado. O serviço 'FirebirdServerHQBirdInstanceFB3' está instalado?");
    }
}





