using WO.Core;
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public enum MessageType : byte
    {
        Normal = 0,
        OnScreen = 1,
        OnScreenInfo = 2,
        OnScreenFail = 3,
        OnScreenHostile = 4
    }
    
    public class ServerMessagePacket : IOutgoingPacket
    {
        public string Channel { get; }
        public string Message { get; }
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }
        public MessageType Type { get; }

        public ServerMessagePacket(string channel, string message, byte r = 255, byte g = 255, byte b = 255,
            MessageType type = MessageType.Normal)
        {
            Channel = channel;
            Message = message;
            R = r;
            G = g;
            B = b;
            Type = type;
        }
        
        public byte Opcode => 0x63;
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteBytePrefixedString(Channel);
            writer.WriteByte(R);
            writer.WriteByte(G);
            writer.WriteByte(B);
            writer.WriteShortPrefixedString(Message);
            writer.WriteByte((byte)Type);
        }
    }
}