using CartsysControlPanel.Handlers;
using System.Diagnostics;
using System.Reflection;

namespace CartsysControlPanel.Infrastructure
{

    public static class DependencyManager
    {
        private static readonly String _firebirdDependency = "CartsysControlPanel.Assets.Firebird.exe";
        private static readonly String _HqbirdPath = ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3");

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

            string targetPath = Path.Combine(_HqbirdPath, "plugins", "udr", "UDR_SC.dll");

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
            string targetPath = Path.Combine(_HqbirdPath, "firebird.conf");

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
            string targetPath = Path.Combine(_HqbirdPath, "plugins", "DbCrypt.conf");

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

        public static void setBackupFolder()
        {

            string backupFolderPath = Path.Combine(_HqbirdPath, "backup");
            string backupFolderZipPath = Path.Combine(_HqbirdPath, "backup.zip");

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
                    System.IO.Compression.ZipFile.ExtractToDirectory(backupFolderZipPath, _HqbirdPath); 

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

    }
}





