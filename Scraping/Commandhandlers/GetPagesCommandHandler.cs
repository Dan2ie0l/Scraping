using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraping.Comands;
using Scraping.Services.Interfaces;

namespace Scraping.Commandhandlers
{
    public class GetPagesCommandHandler : IRequestHandler<GetPagesCommand, string[]>
    {
        private IScrapingService scrapingService { get; set; }


        public GetPagesCommandHandler(IScrapingService scrapingService)
        {
            this.scrapingService = scrapingService;
        }
        public async Task<string[] > Handle(GetPagesCommand request, CancellationToken cancellationToken)
        {
            string node = "//a[@class='js-mxp']";
            List<string> hrefs = new List<string>();
            var doc = scrapingService.GetPage("https://www.pornhub.com/pornstars");

            hrefs.AddRange(scrapingService.GetLinks(doc,node));
            for (int i = 2; i < 10; i++)
            {
                var doc1 = scrapingService.GetPage("https://www.pornhub.com/pornstars?page=" + i);
                hrefs.AddRange(scrapingService.GetLinks(doc1, node));
                Console.WriteLine("We are on page "+i);
            }
            
            Console.WriteLine(hrefs.Count);
            string [] href = hrefs.ToArray();

            return href;
        }

       
    }
}
