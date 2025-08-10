using Serilog;
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
            Log.Information("Player {0} joined!", UserName);

            client.Player = new Player(client, UserName);
            
            // Write a login response containing initial stuff.
            client.Send(new LoginResponsePacket(true, "Welcome to WOEmu 6.0!", 
                client.Player.Rotation, client.Player.X, client.Player.Y, client.Player.Z, 1));

            // Sleep bonus information.
            client.Send(new SetSleepPacket(500));
            client.Send(new MapInfoPacket("Storm"));
            
            // Send 9 squares of 100x100 tiles around the player.
            
            // center square
            /*
             * XXX XXX XXX
             * XXX XXX XXX
             * XXX XXX XXX
             * 
             * XXX XXX XXX
             * XXX X_X XXX
             * XXX XXX XXX
             */
            
            // Center square
            client.Send(new TileStripPacket((short)(client.Player.TileX - (100/2)), (short)(client.Player.TileY - (100/2)), 100, 100));
            // Center left
            client.Send(new TileStripPacket((short)(client.Player.TileX - 150), (short)(client.Player.TileY - (100/2)), 100, 100));
            // Center right
            client.Send(new TileStripPacket((short)(client.Player.TileX + 50), (short)(client.Player.TileY - (100/2)), 100, 100));
            
            // Top left
            client.Send(new TileStripPacket((short)(client.Player.TileX - 150), (short)(client.Player.TileY - 150), 100, 100));
            // Top center
            client.Send(new TileStripPacket((short)(client.Player.TileX - 50), (short)(client.Player.TileY - 150), 100, 100));
            // Top right
            client.Send(new TileStripPacket((short)(client.Player.TileX + 50), (short)(client.Player.TileY - 150), 100, 100));
            
            // Bottom left
            client.Send(new TileStripPacket((short)(client.Player.TileX - 150), (short)(client.Player.TileY + 50), 100, 100));
            // Bottom center
            client.Send(new TileStripPacket((short)(client.Player.TileX - 50), (short)(client.Player.TileY + 50), 100, 100));
            // Bottom right
            client.Send(new TileStripPacket((short)(client.Player.TileX + 50), (short)(client.Player.TileY + 50), 100, 100));
            
            client.Send(new AddKingdomPacket(1, "DniFan's Royal Commonwealth"));
            client.Send(new AddChatUserPacket(-1, client.Player.Name));
            client.Send(new UpdateWeatherPacket(0.8f, 0, 1.0f, 0, 0));
            client.Send(new SetSpeedPacket(5.0f));
            client.Send(new StartMovingPacket());
            client.Send(new TeleportPacket(client.Player.X, client.Player.Y, client.Player.Z, 0, true, true, true, 0));
//            client.Send(new AddSkillPacket(new Skill(
//                context, null, "Programming", 9000, 9000
//            )));
            
            // var form = new BmlForm(1, "Message Of The Day", @"varray{center{header{text='WOEmu 6.0';}};label{text='Welcome to WOemu'};input{id='test';maxlines='5';text='This is a test';maxchars='1024';};button{text='Do Something';id='do_it'};}");
            // client.Send(new BmlFormPacket(form));
        }
    }
}