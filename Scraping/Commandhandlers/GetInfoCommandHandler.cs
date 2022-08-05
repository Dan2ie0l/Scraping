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
    public class GetInfoCommandHandler : IRequestHandler<GetInfoCommand, string[] >
    {
        private IScrapingService scrapingService { get; set; }


        public GetInfoCommandHandler(IScrapingService scrapeingService)
        {
            this.scrapingService = scrapeingService;
        }


        public async Task<string[]> Handle(GetInfoCommand request, CancellationToken cancellationToken)
        {
            string node = "/html/body/div[4]/div[2]/div[4]/div/section/div[5]/div[1]/div[4]/div";
            string node2 = "/html/body/div[4]/div[2]/div[4]/div/section/div[5]/div[1]/div[3]/div";
            HtmlDocument doc = new HtmlDocument();
            string bio;

            List<string> texts = new List<string>();
            foreach (string item in request.URL)
            {
                doc = scrapingService.GetPage("https://www.pornhub.com" + item);
                bio= scrapingService.SelectSingleNode(doc, node, node2);
                texts.Add(bio);
            }
            foreach (string text in texts)
            {
                Console.WriteLine(text);
            }
             
            
            return new string[] {};
        }
    }
}
