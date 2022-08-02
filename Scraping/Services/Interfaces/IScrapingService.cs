using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Services.Interfaces
{
    public interface IScrapingService
    {

        HtmlDocument GetPage(string url);
        List<string> GetLinks(HtmlDocument doc);


    }
}
