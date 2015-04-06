namespace WebCrawler.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using WebCrawler.Contracts;
    using WebCrawler.Models;

    public class CrawlerApplication
    {
        private const int DownloadersCount = 4;
        private const string ImagesDownloadPath = "../../Images/";
        private const string VisitedUrlsLogPath = "../../Logs/visited-urls-log.txt";

        private ICrawler crawler;
        public IList<IDownloader> downloaders;
        private IRepository<string> urlRepository;
        private IOutput consoleLogger;
        internal IOutput visitedUrlsFileLogger;
        internal bool isRunning;

        public CrawlerApplication()
        {
            this.urlRepository = new SynchronizedUrlRepository();
            this.consoleLogger = new SynchronizedConsoleLogger();
            this.visitedUrlsFileLogger = new FileLogger(VisitedUrlsLogPath);
            this.crawler = new Crawler(this.urlRepository, HtmlParser.Instance, new HtmlFetcher(this.visitedUrlsFileLogger));

            this.downloaders = new List<IDownloader>();
            this.InitializeImageDownloaders();
        }

        public void InitializeImageDownloaders()
        {
            for (int i = 0; i < DownloadersCount; i++)
            {
                this.downloaders.Add(new ImageDownloader(this.urlRepository, ImagesDownloadPath, this.consoleLogger));
            }
        }

        public CrawlData CrawlData { get; set; }

        public void Start()
        {
            this.isRunning = true;
            foreach (var downloader in this.downloaders)
            {
                new Thread(() => 
                {
                    downloader.Run(ref isRunning);
                })
                .Start();
            }

            this.crawler.Crawl(this.CrawlData);

            this.isRunning = false;
        }
    }
}
