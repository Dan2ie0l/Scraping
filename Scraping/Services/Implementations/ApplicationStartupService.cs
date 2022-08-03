using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scraping.Comands;
using Scraping.Services.Interfaces;

namespace Scraping.Services.Implementations
{

    public class ApplicationStartupService
    {
        private IScrapingService scrapeingService { get; set; }
        private IMediator mediator { get; set; }
        public ApplicationStartupService(IMediator mediator)
        {

            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task Start()
        {

            Console.WriteLine("Test");

            var result = await mediator.Send(new GetPagesCommand()
            {
                URL = ""
            });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
             /*var result2 = await mediator.Send(new DownloadCommand()
            {
                URL = result.ToList<string>()
            }) ; */


        }
    }
}

