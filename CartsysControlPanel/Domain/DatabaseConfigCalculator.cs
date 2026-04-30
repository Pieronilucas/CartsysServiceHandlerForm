using System.Management;

namespace CartsysControlPanel.Domain
{

    public static class DatabaseConfigCalculator
    {

        public static long? DefaultDbCacheCalc(long dbSizeBytes, int pageSize)
        {
            using var searcher = new ManagementObjectSearcher(
            "SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem");

            var os = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
            if (os == null) return null;


            
            // Tentar obter RAM total e definir o limite de 25% (em Bytes)
            long totalRAMKB = Convert.ToInt64(os["TotalVisibleMemorySize"]);
            long safeLimitKB = (long)(totalRAMKB * 1024 * 0.25);


            // Define multiplicador para dar "folga" do cache
            double multiplier = dbSizeBytes < safeLimitKB * 0.5 ? 1.8
                       : dbSizeBytes < safeLimitKB ? 1.4
                       : 1.2;



            // Calcular necessidade do banco (Tamanho + 20% de margem para índices)
            long DbNecessityBytes = (long)(dbSizeBytes * multiplier);

            // Escolhe o menor entre a necessidade e o limite de segurança
            long BytesToAlocate = Math.Min(DbNecessityBytes, safeLimitKB);

            //  Converter o resultado final para número de páginas
            return BytesToAlocate / pageSize;
        }
    }
}

