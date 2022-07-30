using Microsoft.Extensions.Logging;
using System;
using Scraping.Services;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

Console.WriteLine("HelloWord");

var serviceProvider = new ServiceCollection()
           .AddLogging()
           .AddMediatR(typeof(Program))
           .AddSingleton<IScrapingService, ScrapingService>()
           .AddSingleton<ApplicationStartupService>()
           .BuildServiceProvider();


serviceProvider.GetService<ApplicationStartupService>().Start().GetAwaiter().GetResult();

