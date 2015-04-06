namespace WebCrawler.Contracts
{
    using WebCrawler.Models;

    public interface ICrawler
    {
        void Crawl(CrawlData data);
    }
}
