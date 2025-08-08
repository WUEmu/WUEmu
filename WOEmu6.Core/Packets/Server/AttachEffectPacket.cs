using WO.Core;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class AttachEffectPacket : IOutgoingPacket
    {
        public AttachEffectPacket(WurmId target, EffectType effect, byte data0 = 0, byte data1 = 0, byte data2 = 0, byte data3 = 0)
        {
            Target = target;
            Effect = effect;
            Data0 = data0;
            Data1 = data1;
            Data2 = data2;
            Data3 = data3;
        }
        
        public byte Opcode => 109;

        public WurmId Target { get; }
        
        public EffectType Effect { get; }
        public byte Data0 { get; }
        
        public byte Data1 { get; }
        
        public byte Data2 { get; }
        
        public byte Data3 { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushLong(Target);
            writer.PushByte((byte)Effect);
            writer.PushByte(Data0);
            writer.PushByte(Data1);
            writer.PushByte(Data2);
            writer.PushByte(Data3);
        }
    }
}