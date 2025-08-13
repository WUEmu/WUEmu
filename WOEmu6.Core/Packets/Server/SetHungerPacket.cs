
using WOEmu6.Core.Network;

namespace WOEmu6.Core.Packets.Server
{
    public class SetHungerPacket : IOutgoingPacket
    {
        public SetHungerPacket(ushort hunger, byte nutrition, byte? calories = null, byte? carbs = null, byte? fats = null, byte? protein = null)
        {
            Hunger = hunger;
            Nutrition = nutrition;
            Calories = calories;
            Carbs = carbs;
            Fats = fats;
            Protein = protein;
        }

        public byte Opcode => 61;
        
        public ushort Hunger { get; }
        
        public byte Nutrition { get; }
        
        public byte? Calories { get; }
        
        public byte? Carbs { get; }
        
        public byte? Fats { get; }
        
        public byte? Protein { get; }
        
        public void Write(ServerContext context, PacketWriter writer)
        {
            writer.WriteShort(Hunger);
            writer.WriteByte(Nutrition);
            if (Calories.HasValue)
            {
                writer.WriteByte(Calories.Value);
                writer.WriteByte(Carbs ?? 0);
                writer.WriteByte(Fats ?? 0);
                writer.WriteByte(Protein ?? 0);
            }
        }
    }
}