namespace WebCrawler.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using WebCrawler.Contracts;
    using WebCrawler.Models;
    using WebCrawler.Common;

    public class Crawler : ICrawler
    {
        private IRepository<string> urlRepository;
        private IHtmlParser htmlParser;
        private IFetcher htmlFetcher;
        private HashSet<string> visitedUrls;
        private HashSet<string> downloadedImgs;

        public Crawler(IRepository<string> urlRepository, IHtmlParser htmlParser, IFetcher htmlFetcher)
        {
            this.urlRepository = urlRepository;
            this.htmlParser = htmlParser;
            this.htmlFetcher = htmlFetcher;
            this.visitedUrls = new HashSet<string>();
            this.downloadedImgs = new HashSet<string>();
        }

        public void Crawl(CrawlData data)
        {
            this.Crawl(data.InitialUrl, 0, data.Levels);
        }

        private void Crawl(string url, int currentLevel, int maxLevel)
        {
            if (currentLevel >= maxLevel)
            {
                return;
            }

            this.visitedUrls.Add(url);

            string html = string.Empty;
            try
            {
                html = this.htmlFetcher.Fetch(url);
            } 
            catch (WebException ex)
            {
                return;
            }

            var imageUrls = this.htmlParser.ParseImages(html)
                .Where(u => ResourceUtility.IsValidImage(u))
                .Select(u => ResourceUtility.GetValidResourceString(url, u))
                .Where(u => !this.downloadedImgs.Contains(u));

            this.urlRepository.AddRange(imageUrls);
            foreach (var imageUrl in imageUrls)
            {
                this.downloadedImgs.Add(imageUrl);
            }

            var anchorUrls = this.htmlParser.ParseAnchors(html)
                .Select(u => ResourceUtility.GetValidResourceString(url, u))
                .Where(u => !this.visitedUrls.Contains(u));

            foreach (var anchorUrl in anchorUrls)
            {
                this.Crawl(anchorUrl, currentLevel + 1, maxLevel);
            }
        }
    }
}
