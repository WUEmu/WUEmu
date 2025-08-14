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
        private ServerContext serverContext;
        private Callback<SteamServersConnected_t> onConnectedCallback;
        private Callback<ValidateAuthTicketResponse_t> onValidateCallback;
        private Callback<GSPolicyResponse_t> onPolicyResponse;

        public string Name => "Main Server Thread";

        public void Run(CancellationToken cancellationToken)
        {
            serverContext = ServerContext.Instance.Value;
            if (serverContext.Configuration.UseSteam)
            {
                if (!SteamAPI.Init())
                {
                    Log.Error("Could not initialize Steamworks.NET");
                    return;
                }

                onValidateCallback = Callback<ValidateAuthTicketResponse_t>.CreateGameServer(ValidateAuthTicket);
                onConnectedCallback = Callback<SteamServersConnected_t>.CreateGameServer(OnSteamServersConnected);
                onPolicyResponse = Callback<GSPolicyResponse_t>.CreateGameServer(OnPolicyResponse);
                if (!GameServer.Init(0, 3724, 27016, EServerMode.eServerModeAuthenticationAndSecure, "1.0.0.0"))
                {
                    Log.Error("GameServer.Init() failed");
                    return;
                }

                SteamGameServer.SetModDir("wurmunlimitedserver");
                SteamGameServer.SetDedicatedServer(true);
                SteamGameServer.SetProduct("wurmunlimitedserver");
                SteamGameServer.SetGameDescription("Wurm Unlimited Server");
                SteamGameServer.SetGameTags("version=1.9.1.5;");
                SteamGameServer.LogOnAnonymous();
                SteamGameServer.SetAdvertiseServerActive(true);
            }

            var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 3724);
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen();
            serverSocket.BeginAccept(OnAccept, serverSocket);

            Log.Information("Server started, waiting for players...");
            if (serverContext.Configuration.UseSteam)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    GameServer.RunCallbacks();
                    Thread.CurrentThread.Join(100);
                }
            }
            else
            {
                while (!cancellationToken.IsCancellationRequested)
                    Thread.CurrentThread.Join(2500);
            }

            Log.Information("Main Server Thread stopped");
        }

        private void OnAccept(IAsyncResult result)
        {
            var serverSocket = (Socket)result.AsyncState;
            var socket = serverSocket.EndAccept(result);

            var clientSession = new ClientSession(socket);
            if (!serverContext.Configuration.UseSteam)
                clientSession.Authenticated = true;
            clientSession.StartRead();
            serverSocket.BeginAccept(OnAccept, serverSocket);
            serverContext.Threads.Start(clientSession);
        }

        private void OnPolicyResponse(GSPolicyResponse_t response)
        {
            Log.Information("OnPolicyResponse {respobnse}", response.m_bSecure);
            Log.Information("srv {id}", SteamGameServer.GetSteamID().ToString());
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
            if (pResponse.m_eAuthSessionResponse != EAuthSessionResponse.k_EAuthSessionResponseOK)
            {
                Log.Error("Error in ValidateAuthTicket: {res}", pResponse.m_eAuthSessionResponse);
                return;
            }

            serverContext.SteamAuthenticator.AuthenticationSuccessful(pResponse.m_SteamID.m_SteamID);
        }
    }
}