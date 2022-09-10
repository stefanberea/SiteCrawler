// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;
using SiteCrawler;

Console.WriteLine("Hello, World!");

var baseUrl = "https://twitter.com/";
var httpHelper = new HttpHelper(baseUrl);
var htmlSource = httpHelper.GetSource(baseUrl);

var document = new HtmlDocument();
document.LoadHtml(htmlSource);
var urls = document.DocumentNode.SelectNodes("//a");
foreach (var url in urls)
{
    var address = url.Attributes["href"].Value;
    var host = httpHelper.GetHost(address);
    if (httpHelper.HasCommonHost(host))
    {
        Console.WriteLine(address);
        SaveToFile(document, $"{host}.html");
    }
}


static void SaveToFile(HtmlDocument documnet, string filePath)
{
    documnet.Save(filePath);
}