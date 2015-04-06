namespace WebCrawler.Models
{
    using System;
   
    using WebCrawler.Common;

    public class CrawlData
    {
        public CrawlData(string initialUrl, int levels = 1)
        {
            this.InitialUrl = initialUrl;
            this.Levels = levels;
        }

        public string InitialUrl { get; set; }

        public int Levels { get; set; }
    }
}
