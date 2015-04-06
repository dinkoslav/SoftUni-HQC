namespace WebCrawler.Models
{
    using System;
    using System.Text;

    using WebCrawler.Contracts;

    public class SynchronizedConsoleLogger : IOutput
    {
        private readonly StringBuilder outputBuffer;

        public SynchronizedConsoleLogger()
        {
            this.outputBuffer = new StringBuilder();
        }

        public void AppendLine(string outputLine)
        {
            lock (this.outputBuffer)
            {
                this.outputBuffer.AppendLine(outputLine);
            }
        }

        public void WriteAll()
        {
            lock (this.outputBuffer)
            {
                Console.Write(this.outputBuffer);
            }
        }
    }
}
