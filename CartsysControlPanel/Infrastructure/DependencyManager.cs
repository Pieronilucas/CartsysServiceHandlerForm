using CartsysControlPanel.Handlers;
using System.Diagnostics;
using System.Reflection;

namespace CartsysControlPanel.Infrastructure
{

    public static class DependencyManager
    {
        private static readonly String _firebirdDependency = "CartsysControlPanel.Assets.Firebird.exe";
        private static readonly String HqbirdPath = ServiceHandler.GetServiceDirectory("FirebirdServerHQBirdInstanceFB3");

        public static void FirebirdInstallable()
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

            Thread.Sleep(1000);

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
            if (File.Exists(tempPath))
            {
                try
                {
                    File.Delete(tempPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao tentar excluir o arquivo temporário do Firebird: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void setUdrDll()
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
                    MessageBox.Show($"Ocorreu um erro ao tentar copiar o arquivo udr.dll: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        public static void setFirebirdConfig()
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
                MessageBox.Show($"Ocorreu um erro ao tentar copiar o arquivo firebird.conf: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        public static void setDbCrypt()
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
                MessageBox.Show($"Ocorreu um erro ao tentar copiar o arquivo DbCrypt.conf: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }


    }
}




