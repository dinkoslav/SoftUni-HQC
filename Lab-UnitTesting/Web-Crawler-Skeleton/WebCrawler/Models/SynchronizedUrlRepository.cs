namespace WebCrawler.Core
{
    using System.Collections.Generic;

    using WebCrawler.Contracts;

    public class SynchronizedUrlRepository : IRepository<string>
    {
        public Queue<string> urls;

        public SynchronizedUrlRepository()
        {
            this.urls = new Queue<string>();
        }

        public IEnumerable<string> Resources
        {
            get
            {
                return this.urls;
            }
        }

        public void Add(string url)
        {
            lock (this.urls)
            {
                this.urls.Enqueue(url);
            }
        }

        public void AddRange(IEnumerable<string> urls)
        {
            lock (this.urls)
            {
                foreach (var url in urls)
                {
                    this.urls.Enqueue(url);
                }
            }
        }

        public string Remove()
        {
            string resource;
            lock (this.urls)
            {
                resource = this.IsEmpty ? this.urls.Dequeue() : null;
            }

            return resource;
        }

        public bool IsEmpty
        {
            get
            {
                return this.urls.Count > 0;
            }
        }
    }
}
