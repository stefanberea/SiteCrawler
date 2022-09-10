using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SiteCrawler;

namespace SiteCrawler
{
    public class SiteCrawler
    {
        public static int Crawl(string baseUrl, Action<HtmlDocument, string> process)
        {
            return Crawl(baseUrl, process, new HashSet<string>(StringComparer.OrdinalIgnoreCase));
        }

        public static int Crawl(string baseUrl, Action<HtmlDocument, string> process, HashSet<string> siteUrls)
        {
            if (!HttpHelper.IsUrlValid(baseUrl))
                return 1;

            var htmlSource = HttpHelper.GetHtml(baseUrl);
            var baseHost = HttpHelper.GetHost(baseUrl);

            var document = new HtmlDocument();
            document.LoadHtml(htmlSource);
            siteUrls.Add(baseUrl);
            process(document, baseUrl);

            var urls = document.DocumentNode.SelectNodes("//a");
            if(urls == null || urls.Count == 0)
            {
                return 0;
            }

            foreach (var url in urls)
            {
                var address = url.Attributes["href"].Value;
                var host = HttpHelper.GetHost(address);
                if (HttpHelper.HaveCommonHost(host, baseHost) && !siteUrls.Contains(address))
                {
                    Console.WriteLine(address);
                    Crawl(address, process, siteUrls);
                }
            }
            return 0;
        }

        public static void SaveToFile(HtmlDocument document, string filePath)
        {
            document.Save($"{filePath}.html");
        }

    }
}
