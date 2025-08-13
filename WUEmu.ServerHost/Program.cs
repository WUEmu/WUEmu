using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace WUEmu.ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .MinimumLevel.Debug()
                .CreateLogger();
            
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddSerilog();
            builder.Services.AddHostedService<WUServer>();
            var host = builder.Build();
            host.Run();
        }
    }
}
