namespace CartsysControlPanel.Infrastructure.FileSystem
{
    public static class FileHandler
    {
        public static long FileSizeCalculator(string filePath)
        {

            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("O caminho da pasta e o nome do arquivo não podem ser nulos ou vazios.");
            }
            
            if (!File.Exists(filePath)) {
                throw new FileNotFoundException($"O arquivo '{filePath}' não foi encontrado.");
            }

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                long fileSizeBytes = fileInfo.Length;
                return fileSizeBytes;
            }
            catch (IOException ex)
            {
                throw new IOException($"{ex.Message}");
            }
        }


        public static void AppendTextToFile(string filePath, string textToAppend)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("O caminho do arquivo não pode ser nulo ou vazio.");
            }
            if (textToAppend == null)
            {
                throw new ArgumentNullException(nameof(textToAppend), "O texto a ser adicionado não pode ser nulo.");
            }
            try
            {
                File.AppendAllText(filePath, textToAppend);
            }
            catch (IOException ex)
            {
                throw new IOException($"Ocorreu um erro ao tentar escrever no arquivo");
            }
        }
    }
}
