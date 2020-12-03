using System;
using Microsoft.Extensions.Configuration;

namespace AdventOfCode.Infrastructure
{
    public class AppConfig
    {
        public string BaseRoot { get;  }
        private readonly  IConfigurationRoot config;
        public AppConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", false, true);

            config = builder.Build();

            BaseRoot = GetInputPath();
        }

        private string GetInputPath()
        {
            var input = config["Input"];
            var pathIsAbsolute = input.Contains(@":\");
            
            return pathIsAbsolute ? input : $@"{Environment.CurrentDirectory}\{input}";
        }
    }
}