using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using MediatR;
using Scraping.Comands;
using Scraping.Services.Interfaces;

namespace Scraping.Commandhandlers
{
    public class DownloadCommandHandler : IRequestHandler<DownloadCommand, string[]>
    {
        private IScrapingService scrapingService { get; set; }


        public DownloadCommandHandler(IScrapingService scrapingService)
        {
            this.scrapingService = scrapingService;
        }

        public async Task<string[]> Handle(DownloadCommand request, CancellationToken cancellationToken)
        {
            List<string> hrefs = new List<string>();
            List<string> imghrefs = new List<string>();
            List<string> srcs = new List<string>();
            foreach (var pornstar in request.URL)
            {
                var url = "https://www.pornhub.com" + pornstar;

                var namedoc = scrapingService.HttpGet(url).Result;
                string name = namedoc.DocumentNode.SelectSingleNode("//h1[@itemprop='name']").InnerText;
                var doc = scrapingService.HttpGet(url + "/photos/public").Result;

                var nodeList = doc.DocumentNode.SelectNodes(".//a[contains(@href,'/album/')]");

                foreach (var node in nodeList)
                {
                    hrefs.Add(node.GetAttributeValue("href", null));
                    Console.WriteLine(node.GetAttributeValue("href", null));
                }

                foreach (string it in hrefs)
                {
                    var document = scrapingService.HttpGet("https://www.pornhub.com" + it).Result;
                    var nodes = document.DocumentNode.SelectNodes(".//a[contains(@href,'/photo/')]");
                    if (nodes.Count > 0)
                    {
                        foreach (var i in nodes)
                        {
                            imghrefs.Add(i.GetAttributeValue("href", null));
                        }
                    }
                    else
                    {
                        continue;
                    }
                    Console.WriteLine(" --------------------");

                }

                foreach (var i in imghrefs)
                {
                    var document = scrapingService.HttpGet("https://www.pornhub.com" + i).Result;
                    var node = scrapingService.SelectSingleNode(document, "//*[@id='photoImageSection']/div[1]/a[3]/img", "//*[@id='photoImageSection']/div[1]/a[3]/img");
                    srcs.Add(node.GetAttributeValue("src", null));
                }


                scrapingService.Download(srcs, name);

            }

            return new string[] { };
        }
    }
}
