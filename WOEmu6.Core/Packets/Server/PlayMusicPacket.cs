using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class PlayMusicPacket : IOutgoingPacket
    {
        public PlayMusicPacket(string name, float x, float y, float z, float pitch, float volume, float priority)
        {
            Name = name;
            X = x;
            Y = y;
            Z = z;
            Pitch = pitch;
            Volume = volume;
            Priority = priority;
        }


        public byte Opcode => 115;

        public string Name { get; }

        public float X { get; }

        public float Y { get; }

        public float Z { get; }

        public float Pitch { get; }

        public float Volume { get; }

        public float Priority { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString(Name);
            writer.WriteFloat(X);
            writer.WriteFloat(Y);
            writer.WriteFloat(Z);
            writer.WriteFloat(Pitch);
            writer.WriteFloat(Volume);
            writer.WriteFloat(Priority);
        }
    }
}