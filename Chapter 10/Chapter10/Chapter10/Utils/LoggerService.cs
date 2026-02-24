using System.Text;

namespace Chapter10.Utils
{
    public class LoggerService
    {
        private StringBuilder _logBuffer = new StringBuilder();

        public void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _logBuffer.AppendLine($"[{timestamp}] {message}");
        }

        public void SaveToFile(string path)
        {
            File.WriteAllText(path, _logBuffer.ToString());
        }

    }
}
