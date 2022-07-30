using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraping.Comands;
using Scraping.Services;

namespace Scraping.Commandhandlers
{
    public class GetPagesCommandHandler : IRequestHandler<GetPagesCommand, string[]>
    {
        private IScrapingService scrapingService { get; set; }

        public GetPagesCommandHandler(IScrapingService scrapingService)
        {
            this.scrapingService = scrapingService;
        }
        public Task<string[]> Handle(GetPagesCommand request, CancellationToken cancellationToken)
        {

            var doc = scrapingService.GetPage("https://www.pornhub.com/pornstars");
            scrapingService.GetLinks(doc);

            return null;
        }
    }
}
