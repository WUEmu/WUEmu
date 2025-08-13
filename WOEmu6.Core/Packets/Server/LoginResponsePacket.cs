using System;
using WOEmu6.Core.Network;

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

        public LoginResponsePacket(bool success, string welcomeMessage, float rotation, float x, float y, float z,
            byte power, byte layer = 0, long time = 0x0000000014DEC241L)
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
            writer.WriteByte((byte)(Success ? 1 : 0));
            writer.WriteShortPrefixedString(WelcomeMessage);
            writer.WriteByte(Layer);
            writer.WriteLong(Time);
            writer.WriteLong(DateTime.Now.Ticks);
            writer.WriteFloat(Rotation);
            writer.WriteFloat(X);
            writer.WriteFloat(Y);
            writer.WriteFloat(Z);
            writer.WriteShortPrefixedString("model.creature.humanoid.human.player");
            writer.WriteByte(Power);

            writer.WriteByte((byte)0); // command type (for vehicles?)
            writer.WriteShort(10); // retry seconds?
            writer.WriteLong(0); //face
            writer.WriteByte((byte)0); //kingdom template
            writer.WriteInt(0); //teleport counter
            writer.WriteByte((byte)1); //blood?
            writer.WriteLong(0); // bridge id
            writer.WriteFloat(3); //ground offset
            writer.WriteInt(32); // tile size X
        }
    }
}