using WO.Core;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.Packets.Server
{
    public class AddCreaturePacket : IOutgoingPacket
    {
        public AddCreaturePacket(Creature creature)
        {
            Creature = creature;
        }

        public byte Opcode => 108;
        
        public Creature Creature { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.PushLong(Creature.Id);
            writer.WriteBytePrefixedString(Creature.Model);
            writer.WriteBoolean(Creature.IsSolid);
            writer.PushFloat(Creature.Position.Y);
            writer.PushFloat(Creature.Position.X);
            writer.PushLong(0); // bridge
            writer.PushFloat(Creature.Rotation);
            writer.PushFloat(Creature.Position.Z);
            writer.WriteBytePrefixedString(Creature.Name);
            writer.WriteBytePrefixedString(Creature.HoverText);
            writer.WriteBoolean(Creature.IsFloating);
            writer.WriteByte(Creature.Layer);
            writer.WriteByte(Creature.CreatureType);
            writer.WriteByte(Creature.Material);
            writer.WriteByte(Creature.Kingdom);
            writer.PushLong(Creature.Face);
            writer.WriteBoolean(Creature.IsBloodKingdom);
            writer.WriteByte((byte)Creature.Condition);
            writer.WriteByte(Creature.Rarity);
        }
    }
}