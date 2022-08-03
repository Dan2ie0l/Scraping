using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Scraping.Comands;

namespace Scraping.Commandhandlers
{
    public class DownloadCommandHandler : IRequestHandler<DownloadCommand, string[] >
    {
        
        public async Task<string[]> Handle(DownloadCommand request, CancellationToken cancellationToken)
        {
            

            return new string[] {};
        }
    }
}
