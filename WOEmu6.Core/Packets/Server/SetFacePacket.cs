
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class SetFacePacket : IOutgoingPacket
    {
        public SetFacePacket(long oldFace, long mirrorItem)
        {
            OldFace = oldFace;
            MirrorItem = mirrorItem;
        }
        
        public byte Opcode => 0x02;
        
        public long OldFace { get; }
        
        public long MirrorItem { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteLong(OldFace);
            writer.WriteLong(MirrorItem);
        }
    }
}