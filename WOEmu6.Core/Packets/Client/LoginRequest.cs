using WO.Core;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.Packets.Client
{
    public class LoginRequest : IIncomingPacket
    {
        public byte Opcode => 0xF1;
        
        public int Version { get; private set; }
        
        public string UserName { get; private set; }
        
        public string Password { get; private set; }
        
        public string ServerPassword { get; private set; }
        
        public string SteamId { get; private set; }
        
        public bool IsExtraTileData { get; private set; }
        
        public void Read(PacketReader reader)
        {
            Version = reader.PopInt();
            UserName = reader.ReadBytePrefixedString();
            Password = reader.ReadBytePrefixedString();
            ServerPassword = reader.ReadBytePrefixedString();
            SteamId = reader.ReadBytePrefixedString();
            IsExtraTileData = reader.ReadByte() == 1;
        }

        public void Handle(ClientSession client)
        {
            // Write a login response containing initial stuff.
            client.Send(new LoginResponsePacket(true, "Welcome to WOEmu 6.0!", 0, 0, 0, 0, 1));

            // Sleep bonus information.
            client.Send(new SetSleepPacket(500));
            
            client.Send(new MapInfoPacket());
            
            // Send preliminary tile strip.
            client.Send(new TileStripPacket(-10, -10, 302, 1));
            
            // Send the movement speed.
            client.Send(new SetSpeedPacket(1.0f));
            
            client.Send(new StartMovingPacket());
            
            client.Send(new TeleportPacket(0, 0, 0, 0, true, true, true, 0));
        }
    }
}