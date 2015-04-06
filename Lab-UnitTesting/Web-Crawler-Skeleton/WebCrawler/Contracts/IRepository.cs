namespace WebCrawler.Contracts
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IEnumerable<T> Resources { get; }

        bool IsEmpty { get; }

        void Add(T resource);

        void AddRange(IEnumerable<T> resources);

        T Remove();
    }
}
