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
        public static int Crawl(string baseUrl)
        {
            if (!HttpHelper.IsUrlValid(baseUrl))
                return 1;

            var htmlSource = HttpHelper.GetHtml(baseUrl);
            var baseHost = HttpHelper.GetHost(baseUrl);

            var document = new HtmlDocument();
            document.LoadHtml(htmlSource);
            var urls = document.DocumentNode.SelectNodes("//a");
            foreach (var url in urls)
            {
                var address = url.Attributes["href"].Value;
                var host = HttpHelper.GetHost(address);
                if (HttpHelper.HaveCommonHost(host, baseHost))
                {
                    Console.WriteLine(address);
                    SaveToFile(document, $"{host}.html");
                }
            }
            return 0;
        }


        static void SaveToFile(HtmlDocument documnet, string filePath)
        {
            documnet.Save(filePath);
        }

    }
}
