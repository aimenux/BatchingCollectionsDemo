using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Lib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace App
{
    public static class Program
    {
        public static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IBatchExtractor, BatchExtractor1>();
            services.AddSingleton<IBatchExtractor, BatchExtractor2>();
            services.AddSingleton<IBatchExtractor, BatchExtractor3>();
            services.AddSingleton<IBatchExtractor, BatchExtractor4>();
            services.AddSingleton<IBatchExtractor, BatchExtractor5>();
            services.Configure<Settings>(configuration.GetSection(nameof(Settings)));

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole(options =>
                {
                    options.DisableColors = false;
                    options.TimestampFormat = "[HH:mm:ss:fff] ";
                });
                loggingBuilder.AddNonGenericLogger();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
            });

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger>();
            var settings = serviceProvider.GetRequiredService<IOptions<Settings>>().Value;
            var extractors = serviceProvider.GetServices<IBatchExtractor>();

            var batchSize = settings.BatchSize;
            var itemsSize = settings.ItemsSize;
            
            foreach (var extractor in extractors)
            {
                var items = RandomGenerator.RandomStrings(itemsSize);

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var batchs = extractor.Batch(items, batchSize);
                stopWatch.Stop();

                logger.LogInformation("Found {batchs} batchs for {items} items", batchs.Count(), itemsSize);

                logger.LogInformation("Elapsed time for '{processor}' is '{duration}'", extractor.Name, stopWatch.Elapsed.ToString("g"));
            }

            Console.WriteLine("Press any key to exit !");
            Console.ReadKey();
        }

        private static void AddNonGenericLogger(this ILoggingBuilder loggingBuilder)
        {
            var services = loggingBuilder.Services;
            services.AddSingleton(serviceProvider =>
            {
                const string categoryName = nameof(Program);
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                return loggerFactory.CreateLogger(categoryName);
            });
        }
    }
}
