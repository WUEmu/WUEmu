using WO.Core;
using WOEmu6.Core.Network;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class DetachEffectPacket : IOutgoingPacket
    {
        public DetachEffectPacket(WurmId target, EffectType effect)
        {
            Target = target;
            Effect = effect;
        }
        
        public byte Opcode => 18;
        
        public WurmId Target { get; }
        
        public EffectType Effect { get; }

        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteLong(Target);
            writer.WriteByte((byte)Effect);
        }
    }
}