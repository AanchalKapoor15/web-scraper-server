using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebScraper.Services.Interfaces;
using WebScraper.Data;


namespace WebScraper.Services
{
    public class WebScraperService : IWebScraperService
    {
        private readonly HttpClient _httpClient;

        public WebScraperService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int[]> GetOccurrences(string searchEngine, string searchTerm, string url)
        {
            int[] countArray = new int[10];

            {
                for (int i = 1; i <= 10; i++)
                {
                    var contents = await GetContent(String.Format(Constants.basePath, searchEngine, i.ToString("D2")));

                    countArray[i - 1] = GetMatches(contents, url, searchEngine);
                }
            }
            return countArray;
        }

        public async Task<string> GetContent(string path)
        {
            var response = await _httpClient.GetAsync(path);
            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }

        public int GetMatches(string contents, string url, string browser)
        {
            return Regex.Matches(contents, ">" + url).Count;
        }
    }
}
