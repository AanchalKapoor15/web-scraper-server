using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebScraper.Services;
using WebScraper.Services.Interfaces;

namespace WebScraper.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {
        IWebScraperService _webScraperService;

        public WebScraperController(IWebScraperService webScraperService)
        {
            _webScraperService = webScraperService;
        }

        // GET webScraper
        [HttpGet]
        public async Task<ActionResult<int[]>> Get(string browser, string searchTerm, string url)
        {
            var countArray = await _webScraperService.GetOccurrences(browser, searchTerm, url);
            return countArray;
        }
    }
}
