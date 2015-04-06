namespace WebCrawler.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using WebCrawler.Contracts;
    using WebCrawler.Common;

    public class HtmlParser : IHtmlParser
    {
        private const string ImageRegexPattern = "<img.*?src=\"(.*?)\".*?>";
        private const string AnchorRegexPattern = "<a.*?href=\"(.*?)\".*?>";
        private const int MatchGroupIndex = 1;

        public static readonly HtmlParser Instance = new HtmlParser();

        private Regex imageRegex;
        private Regex anchorRegex;

        private HtmlParser()
        {
        }

        private Regex ImageRegex
        {
            get
            {
                return this.imageRegex ?? (this.imageRegex = new Regex(ImageRegexPattern));
            }
        }

        private Regex AnchorRegex
        {
            get
            {
                return this.anchorRegex ?? (this.anchorRegex = new Regex(AnchorRegexPattern));
            }
        }

        public IEnumerable<string> ParseImages(string html)
        {
            var matches = this.ImageRegex.Matches(html);

            return matches.GroupsAsEnumerable(MatchGroupIndex);
        }

        public IEnumerable<string> ParseAnchors(string html)
        {
            var matches = this.AnchorRegex.Matches(html);

            return matches.GroupsAsEnumerable(MatchGroupIndex);
        }
    }
}
