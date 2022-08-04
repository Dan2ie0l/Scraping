using HtmlAgilityPack;
using Scraping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Services.Implementations
{
    public class ScrapingService : IScrapingService
    {


        public HtmlDocument GetPage(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            doc = web.Load(url);
            return doc;
        }

        public List<string> GetLinks(HtmlDocument doc, string nodes)
        {
            int n = 0;
            List<string> links = new List<string>();

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes(nodes))
            {
                n++;
                links.Add(node.GetAttributeValue("href", null));
                Console.WriteLine("node:" + node.GetAttributeValue("href", null));
                Console.WriteLine(n);

            }

            return links;
        }

        public  string SelectSingleNode(HtmlDocument doc, string node)
        {
             string bio = "";

              HtmlNode nodee = doc.DocumentNode.SelectSingleNode(node);
              bio = (nodee.FirstChild.InnerText);
               Console.WriteLine(bio);


            return bio;
        }

        public async Task<string[]> Download(string url)
        {
            WebClient cl = new WebClient();
            string name = "Anne";

            string root = "C:\\" + name;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            try
            {
                cl.DownloadFile(url, Path.Combine(root, Path.GetFileName(RandomNames() + ".jpeg")));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public string RandomNames()
        {
            int length = 7;

            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

    }
}
