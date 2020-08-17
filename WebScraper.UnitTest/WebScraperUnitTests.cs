using System;
using Xunit;
using WebScraper.Services;
using WebScraper.Data;
using Moq;
using System.Net.Http;

namespace WebScraper.UnitTests
{
    public class WebScraperUnitTests
    {
        public const string searchTerm = "online title search";
        public const string urlToSearch = "www.infotrack.com.au";
        public const string pageNumber = "01";
        public const string htmlSnippet = "<cite>www.infotrack.com.au</cite>";

        //arrange common configuration
        static HttpClient httpClient = new HttpClient();
        WebScraperService webScraperService = new WebScraperService(httpClient);

        [Fact]
        public async void Test_GetOccurrences()
        {
            //act
            var actualCount = await webScraperService.GetOccurrences(Constants.googleBrowser, searchTerm, urlToSearch);

            //assert
            var expectedCount = new int[10] { 2, 2, 0, 0, 0, 0, 0, 0, 0, 0 };
            Assert.Equal(expectedCount, actualCount);
        }

        [Fact]
        public async void Test_GetContent()
        {
            //act
            var actualResponse = await webScraperService.GetContent(String.Format(Constants.basePath, Constants.googleBrowser, pageNumber));

            //assert
            Assert.NotNull(actualResponse);
        }

        [Fact]
        public void Test_GetMatches()
        {
            //act
            var actualMatches = webScraperService.GetMatches(htmlSnippet, urlToSearch, Constants.googleBrowser);

            //assert
            var expectedMatches = 1;
            Assert.Equal(actualMatches, expectedMatches);
        }
    }
}
