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

            HttpClient HttpClient = new HttpClient();
               
            string data = "...";
            using (var req = new HttpRequestMessage(HttpMethod.Get, url))
            {
                req.Headers.Add("Accept-Encoding","gzip, deflate, br");
                req.Headers.Add("Accept-Language", "en-US,en;q=0.9,ru;q=0.8");
                req.Headers.Add("User-Agent", " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36");
                req.Headers.Add("Host","www.pornhub.com");
                req.Headers.Add("Connection", " keep-alive");
                req.Headers.Add("Accept","text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
                req.Headers.Add("Cookie","bs=rcq39bagbm5fpb2b2t9i5yf2p92pln8c; ss=186252303173252801; fg_568e4786bc5d52ecadad43e36747ddff=14957.100000; fg_fcf2e67d6468e8e1072596aead761f2b=88971.100000; fg_ee26b76392ae0c54fbcf7c635e3da0fa=31568.100000; tj_UUID=10a278bf7b43436daf09d590555b32c5; tj_UUID_v2=10a278bf-7b43-436d-af09-d590555b32c5; _ga=GA1.2.1272407682.1659360647; d_uidb=b0d62df8-81ac-a05e-0ac0-a11915674f6d; ua=620eeaccf0f03dc51ea5a9f1f3fb4360; platform=pc; atatusScript=hide; _gid=GA1.2.515965787.1660139943; _gat=1; d_fs=1");
                /* req.Headers.Add("x-trace", "2BC83079D58851FCFA3D1F10E63FE47976E368504F7A1DA85CFCFCF56800");
                 req.Headers.Add("x-frame-options", "SAMEORIGIN");
                 req.Headers.Add("strict-transport-security", "max-age=63072000; includeSubDomains; preload");
                 req.Headers.Add("transfer-encoding", "chunked");*/
                var httpClientHandler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
                };
                HttpClient = new HttpClient(httpClientHandler);
                var response = await HttpClient.SendAsync(req);

                response.EnsureSuccessStatusCode();

                 data =  await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine(data);

            // string data =  scrapingService.HttpGet(url);
            // Console.WriteLine(data);


            return new string[] { };
        }
    }
}
