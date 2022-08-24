using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using MediatR;
using Scraping.Comands;
using Scraping.Services.Interfaces;

namespace Scraping.Commandhandlers
{
    public class GetInfoCommandHandler : IRequestHandler<GetInfoCommand, string[]>
    {
        private IScrapingService scrapingService { get; set; }


        public GetInfoCommandHandler(IScrapingService scrapeingService)
        {
            this.scrapingService = scrapeingService;
        }


        public async Task<string[]> Handle(GetInfoCommand request, CancellationToken cancellationToken)
        {
            string node = "/html/body/div[4]/div[2]/div[4]/div/section/div[5]/div[1]/div[1]/div/section/div[2]";
            string node2 = "//div[@itemprop='description']";
            HtmlDocument doc = new HtmlDocument();
            string bio = "";
            HtmlNode[] nodes = null;
            List<string> texts = new List<string>();
            foreach (string item in request.URL)
            {

                doc = scrapingService.HttpGet("https://www.pornhub.com" + item).Result;
                if(scrapingService.SelectSingleNode(doc, node, node2) != null)
                {
                    bio = scrapingService.SelectSingleNode(doc, node, node2).InnerText;

                }
                else
                {
                    Console.WriteLine("bio is null");
                }
                texts.Add(bio);
                nodes = scrapingService.SelectNodes(doc, "//div[@class='infoPiece']");
                
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine();
                Console.WriteLine();
                 Dictionary<string, string> info = new Dictionary<string, string>();
                string [] names = item.Split("/pornstar/");
                foreach (string s in names)
                {

                }
                if (nodes != null)
                {
                    foreach (HtmlNode bb in nodes)
                    {
                        string key = bb.FirstChild.InnerText;
                        string value = bb.LastChild.InnerText;
                        Console.WriteLine(key + " " + value);
                    }
                }
                else
                {
                    Console.WriteLine("nodes is null");
                }
                /* foreach (KeyValuePair<string, string> itm in info)
                 {
                     Console.WriteLine(itm.Key + " " + itm.Value);
                 }*/
                Console.WriteLine("----------------------------------------------------");

            }



            return new string[] { };
        }
    }
}
