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
            List<string> hrefs = new List<string>();
            var doc = scrapingService.GetPage("https://www.pornhub.com/pornstars");

            hrefs.AddRange(scrapingService.GetLinks(doc));
            for (int i = 2; i < 10; i++)
            {
                var doc1 = scrapingService.GetPage("https://www.pornhub.com/pornstars?page=" + i);
                scrapingService.GetLinks(doc);
                hrefs.AddRange(scrapingService.GetLinks(doc1));
                Console.WriteLine("We are on page "+i);
            }

            Console.WriteLine(hrefs.Count);
            string [] href = hrefs.ToArray();
            return href;
        }

       
    }
}
