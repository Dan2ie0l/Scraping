using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Comands
{
    public class GetPagesCommand : IRequest<string[]>
    {
        public  string URL { get; set; }
    }
}
