using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetCoreFeaturesBasicDemo.Services;

namespace DotNetCoreFeaturesBasicDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var defaultBuilder = Host.CreateDefaultBuilder(args);
            defaultBuilder.ConfigureServices(RegisterDemoAppServices);

            using IHost host = defaultBuilder.Build();

            // Application code should start here.
            var answerMachine = host.Services.GetRequiredService<AnswerMachine>();

            answerMachine.DisplayAppConfigValues();
            await answerMachine.RunAnswerMachine(args);

            await host.RunAsync();
        }

        private static void RegisterDemoAppServices(IServiceCollection services)
        {
            services.AddTransient<IUtilities, Utilities>();
            services.AddTransient<AnswerMachine>();
        }
    }
}