using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper.Services.Interfaces
{
    public interface IWebScraperService
    {
        Task<int[]> GetOccurrences(string searchEngine, string searchTerm, string url);
    }
}
