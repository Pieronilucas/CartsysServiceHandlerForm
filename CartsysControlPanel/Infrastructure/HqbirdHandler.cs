using System.Management;

namespace CartsysControlPanel.Infrastructure
{
    
    public static class HqbirdHandler
    {
        private static double _multiplier;
        public static long? DefaultDbCacheCalc(long dbSizeBytes, int pageSize)
        {
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem"))
                {
                    foreach (var obj in searcher.Get())
                    {
                        // Tentar obter RAM total e definir o limite de 25% (em Bytes)
                        long totalRAMKB = Convert.ToInt64(obj["TotalVisibleMemorySize"]);
                        long SafeLimitKB = (long)(totalRAMKB * 1024 * 0.25);


                        // Define multiplicador para dar "folga" do cache
                        if (dbSizeBytes < (SafeLimitKB  * 0.5))
                        {
                            _multiplier = 1.8; 
                        }
                        else if(dbSizeBytes < SafeLimitKB)
                        {
                            _multiplier = 1.4;
                        }
                        else
                        {
                            _multiplier = 1.2;
                        }


                        // Calcular necessidade do banco (Tamanho + 20% de margem para índices)
                        long DbNecessityBytes = (long)(dbSizeBytes * _multiplier);

                        // Escolhe o menor entre a necessidade e o limite de segurança
                        long BytesToAlocate = Math.Min(DbNecessityBytes, SafeLimitKB);

                        //  Converter o resultado final para número de páginas
                        return BytesToAlocate / pageSize;


                    }
                }
            }
            catch (Exception ex)
            {
                throw;
                return null;
            }
            return null;
        }
    }
}
