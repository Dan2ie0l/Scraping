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
            string node = "body > div.wrapper > div.container > div.claimed.noBio > div > section > div.model-details.js-headerContent > div.bottomDescription.display-grid.bio.auto-columns > div.biographyAbout.column.text.js-bioAbout > div > section > div:nth-child(2)";
            HtmlDocument doc = new HtmlDocument();
            string bio;

            List<string> texts = new List<string>();
            foreach (string item in request.URL)
            {
                doc = scrapingService.GetPage("https://www.pornhub.com" + item);
                bio= scrapingService.SelectSingleNode(doc, node);
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
