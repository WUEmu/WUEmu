using System;
using System.Net;
using System.Net.Sockets;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Scripting;

namespace WOEmu6.Core
{
    public class Server
    {
        public void Run()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .MinimumLevel.Debug()
                .CreateLogger();
            
            var serverContext = ServerContext.Instance.Value;
            var loader = new ScriptLoader(serverContext.Lua, "Scripts");
            loader.Initialize();
            
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 3724);
            var socket = new TcpListener(ipEndPoint);
            socket.Start();
            // Console.WriteLine("Waiting for connections...");
            Log.Information("Server started, waiting for players...");

            while (true)
            {
                var client = socket.AcceptTcpClient();
                var session = new ClientSession(client);
                session.Run();
            }
        }
    }
}
