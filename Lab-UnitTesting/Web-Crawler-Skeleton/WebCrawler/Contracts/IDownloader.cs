namespace WebCrawler.Contracts
{
    public interface IDownloader
    {
        string DownloadPath { get; }

        IRepository<string> UrlRepository { get; }

        void Run(ref bool stopCondition);
    }
}
