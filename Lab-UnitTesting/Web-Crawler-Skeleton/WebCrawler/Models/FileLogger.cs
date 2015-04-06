namespace WebCrawler.Models
{
    using System.IO;
    using System.Text;

    using WebCrawler.Contracts;

    public class FileLogger : IOutput
    {
        private StringBuilder outputBuffer;
        private string logPath;

        public FileLogger(string logPath)
        {
            this.logPath = logPath;
            this.outputBuffer = new StringBuilder();
        }

        public void AppendLine(string outputLine)
        {
            this.outputBuffer.AppendLine(outputLine + "\n");
        }

        public void WriteAll()
        {
            var writer = new StreamWriter(this.logPath);
            using (writer)
            {
                writer.Write(this.outputBuffer);
                this.outputBuffer.Clear();
            }
        }
    }
}
