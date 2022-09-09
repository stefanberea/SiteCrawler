// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;
using SiteCrawler;

Console.WriteLine("Hello, World!");

var baseUrl = "http://google.com/";
var htmlSource = HttpHelper.GetSource(baseUrl);

var document = new HtmlDocument();
document.LoadHtml(htmlSource);
var urls = document.DocumentNode.SelectNodes("//a");
foreach (var url in urls)
{
    //var parsedUrl = HttpHelper.ParseUrl();
    Console.WriteLine(url.Attributes["href"].Value);
}