using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using WOEmu6.Core;

namespace WUEmu.ServerHost
{
    public class WUServer : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var server = new Server();
            ServerContext.Instance.Value.Threads.Start(server);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Bye Felicia");
            return Task.CompletedTask;
        }
    }
}
