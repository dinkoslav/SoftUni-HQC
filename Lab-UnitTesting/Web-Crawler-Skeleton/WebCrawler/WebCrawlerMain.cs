namespace WebCrawler
{
    using System;

    using WebCrawler.Core;
    using WebCrawler.Models;

    public class WebCrawlerMain
    {
        private const string InitialUrl = "https://softuni.bg/";
        private const int Levels = 2;

        public static void Main()
        {
            Console.WriteLine("WebCrawler v1.0.\nEnter a site url (i.e https://softuni.bg/) and the levels you want to crawl.");
            Console.WriteLine("Images will be downloaded to the Images directory.");

            var app = new CrawlerApplication();
            app.CrawlData = new CrawlData(InitialUrl, Levels);
            app.Start();

            Console.WriteLine("Finished!");
        }
    }
}
