namespace WebCrawler.Contracts
{
    public interface IOutput
    {
        void AppendLine(string outputLine);

        void WriteAll();
    }
}
