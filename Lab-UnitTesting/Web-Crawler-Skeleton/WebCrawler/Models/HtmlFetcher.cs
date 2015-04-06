namespace WebCrawler.Models
{
    using System.Net;

    using WebCrawler.Contracts;

    public class HtmlFetcher : IFetcher, IOutputProducer
    {
        private WebClient client;
        
        public HtmlFetcher(IOutput output)
        {
            this.Output = output;
            this.client = new WebClient();
            this.SetClientRequestHeaders();
        }

        public IOutput Output { get; private set; }

        public string Fetch(string url)
        {
            using (this.client)
            {
                var html = this.client.DownloadString(url);

                this.Output.AppendLine(url);
                this.Output.WriteAll();

                return html;
            }
        }

        private void SetClientRequestHeaders()
        {
            this.client.Headers.Add("user-agent", " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0)");
        }
    }
}
