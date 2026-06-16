using CartsysControlPanel.Infrastructure.FileSystem;
using CartsysControlPanel.Logging;
using CartsysControlPanel.Views;
using System.Management;

namespace CartsysControlPanel.Domain
{
    public record PageSizeConfig(
    int Cartorio = 4096,
    int Arquivos = 4096,
    int Auditoria = 4096,
    int Indisponibilidade = 4096,
    int NotaFiscal = 4096
);


    public static class DatabaseConfigCalculator
    {
        private static int _cartorioPage;
        private static int _arquivosPage;
        private static int _auditoriaPage;
        private static int _indisponibilidadePage;
        private static int _notaFiscalPage;


        public static (long TotalRAMKB, long SafeLimitKB) GetMemoryInfo()
        {
            using var searcher = new ManagementObjectSearcher(
                "SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem");

            var os = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
            if (os == null)
            {
                LoggingFile.Error("Não foi possível obter informações de RAM do sistema.");
                return (0, 0);
            }

            long totalRAMKB = Convert.ToInt64(os["TotalVisibleMemorySize"]);
            long safeLimitKB = (long)(totalRAMKB * 0.25);
            return (totalRAMKB, safeLimitKB);
        }

        public static long GetSafeLimitKB() => GetMemoryInfo().SafeLimitKB;

        public static long? DefaultDbCacheCalc(long dbSizeBytes, int pageSize, long safeLimitKB)
        {
            if (safeLimitKB <= 0) return null;
            if (pageSize <= 0) throw new ArgumentException("PageSize deve ser maior que zero.");

            long safeLimitBytes = safeLimitKB * 1024;

            double multiplier = dbSizeBytes < safeLimitBytes * 0.5 ? 1.8
                              : dbSizeBytes < safeLimitBytes ? 1.4
                              : 1.2;

            long dbNecessityBytes = (long)(dbSizeBytes * multiplier);
            long bytesToAllocate = Math.Min(dbNecessityBytes, safeLimitBytes);

            long calculatedPages = bytesToAllocate / pageSize;

            // mínimo de 1GB em páginas independente do tamanho do banco
            long minPages = (1024L * 1024 * 1024) / pageSize;

            return Math.Max(calculatedPages, minPages);
        }

        public static Dictionary<string, long?> CalculateAll(string folderPath,
            PageSizeConfig config)
        {


            long safeLimitKB = GetSafeLimitKB();
            var results = new Dictionary<string, long?>();

            _cartorioPage = Convert.ToInt32(config.Cartorio);
            _arquivosPage = Convert.ToInt32(config.Arquivos);
            _auditoriaPage = Convert.ToInt32(config.Auditoria);
            _indisponibilidadePage = Convert.ToInt32(config.Indisponibilidade);
            _notaFiscalPage = Convert.ToInt32(config.NotaFiscal);

            var databases = new Dictionary<string, (int PageSize, bool IsOptional)>
            {
                { "CARTORIO.FDB",          (_cartorioPage,          false) },
                { "ARQUIVOS.FDB",          (_arquivosPage,          false) },
                { "AUDITORIA.FDB",         (_auditoriaPage,         false) },
                { "INDISPONIBILIDADE.FDB", (_indisponibilidadePage, false) },
                { "NOTAFISCALDB.FDB",      (_notaFiscalPage,        true)  }
            };

            foreach (var db in databases)
            {
                string fullPath = Path.Combine(folderPath, db.Key);

                if (!File.Exists(fullPath))
                {
                    if (db.Value.IsOptional)
                    {
                        LoggingFile.Info($"{db.Key} não encontrado — opcional, ignorando.");
                        continue;
                    }
                    LoggingFile.Warning($"{db.Key} não encontrado na pasta selecionada.");
                    results[db.Key] = null;
                    continue;
                }

                long fileSize = FileHandler.FileSizeCalculator(fullPath);
                results[db.Key] = DefaultDbCacheCalc(fileSize, db.Value.PageSize, safeLimitKB);
                LoggingFile.Info($"{db.Key}: {fileSize} bytes → {results[db.Key]} páginas de cache.");
            }

            return results;
        }

        public static string GenerateDbConf(Dictionary<string, long?> results, string folderPath)
        {
            var sb = new System.Text.StringBuilder();

            foreach (var result in results)
            {
                if (result.Value == null) continue;

                sb.AppendLine($"{Path.GetFileNameWithoutExtension(result.Key)} = {Path.Combine(folderPath, result.Key)}");
                sb.AppendLine("{");
                sb.AppendLine($"\tDefaultDBCachePages = {result.Value}");
                sb.AppendLine("}");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}

