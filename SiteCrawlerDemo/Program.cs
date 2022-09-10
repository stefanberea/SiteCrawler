using System.Security.Cryptography;
using System.Text;

internal class Program
{
    private static int Main(string[] args)
    {
        var outputFiles = new Dictionary<string, string>();
        if (args.Length == 0)
        {
            System.Console.WriteLine("Please enter a web URL to crawl.");
            return 1;
        }
        var result = SiteCrawler.SiteCrawler.Crawl(args[0], (document, address) =>
        {
            var filePath = address.GetHashCode().ToString();
            outputFiles.Add(filePath, address);
            SiteCrawler.SiteCrawler.SaveToFile(document, filePath);
        });

        if (result == 0)
        {
            File.WriteAllLines(
                "FileIndex.csv",
                outputFiles.Select(f => string.Format($"{f.Key};{f.Value}")));
        }

        return result;
    }
}