using System.Diagnostics;
using System.Reflection;

namespace CartsysControlPanel.Infrastructure
{

    public static class DependencyManager
    {
        private static readonly String _firebirdDependency = "CartsysControlPanel.Assets.Firebird.exe";


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
    }
}
