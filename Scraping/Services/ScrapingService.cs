using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Services
{
    public class ScrapingService : IScrapingService
    {
     

        public HtmlDocument GetPage(string url)
        {
            WebClient cl = new WebClient();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            doc = web.Load(url);
            return doc;
        }

        public Task<string[]> GetLinks(HtmlDocument doc)
        {
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a[@class='js-mxp']"))
            {
                Console.WriteLine("node:" + node.GetAttributeValue("href", null));
            }
            return null;
        }
    }
}
