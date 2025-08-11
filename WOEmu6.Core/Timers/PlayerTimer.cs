using System;
using WOEmu6.Core.Packets;

namespace WOEmu6.Core.Timers
{
    /// <summary>
    /// Timer for player scope.
    /// </summary>
    public abstract class PlayerTimer : TimerBase
    {
        public PlayerTimer(ClientSession client)
        {
            Client = client;
        }
        
        public ClientSession Client { get; }
    }
}