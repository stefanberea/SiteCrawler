internal class Program
{
    private static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            System.Console.WriteLine("Please enter a web URL to crawl.");
            return 1;
        }
        var result = SiteCrawler.SiteCrawler.Crawl(args[0]);

        return result;
    }
}