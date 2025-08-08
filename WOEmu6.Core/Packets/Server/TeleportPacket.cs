using System.Runtime.InteropServices.ComTypes;
using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class TeleportPacket : IOutgoingPacket
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        public float Rotation { get; }
        public bool Local { get; }
        public bool IsOnSurface { get; }
        public bool Disembark { get; }
        public int TeleportCounter { get; }
        public byte StartCommandingType { get; }

        public TeleportPacket(float x, float y, float z, float rotation, bool local, bool isOnSurface, bool disembark,
            int teleportCounter, byte startCommandingType = 0)
        {
            X = x;
            Y = y;
            Z = z;
            Rotation = rotation;
            Local = local;
            IsOnSurface = isOnSurface;
            Disembark = disembark;
            TeleportCounter = teleportCounter;
            StartCommandingType = startCommandingType;
        }
        
        public byte Opcode => 51;
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushFloat(X);
            writer.PushFloat(Y);
            writer.PushFloat(Z);
            writer.PushFloat(Rotation);
            writer.PushByte((byte)(Local ? 1 : 0));
            writer.PushByte((byte)(IsOnSurface ? 0 : -1));
            writer.PushByte((byte)(Disembark ? 1 : 0));
            writer.PushByte(StartCommandingType);
            writer.PushInt(TeleportCounter);
        }
    }
}