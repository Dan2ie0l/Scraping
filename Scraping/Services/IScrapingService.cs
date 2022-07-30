﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Services
{
    public interface IScrapingService
    {

        HtmlDocument GetPage(string url);
        Task<string[]> GetLinks( HtmlDocument doc);





    }
}
