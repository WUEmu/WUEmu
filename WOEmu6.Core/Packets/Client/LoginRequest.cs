using System;
using WO.Core;
using WOEmu6.Core.BML;
using WOEmu6.Core.Objects;
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

        public void Handle(ServerContext context, ClientSession client)
        {
            Console.WriteLine("Player {0} joined!", UserName);

            client.Player = new Player(client, UserName);
            
            // Write a login response containing initial stuff.
            client.Send(new LoginResponsePacket(true, "Welcome to WOEmu 6.0!", 
                client.Player.Rotation, client.Player.X, client.Player.Y, client.Player.Z, 1));

            // Sleep bonus information.
            client.Send(new SetSleepPacket(500));
            client.Send(new MapInfoPacket());
            client.Send(new TileStripPacket( (short)(client.Player.TileX - (100/2)), (short)(client.Player.TileY - (100/2)), (short)100, (short)100));
            client.Send(new SetSpeedPacket(2.0f));
            client.Send(new StartMovingPacket());
            client.Send(new TeleportPacket(client.Player.X, client.Player.Y, client.Player.Z, 0, true, true, true, 0));
            client.Send(new AddSkillPacket(new Skill(
                1, null, "Programming", 9000, 9000
            )));
            
            var form = new BmlForm(1, "Message Of The Day", @"varray{center{header{text='WOEmu 6.0';}};label{text='Welcome to WOemu'};input{id='test';maxlines='5';text='This is a test';maxchars='1024';};button{text='Do Something';id='do_it'};}");
            client.Send(new BmlFormPacket(form));
        }
    }
}