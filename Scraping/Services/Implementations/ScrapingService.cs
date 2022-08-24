using HtmlAgilityPack;
using Scraping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Services.Implementations
{
    public class ScrapingService : IScrapingService
    {



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

        public HtmlNode SelectSingleNode(HtmlDocument doc, string node, string node2)
        {

            HtmlNode nodee = doc.DocumentNode.SelectSingleNode(node);
            if (nodee == null)
            {
                nodee = doc.DocumentNode.SelectSingleNode(node2);
            }


            return nodee;
        }
        public HtmlNode[] SelectNodes(HtmlDocument doc, string node)
        {

            HtmlNode[] nodes = doc.DocumentNode.SelectNodes(node).ToArray();


            return nodes;
        }

        public async Task<string[]> Download(List<string> urls, string dir)
        {
            WebClient cl = new WebClient();
            ServicePointManager.DefaultConnectionLimit = 200;

            string root = "C:\\" + dir;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            try
            {
                foreach (var url in urls)
                {
                    cl.DownloadFile(url, Path.Combine(root, Path.GetFileName(RandomNames() + ".jpeg")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
        public async Task<HtmlDocument> HttpGet(string url)
        {

            HttpClient HttpClient = new HttpClient();
            HtmlDocument doc;
            using (var req = new HttpRequestMessage(HttpMethod.Get, url))
            {
                req.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                req.Headers.Add("Accept-Language", "en-US,en;q=0.9,ru;q=0.8");
                req.Headers.Add("User-Agent", " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36");
                req.Headers.Add("Host", "www.pornhub.com");
                req.Headers.Add("Connection", " keep-alive");
                req.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                req.Headers.Add("Cookie", "bs=rcq39bagbm5fpb2b2t9i5yf2p92pln8c; ss=186252303173252801; fg_568e4786bc5d52ecadad43e36747ddff=14957.100000; fg_fcf2e67d6468e8e1072596aead761f2b=88971.100000; fg_ee26b76392ae0c54fbcf7c635e3da0fa=31568.100000; tj_UUID=10a278bf7b43436daf09d590555b32c5; tj_UUID_v2=10a278bf-7b43-436d-af09-d590555b32c5; _ga=GA1.2.1272407682.1659360647; d_uidb=b0d62df8-81ac-a05e-0ac0-a11915674f6d; ua=620eeaccf0f03dc51ea5a9f1f3fb4360; platform=pc; atatusScript=hide; _gid=GA1.2.515965787.1660139943; _gat=1; d_fs=1");

                var httpClientHandler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
                };
                HttpClient = new HttpClient(httpClientHandler);
                var response = await HttpClient.SendAsync(req);

                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    doc = new HtmlDocument();
                    doc.Load(stream);
                }
                else
                {
                    doc = null;

                    Console.WriteLine($"Request failed. Error status code: {(int)response.StatusCode}");
                }
                

            }

            return doc;
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
