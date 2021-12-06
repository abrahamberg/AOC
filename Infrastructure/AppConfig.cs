using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;

namespace AdventOfCode.Infrastructure
{
    public class AppConfig
    {
        public string BaseRoot { get; private set; }
        private readonly  IConfigurationRoot _config;
        public AppConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", false, true);

            _config = builder.Build();

            GetInputPath();
        }

        private void GetInputPath()
        {
            var input = _config["Input"];
            var pathIsAbsolute = input.Contains(@":\");
        
            BaseRoot= pathIsAbsolute ? input : GetRelativePath(input);
        }
        private string GetRelativePath(string input)
        {
            string result;
            if (input == ".")
                result = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? "..\\..\\..\\Input"
                    : "../../../Input";
            else
                result=  $@"{Environment.CurrentDirectory}\{input}";
            return result;
        }
    }
}