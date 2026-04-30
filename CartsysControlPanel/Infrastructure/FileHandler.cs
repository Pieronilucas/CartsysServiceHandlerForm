namespace CartsysControlPanel.Infrastructure
{
    public static class FileHandler
    {
        public static long FileSizeCalculator(string filePath)
        {
            
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("O caminho da pasta e o nome do arquivo não podem ser nulos ou vazios.");
            }
            

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                long fileSizeBytes = fileInfo.Length;
                return fileSizeBytes;

            }
            catch(FileNotFoundException ex)
            {
                throw new FileNotFoundException($"Não foi possível encontrar o arquivo: {ex.Message}", ex);
            }
            catch (IOException ex)
            {
                throw new IOException($"Ocorreu um erro ao calcular o tamanho do arquivo: {ex.Message}", ex);
            }
        }
    }
}
