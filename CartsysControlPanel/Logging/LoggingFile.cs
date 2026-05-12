using CartsysControlPanel.Infrastructure.FileSystem;

namespace CartsysControlPanel.Logging
{
    public static class LoggingFile
    {
        private static readonly string _logDirectory = Path.Combine(Path.GetTempPath(), "CartsysControlPanelLogs", "Logs");
        private static string _logFileName => Path.Combine(_logDirectory, $"log_{DateTime.Now:yyyy-MM-dd}.txt");

        static LoggingFile()
        {

            Directory.CreateDirectory(_logDirectory);

        }

        public static void Info(string message)
        {
            WriteLog("INFO", message);
        }
        public static void Warning(string message)
        {
            WriteLog("WARNING", message);
        }
        public static void Error(string message, Exception? ex = null)
        {
            WriteLog("ERROR", ex == null ? message : $"{message} - Exception: {ex.GetType().Name} : {ex.Message}");
        }


        private static void WriteLog(string level, string message)
        {
            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            try
            {
                FileHandler.AppendTextToFile(_logFileName, entry);
            }
            catch (IOException)
            {
                try
                {
                    string fallbackLogFileName = Path.Combine(_logDirectory, $"log_fallback_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt");
                    FileHandler.AppendTextToFile(fallbackLogFileName, entry);

                }
                catch
                {
                    // estratégia de fallback implementada para a primeira falha, mas, caso haja a segunad, não iremos parar a aplicação por logs.
                }
            }
        }
    }
}
