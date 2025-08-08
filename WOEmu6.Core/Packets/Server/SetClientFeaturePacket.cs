using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class SetClientFeaturePacket : IOutgoingPacket
    {
        public SetClientFeaturePacket(ClientFeature feature, bool enabled)
        {
            // TODO: qualtiy values
            Feature = feature;
            Enabled = enabled;
        }

        public byte Opcode => 0xE2;
        
        public ClientFeature Feature { get; }
        
        public bool Enabled { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushByte((byte)Feature);
            writer.PushByte((byte)(Enabled ? 1 : 0));
        }
    }
}