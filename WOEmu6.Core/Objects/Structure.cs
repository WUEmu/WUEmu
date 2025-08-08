using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Objects
{
    public class Structure : ObjectBase
    {
        public Structure(StructureType structureType, string name, Position2D<short> position, byte layer)
        {
            Id = new WurmId(ObjectType.Structure, 0, 1);
            StructureType = structureType;
            Name = name;
            Position = position;
            Layer = layer;
        }
        
        public StructureType StructureType { get; }
        
        public string Name { get; }
        
        public Position2D<short> Position { get; }
        
        public byte Layer { get; }
        
        protected override ObjectType Type => ObjectType.Structure;
    }
}