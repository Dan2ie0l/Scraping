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

            var url = "https://www.pornhub.com/pornstar/riley-reid";

            var data = scrapingService.HttpGet(url + "");
            foreach (var item in data)
            {
                Console.WriteLine(item.InnerText);
            }


            return new string[] { };
        }
    }
}
