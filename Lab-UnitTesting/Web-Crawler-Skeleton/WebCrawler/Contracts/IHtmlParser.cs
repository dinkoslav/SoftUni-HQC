namespace WebCrawler.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHtmlParser
    {
        IEnumerable<string> ParseImages(string html);

        IEnumerable<string> ParseAnchors(string html);
    }
}
