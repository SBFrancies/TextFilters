using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using TextFilters.Filters;
using TextFilters.Interface;
using TextFilters.Service;

namespace TextFilters
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;
        private static IObservable<string> _consoleWatcher;
        private static IConfiguration _configuration;

        public static void Main(string[] args)
        {
            _configuration = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json", false, true).Build();

            RegisterServices();
            RegisterObserver();
            new AutoResetEvent(false).WaitOne();
        }

        private static void RegisterObserver()
        {
            _consoleWatcher = Observable
                .Defer(() =>
                    Observable
                        .Start(_serviceProvider.GetService<IReader>().ReadLine)).Repeat().Publish().RefCount();

            var textProcessor = _serviceProvider.GetRequiredService<ITextProcessor>();
            var writer = _serviceProvider.GetRequiredService<IWriter>();

            _consoleWatcher.Subscribe(async input =>
            {
                var processedText = await textProcessor.ProcessTextAsync(input);
                writer.WriteLine(processedText);
            } );
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            var consoleService = new ConsoleService();
            collection.AddSingleton<IReader>(consoleService);
            collection.AddSingleton<IWriter>(consoleService);
            collection.AddSingleton<IFileSystem, FileSystemService>();
            collection.AddSingleton<ITextProcessor, TextProcessorService>();
            collection.AddSingleton<ITextFilter>(new ContainsLetterFilter(_configuration["LetterFilter"].ToCharArray()));
            collection.AddSingleton<ITextFilter>(new VowelInMiddleFilter());
            collection.AddSingleton<ITextFilter>(new WordLengthFilter(int.Parse(_configuration["WordLengthFilter"])));

            _serviceProvider = collection.BuildServiceProvider();
        }
    }
}
