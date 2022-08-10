﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.Services.Interfaces
{
    public interface IScrapingService
    {

        HtmlDocument GetPage(string url);
        List<string> GetLinks(HtmlDocument doc, string  nodes);
        HtmlNode[] SelectNodes(HtmlDocument doc, string node);
        string SelectSingleNode(HtmlDocument doc, string node, string node2);
        string HttpGet(string url);

    }
}
