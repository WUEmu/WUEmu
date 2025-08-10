using System.Diagnostics;
using WO.Core;

namespace WOEmu6.Core.Packets.Server
{
    public class FishingStartPacket : IOutgoingPacket
    {
        public FishingStartPacket(float minRadius, float maxRadius, FishingRodType rod, byte rodMaterial, FishingReelType reel, byte reelMaterial, FishingFloatType f, FishingBaitType bait, bool auto)
        {
            MinRadius = minRadius;
            MaxRadius = maxRadius;
            RodMaterial = rodMaterial;
            Reel = reel;
            Rod = rod;
            ReelMaterial = reelMaterial;
            Float = f;
            Bait = bait;
            Auto = auto;
        }

        public byte Opcode => -64 & 0xFF;
        
        public float MinRadius { get; }
        
        public float MaxRadius { get; }
        
        public FishingRodType Rod { get; }
        
        public byte RodMaterial { get; }
        
        public FishingReelType Reel { get; }
        
        public byte ReelMaterial { get; }
        
        public FishingFloatType Float { get; }
        
        public FishingBaitType Bait { get; }
        
        public bool Auto { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteByte((byte)FishingSubCommand.StartFishing);
            writer.PushFloat(MinRadius);
            writer.PushFloat(MaxRadius);
            writer.WriteByte((byte)Rod);
            writer.WriteByte(RodMaterial);
            writer.WriteByte((byte)Reel);
            writer.WriteByte(ReelMaterial);
            writer.WriteByte((byte)Float);
            writer.WriteByte((byte)Bait);
            writer.WriteBoolean(Auto);
        }
    }
}