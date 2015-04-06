namespace WebCrawler.Common
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class Extensions
    {
        public static IEnumerable<string> GroupsAsEnumerable(this MatchCollection matches, int groupIndex)
        {
            string[] matchArray = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                matchArray[i] = matches[i].Groups[1].ToString();
            }

            return matchArray;
        }
    }
}
