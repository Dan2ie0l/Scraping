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
            string node2 = "/html/body/div[4]/div[2]/div[4]/div/section/div[5]/div[1]/div[1]/div/div[2]";
            HtmlDocument doc = new HtmlDocument();
            string bio;
            HtmlNode[] nodes = null;
            List<string> texts = new List<string>();
            foreach (string item in request.URL)
            {

                doc = scrapingService.HttpGet("https://www.pornhub.com" + item).Result;
                bio = scrapingService.SelectSingleNode(doc, node, node2);
                texts.Add(bio);
                var doc1 = scrapingService.HttpGet("https://www.pornhub.com" + item).Result;
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine();
                Console.WriteLine(scrapingService.SelectSingleNode(doc, "/html/body/div[4]/div[2]/div[4]/div/section/div[2]/div[1]/div/div[1]/h1", "/html/body/div[4]/div[2]/div[4]/div/section/div[2]/div[1]/div/div[1]/h1").Trim());
                Console.WriteLine();
                Dictionary<string, string> info = new Dictionary<string, string>();

                foreach (HtmlNode bb in nodes)
                {
                    string key = bb.FirstChild.InnerText;
                    string value = bb.LastChild.InnerText;
                    Console.WriteLine(key + " " + value);
                 }

                /* foreach (KeyValuePair<string, string> itm in info)
                 {
                     Console.WriteLine(itm.Key + " " + itm.Value);
                 }*/
                Console.WriteLine("----------------------------------------------------");

                Thread.Sleep(3000);
            }



            return new string[] { };
        }
    }
}
