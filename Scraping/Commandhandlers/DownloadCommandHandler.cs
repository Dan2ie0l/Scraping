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
            List<string> hrefs = new List<string>();
            List<string> imghrefs = new List<string>();
            List<string> srcs = new List<string>();
            foreach (var item in request.URL)
            {


                if (item.Contains("pornstar"))
                {

                    Thread.Sleep(5000);
                    var url = "https://www.pornhub.com" + item;
                    string h1name = "";
                    var namedoc = scrapingService.HttpGet(url).Result;
                    var name = namedoc.DocumentNode.SelectSingleNode(".//h1");
                    var n = name.InnerText.Split('\t');
                    foreach (var ittem in n)
                    {
                        if (ittem.Length > 3)
                        {
                            h1name = ittem.Trim();
                        }
                    }
                    HtmlDocument doc = new HtmlDocument();

                    doc = scrapingService.HttpGet(url + "/photos/public").Result;



                    if (doc == null)
                    {
                        continue;
                    }
                    var nodeList = doc.DocumentNode.SelectNodes("//div[@class='photoAlbumListBlock js_lazy_bkg']");
                    if(nodeList != null)
                    {
                        foreach (var node in nodeList)
                        {
                            var nod = node.SelectSingleNode("./a");
                            hrefs.Add(nod.GetAttributeValue("href", null));
                            Console.WriteLine(nod.GetAttributeValue("href", null));
                        }
                    }
                    else
                    {
                        continue;
                    }
                    

                    foreach (string it in hrefs)
                    {
                        var document = scrapingService.HttpGet("https://www.pornhub.com" + it).Result;
                        var nodes = document.DocumentNode.SelectNodes(".//a[contains(@href,'/photo/')]");
                        if (nodes.Count > 0)
                        {
                            foreach (var i in nodes)
                            {
                                imghrefs.Add(i.GetAttributeValue("href", null));
                            }
                        }
                        else
                        {
                            continue;
                        }
                        Console.WriteLine(" --------------------");

                    }
                    Console.WriteLine(h1name);
                    Console.WriteLine(imghrefs.Count);
                    foreach (var i in imghrefs)
                    {

                        var document = scrapingService.HttpGet("https://www.pornhub.com" + i).Result;
                        var node = scrapingService.SelectSingleNode(document, "//*[@id='photoImageSection']/div[1]/a[3]/img", "//*[@id='photoImageSection']/div[1]/a[3]/img");
                        if (node != null)
                        {
                            srcs.Add(node.GetAttributeValue("src", null));
                            Console.WriteLine(node.GetAttributeValue("src", null));
                        }
                        else
                        {
                            continue;
                        }
                    }
                    scrapingService.Download(srcs, h1name);
                    imghrefs.Clear();
                    srcs.Clear();
                    hrefs.Clear();
                }


            }



            return new string[] { };
        }
    }
}
