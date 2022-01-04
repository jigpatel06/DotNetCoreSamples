using System;
using System.Threading.Tasks;
using DotNetCoreFeaturesBasicDemo.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DotNetCoreFeaturesBasicDemo.Services
{
    public class AnswerMachine
    {
        private readonly IUtilities _Utilities;
        private readonly IConfiguration _appConfig;
        private readonly IHostEnvironment _host;

        public AnswerMachine(IUtilities utilities, IConfiguration appConfig, IHostEnvironment host)
        {
            _Utilities = utilities;
            _appConfig = appConfig;
            _host = host;
        }

        public void DisplayAppConfigValues()
        {
            Console.WriteLine();
            Console.WriteLine($"Hosting environment: {_host.EnvironmentName}");

            Console.WriteLine();
            Console.WriteLine("Application Configuration Values: Individual");

            Console.WriteLine($"KeyOne = {_appConfig.GetValue<int>("KeyOne")}");
            Console.WriteLine($"KeyTwo = {_appConfig["KeyTwo"]}");
            Console.WriteLine($"KeyThree:Message = {_appConfig.GetValue<string>("KeyThree:Message")}");

            Console.WriteLine();

            var options = _appConfig.GetSection(nameof(TransientFaultHandlingOptions)).Get<TransientFaultHandlingOptions>();

            Console.WriteLine();
            Console.WriteLine("Application Configuration Values: related setting using strongly typed access");
            Console.WriteLine($"TransientFaultHandlingOptions.Enabled={options.Enabled}");
            Console.WriteLine($"TransientFaultHandlingOptions.AutoRetryDelay={options.AutoRetryDelay}");
            Console.WriteLine();
        }

        public async Task RunAnswerMachine(string[] args)
        {
            Console.WriteLine();

            Console.Write("Question: ");
            foreach (var s in args)
            {
                Console.Write(s);
                Console.Write(' ');
            }
            Console.WriteLine();

            string[] answers =
            {
                "It is certain.",       "Reply hazy, try again.",     "Don’t count on it.",
                "It is decidedly so.",  "Ask again later.",           "My reply is no.",
                "Without a doubt.",     "Better not tell you now.",   "My sources say no.",
                "Yes – definitely.",    "Cannot predict now.",        "Outlook not so good.",
                "You may rely on it.",  "Concentrate and ask again.", "Very doubtful.",
                "As I see it, yes.",
                "Most likely.",
                "Outlook good.",
                "Yes.",
                "Signs point to yes.",
            };

            await _Utilities.ShowConsoleAnimation();

            var index = new Random().Next(answers.Length - 1);
            Console.WriteLine();
            Console.WriteLine($"Answer: {answers[index]}");
            Console.WriteLine();
        }
    }
}