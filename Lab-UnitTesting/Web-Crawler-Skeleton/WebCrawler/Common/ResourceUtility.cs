namespace WebCrawler.Common
{
    public static class ResourceUtility
    {
        public static string GetValidResourceString(string originalUrl, string resource)
        {
            if (IsValidHttpResource(resource))
            {
                return resource;
            }

            int thirdSlashIndex = NthIndexOfCharacter('/', originalUrl, 3);
            string rootUrl = originalUrl.Substring(0, thirdSlashIndex + 1);

            return string.Format("{0}{1}", rootUrl, resource);
        }

        public static bool IsValidHttpResource(string url)
        {
            return url.StartsWith("http");
        }

        public static bool IsValidImage(string imageName)
        {
            string[] validImageFormats = 
            {
                ".png", ".jpg", ".jpeg", ".bmp", ".icon", ".svg"
            };

            for (int i = 0; i < validImageFormats.Length; i++)
            {
                if (imageName.StartsWith(validImageFormats[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static int NthIndexOfCharacter(char character, string text, int n)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == character)
                {
                    count++;
                    if (count == n)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
