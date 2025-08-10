using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class SetMapAnnotationPermissions : IOutgoingPacket
    {
        public SetMapAnnotationPermissions(bool isMayor, bool isAllianceMayor)
        {
            IsMayor = isMayor;
            IsAllianceMayor = isAllianceMayor;
        }

        public byte Opcode => -43 & 0xFF;
        
        public bool IsMayor { get; }
        
        public bool IsAllianceMayor { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteByte((byte)MapAnnotationCommand.GetPermissions);
            writer.WriteBoolean(IsMayor);
            writer.WriteBoolean(IsAllianceMayor);
        }
    }
}