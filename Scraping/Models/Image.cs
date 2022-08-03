using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Models
{
    public class Image
    {
        public int Id { get; set; }
        public ICollection<string> Urls { get; set; } = new List<string>();

    }
}