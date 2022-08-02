using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Services.Implementations
{
    public class ScrapingService : IScrapingService
    {


        public HtmlDocument GetPage(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            doc = web.Load(url);
            return doc;
        }

        public List<string> GetLinks(HtmlDocument doc)
        {
            int n = 0;
            List<string> links = new List<string>();

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a[@class='js-mxp']"))
            {
                n++;
                links.Add(node.GetAttributeValue("href", null));
                Console.WriteLine("node:" + node.GetAttributeValue("href", null));
                Console.WriteLine(n);

            }

            return links;
        }


    }
}
