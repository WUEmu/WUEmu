using WO.Core;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class AttachAnimationPacket : IOutgoingPacket
    {
        public AttachAnimationPacket(WurmId target, string animation, bool looping, bool freezeAfterFinish)
        {
            Target = target;
            Animation = animation;
            Looping = looping;
            FreezeAfterFinish = freezeAfterFinish;
        }


        public byte Opcode => 24;
        
        public WurmId Target { get; }
        
        public string Animation { get; }
        
        public bool Looping { get; }
        
        public bool FreezeAfterFinish { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushLong(Target);
            writer.WriteBytePrefixedString(Animation);
            writer.WriteBoolean(Looping);
            writer.WriteBoolean(FreezeAfterFinish);
        }
    }
}