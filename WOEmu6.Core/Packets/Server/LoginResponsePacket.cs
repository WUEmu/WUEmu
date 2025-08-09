using System;
using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class LoginResponsePacket : IOutgoingPacket
    {
        public bool Success { get; }
        
        public string WelcomeMessage { get; }
        public float Rotation { get; }
        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        public byte Power { get; }

        public byte Layer { get; }
        public long Time { get; }

        public LoginResponsePacket(bool success, string welcomeMessage, float rotation, float x, float y, float z, byte power, byte layer = 0, long time = 0x0000000014DEC241L)
        {
            Success = success;
            WelcomeMessage = welcomeMessage;
            Rotation = rotation;
            X = x;
            Y = y;
            Z = z;
            Power = power;
            Layer = layer;
            Time = time;
        }
        
        public byte Opcode => 0xF1;
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            // writer.PushByte(0xF1);
            writer.WriteByte((byte)(Success ? 1 : 0));
            writer.WriteShortPrefixedString(WelcomeMessage);
            writer.WriteByte(Layer);
            writer.PushLong(Time);
            writer.PushLong(DateTime.Now.Ticks);
            writer.PushFloat(Rotation);
            writer.PushFloat(X);
            writer.PushFloat(Y);
            writer.PushFloat(Z);
            writer.WriteShortPrefixedString("model.creature.humanoid.human.player");
            writer.WriteByte(Power);
            
            writer.WriteByte((byte)0); // command type (for vehicles?)
            writer.WriteShort(10); // retry seconds?
            writer.PushLong(0);//face
            writer.WriteByte((byte)0); //kingdom template
            writer.PushInt(0); //teleport counter
            writer.WriteByte((byte)1); //blood?
            writer.PushLong(0); // bridge id
            writer.PushFloat(3); //ground offset
            writer.PushInt(32); // tile size X
            
            ;
            // var msg = Encoding.UTF8.GetBytes("Welcome to... WOEmu 5.0. It's been 84 years.");
            // writer.PushShort((short)msg.Length);
            // writer.PushBytes(msg);
            // writer.PushByte(0); // on surface
            // writer.PushLong(0x0000000014DEC241L); // time
            // writer.PushLong(0); // millis
            // writer.PushFloat(0); //rot
            // writer.PushFloat(0); // x
            // writer.PushFloat(0); // y
            // writer.PushFloat(50); // z
                        
            // var model = Encoding.UTF8.GetBytes("Human");
            // writer.PushShort((short)model.Length);
            // writer.PushBytes(model);
                        
            //power
            // writer.PushByte(1);

            
        }
    }
}