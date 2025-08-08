using System;
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
            Console.WriteLine("Player {0} joined!", UserName);
            
            // Write a login response containing initial stuff.
            client.Send(new LoginResponsePacket(true, "Welcome to WOEmu 6.0!", 0, 200*4, 200*4, 50, 1));

            // Sleep bonus information.
            client.Send(new SetSleepPacket(500));
            
            client.Send(new MapInfoPacket());
            
            // Send preliminary tile strip.
            client.Send(new TileStripPacket(200, 200, 50, 50));
            client.Send(new TileStripPacket(250, 200, 50, 50));
            client.Send(new TileStripPacket(300, 200, 50, 50));
            client.Send(new TileStripPacket(200, 250, 50, 50));
            client.Send(new TileStripPacket(200, 300, 50, 50));
            client.Send(new TileStripPacket(150, 200, 50, 50));
            client.Send(new TileStripPacket(100, 200, 50, 50));
            client.Send(new TileStripPacket(200, 150, 50, 50));
            client.Send(new TileStripPacket(200, 100, 50, 50));
            
            // Send the movement speed.
            client.Send(new SetSpeedPacket(2.0f));
            
            client.Send(new StartMovingPacket());
            
            client.Send(new TeleportPacket(200*4, 200*4, 50, 0, true, true, true, 0));
        }
    }
}