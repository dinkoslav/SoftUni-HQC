namespace WebCrawler.Models
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Threading;

    using WebCrawler.Contracts;

    public class ImageDownloader : IDownloader, IOutputProducer
    {
        private const char FormatDelimiter = '.';
        private const char DirectoryDelimiter = '/';

        private WebClient client;

        public ImageDownloader(IRepository<string> urlRepository, string downloadPath, IOutput output)
        {
            this.Output = output;
            this.UrlRepository = urlRepository;
            this.DownloadPath = downloadPath;
            this.client = new WebClient();
            this.SetClientRequestHeaders();
        }

        public IRepository<string> UrlRepository { get; private set; }

        public string DownloadPath { get; private set; }

        public IOutput Output { get; private set; }

        public void Run(ref bool runCondition)
        {
            while (runCondition || !this.UrlRepository.IsEmpty)
            {
                var resource = this.UrlRepository.Remove();

                if (resource != null)
                {
                    string fileName = this.GetFileName(resource);

                    try
                    {
                        this.Output.AppendLine(string.Format("Thread {0} downloading {1}",
                            Thread.CurrentThread.ManagedThreadId, resource));
                        this.Download(resource, fileName);
                        this.Output.AppendLine(string.Format("Thread {0} finished {1}",
                            Thread.CurrentThread.ManagedThreadId, resource));
                    }
                    catch (WebException ex)
                    {
                        this.Output.AppendLine(string.Format("Error downloading {2}. {0} {1}", ex.Message, ex.Response, resource));
                    }
                    finally
                    {
                        this.Output.WriteAll();
                    }
                }
            }
        }

        private void Download(string url, string fileName)
        {
            using (this.client)
            {
                var date = DateTime.Now.ToFileTime();

                client.DownloadFile(url, string.Format("{0}{1}-{2}",
                    this.DownloadPath, date, fileName));
            }
        }

        private void SetClientRequestHeaders()
        {
            this.client.Headers.Add("accept", "image/webp,*/*;q=0.8");
            this.client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.3; WOW64)");
        }

        private string GetFileName(string resource)
        {
            return resource.Substring(resource.LastIndexOf(DirectoryDelimiter) + 1);
        }
    }
}
