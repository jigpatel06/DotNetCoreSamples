using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DotNetCoreFeaturesBasicDemo.Services
{
    public class Utilities : IUtilities
    {
        private readonly ILogger<Utilities> _logger;

        public Utilities(ILogger<Utilities> logger)
        {
            _logger = logger;
        }
        public async Task ShowConsoleAnimation()
        {
            Console.WriteLine();

            _logger.LogInformation("started thinking...");

            for (int i = 0; i < 20; i++)
            {
                foreach (string s in new[] { "| -", "/ \\", "- |", "\\ /", })
                {
                    Console.Write(s);
                    await Task.Delay(50);
                    Console.Write("\b\b\b");
                }
            }
            Console.WriteLine();
        }
    }
}