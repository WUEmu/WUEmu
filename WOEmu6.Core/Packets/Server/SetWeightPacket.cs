using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class SetWeightPacket : IOutgoingPacket
    {
        public SetWeightPacket(float weight)
        {
            Weight = weight;
        }

        public byte Opcode => 5;
        
        public float Weight { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushFloat(Weight);
        }
    }
}