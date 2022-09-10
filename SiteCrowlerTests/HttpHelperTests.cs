using SiteCrawler;

namespace SiteCrowlerTests
{
    public class HttpHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("invalid input")]
        public void AlwaysReturnsString(string input)
        {
            var expected = string.Empty;

            var result = HttpHelper.GetHtml(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}