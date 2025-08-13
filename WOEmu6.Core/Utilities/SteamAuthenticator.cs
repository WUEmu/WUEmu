using System.Collections.Generic;
using Serilog;
using Steamworks;
using WOEmu6.Core.Packets.Client;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Utilities
{
    public class SteamAuthenticator
    {
        private readonly Dictionary<ulong, SteamLoginRequest> loginRequests;
        private object requestsLock = new object();
        
        public SteamAuthenticator()
        {
            loginRequests = new Dictionary<ulong, SteamLoginRequest>();
        }

        public void StartAuthentication(SteamLoginRequest request)
        {
            var steamIdAsUlong = ulong.Parse(request.SteamId);
            
            lock (requestsLock)
            {
                if (loginRequests.Remove(steamIdAsUlong))
                {
                    // Still an old one there, remove it.
                    Log.Warning("Stale Steam login request removed for steam ID {steamId}", request.SteamId);
                }
                
                loginRequests.Add(steamIdAsUlong, request);
                var result = SteamGameServer.BeginAuthSession(request.Tickets, (int)request.TokenLength, new CSteamID(ulong.Parse(request.SteamId)));
                if (result != EBeginAuthSessionResult.k_EBeginAuthSessionResultOK)
                {
                    Log.Error("Steam BeginAuthSession invalid result: {res}", result);
                }
            }
        }

        public void AuthenticationSuccessful(ulong steamId)
        {
            IOutgoingPacket response;
            SteamLoginRequest request;
            
            lock (requestsLock)
            {
                if (!loginRequests.Remove(steamId, out request))
                {
                    Log.Error("No pending login request for steam ID {steamId}", steamId);
                    response = new SteamLoginResponsePacket(false, "No pending login request for you");
                    return;
                }
            }

            response = new SteamLoginResponsePacket(true);
            request.Session.Authenticated = true;
            request.Session.Send(response);
        }
    }
}
