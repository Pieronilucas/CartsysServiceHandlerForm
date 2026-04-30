using CartsysControlPanel.Infrastructure.System;
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
                fileStream.Flush();

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
                        using (var fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                        {
                            resourceStream.CopyTo(fileStream);
                            fileStream.Flush();
                        }
                    }
                }
                catch (Exception ex)
                {
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
                    using (var fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                    {
                        ResourceStream.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
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
                    using (var fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                    {
                        ResourceStream.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
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
                }
                if (File.Exists(backupFolderZipPath))
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(backupFolderZipPath, HqbirdPath);

                    TryDeleteFile(backupFolderZipPath);
                }


            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao configurar pasta de backup: {ex.Message}", ex);
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
            catch (Exception ex)
            {
                throw new Exception($"Falha ao tentar excluir o arquivo temporário '{filePath}': {ex.Message}", ex);
            }
        }
        private static string HqbirdPath =>
            ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3")
            ?? throw new InvalidOperationException(
            "Diretório do HQBird não encontrado. O serviço 'FirebirdServerHQBirdInstanceFB3' está instalado?");
    }
}





