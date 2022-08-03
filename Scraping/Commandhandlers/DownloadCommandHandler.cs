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
    public class DownloadCommandHandler : IRequestHandler<DownloadCommand, string[] >
    {
        private IScrapingService scrapingService { get; set; }
        priva

        public DownloadCommandHandler(IScrapingService scrapingService)
        {
            this.scrapingService = scrapingService;
        }
        public async Task<string[]> Handle(DownloadCommand request, CancellationToken cancellationToken)
        {
            HtmlDocument doc = new HtmlDocument();
            foreach (var item in request.URL)
            {
                 doc = scrapingService.GetPage("https://www.pornhub.com"+ item);
            }
            List<string> hrefs = new List<string>();

            hrefs.AddRange(scrapingService.GetLinks(doc));
            
            

            Console.WriteLine(hrefs.Count);
            string[] href = hrefs.ToArray();



            return new string[] {};
        }
    }
}
