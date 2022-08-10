﻿using System;
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
    public class DownloadCommandHandler : IRequestHandler<DownloadCommand, string[] >
    {
        private IScrapingService scrapingService { get; set; }
        

        public DownloadCommandHandler(IScrapingService scrapingService)
        {
            this.scrapingService = scrapingService;
        }

        public async Task<string[]> Handle(DownloadCommand request, CancellationToken cancellationToken)
        {

            var url = "https://www.pornhub.com/pornstar/riley-reid";

             var req = WebRequest.Create(url);
             req.Method = "GET";
             WebResponse response;
             try
             {
                  response = req.GetResponse();
                  using var webStream = response.GetResponseStream();
                 using var reader = new StreamReader(webStream);
                 var data = reader.ReadToEnd();

                 Console.WriteLine(data);
             }
             catch (WebException e) {
                 if (e.Message.Contains("302"))
                     {
                     Console.WriteLine(e.Message);
                     
                 }

             }
            

           // string data =  scrapingService.HttpGet(url);
           // Console.WriteLine(data);


            return new string[] {};
        }
    }
}
