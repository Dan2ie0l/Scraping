using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Scraping.Services.Implementations;
using Scraping.Services.Interfaces;

var serviceProvider = new ServiceCollection()
           .AddLogging()
           .AddMediatR(AppDomain.CurrentDomain.GetAssemblies())
           .AddSingleton<IScrapingService, ScrapingService>()
           .AddSingleton<ApplicationStartupService>()
           .BuildServiceProvider();


serviceProvider.GetService<ApplicationStartupService>().Start().GetAwaiter().GetResult();

