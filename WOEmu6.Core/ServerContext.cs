using WOEmu6.Core.Packets.Client;

namespace WOEmu6.Core
{
    public class ServerContext
    {
        public ServerContext()
        {
            IncomingPacketFactory = new IncomingPacketFactory();
        }
        
        public IncomingPacketFactory IncomingPacketFactory { get; }    
    }
}