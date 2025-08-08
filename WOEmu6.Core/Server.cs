using System;
using System.Net;
using System.Net.Sockets;
using WOEmu6.Core.Packets;

namespace WOEmu6.Core
{
    public class Server
    {
        public Server()
        {
            ServerContext = new ServerContext();
        }
        
        public ServerContext ServerContext { get; }

        public void Run()
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 3724);
            var socket = new TcpListener(ipEndPoint);
            socket.Start();
            Console.WriteLine("Waiting for connections...");

            while (true)
            {
                var client = socket.AcceptTcpClient();
                var session = new ClientSession(ServerContext, client);
                session.Run();
            }
        }
    }
}
