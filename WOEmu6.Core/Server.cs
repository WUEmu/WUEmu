using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Serilog;
using Steamworks;
using WOEmu6.Core.Threading;

namespace WOEmu6.Core
{
    public class Server : IThread
    {
        private const bool UseSteam = false;
        
        private ServerContext serverContext;
        private Callback<SteamServersConnected_t> onConnectedCallback;
        private Callback<ValidateAuthTicketResponse_t> onValidateCallback;

        public string Name => "Main Server Thread";

        public void Run(CancellationToken cancellationToken)
        {
            if (UseSteam)
            {
                if (!SteamAPI.Init())
                {
                    Log.Error("Could not initialize Steamworks.NET");
                    return;
                }

                onValidateCallback = Callback<ValidateAuthTicketResponse_t>.CreateGameServer(ValidateAuthTicket);
                onConnectedCallback = Callback<SteamServersConnected_t>.CreateGameServer(OnSteamServersConnected);
                if (!GameServer.Init(0, 3724, 27016, EServerMode.eServerModeNoAuthentication, "1.0.0.0"))
                {
                    Log.Error("GameServer.Init() failed");
                    return;
                }

                SteamGameServer.SetModDir("wurmunlimitedserver");
                SteamGameServer.SetDedicatedServer(true);
                SteamGameServer.SetProduct("wurmunlimitedserver");
                SteamGameServer.SetGameDescription("Wurm Unlimited Server");
                SteamGameServer.LogOnAnonymous();
            }

            serverContext = ServerContext.Instance.Value;
            var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 3724);
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen();
            serverSocket.BeginAccept(OnAccept, serverSocket);

            Log.Information("Server started, waiting for players...");
            Thread.CurrentThread.Join();
        }

        private void OnAccept(IAsyncResult result)
        {
            var serverSocket = (Socket)result.AsyncState;
            var socket = serverSocket.EndAccept(result);

            var clientSession = new ClientSession(socket);
            clientSession.StartRead();
            serverSocket.BeginAccept(OnAccept, serverSocket);
            serverContext.Threads.Start(clientSession);
        }

        private void OnSteamServersConnected(SteamServersConnected_t response)
        {
            Log.Information("Connected to Steam servers!");
            SteamGameServer.SetMaxPlayerCount(32);
            SteamGameServer.SetPasswordProtected(false);
            SteamGameServer.SetServerName("WUEmu :: DniFan's Test Realm");
            SteamGameServer.SetBotPlayerCount(0); // optional, defaults to zero
            SteamGameServer.SetMapName("zone_test");
        }

        private void ValidateAuthTicket(ValidateAuthTicketResponse_t pResponse)
        {
            
        }
    }
}
