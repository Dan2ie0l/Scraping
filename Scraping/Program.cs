using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Scraping.Services.Implementations;
using Scraping.Services.Interfaces;

var serviceProvider = new ServiceCollection()
           .AddLogging()
           .AddMediatR(typeof(Program))
           .AddSingleton<IScrapingService, ScrapingService>()
           .AddSingleton<ApplicationStartupService>()
           .BuildServiceProvider();


serviceProvider.GetService<ApplicationStartupService>().Start().GetAwaiter().GetResult();

