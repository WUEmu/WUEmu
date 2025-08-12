using System;
using System.Collections.Generic;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;
using WOEmu6.Core.Zones;

namespace WOEmu6.Core.Objects
{
    public class Creature : ObjectBase
    {
        public Creature(WurmId id, Zone zone)
        {
            Id = id;
            CurrentZone = zone;
        }

        public Creature(Zone zone) : this(ServerContext.Instance.Value.WurmIdGenerator.NewWurmId(ObjectType.Creature), zone)
        {
        }
        
        public Zone CurrentZone { get; set; }
        
        public string Model { get; set; }
        
        public string Name { get; set; }
        
        public string HoverText { get; set; }
        
        public bool IsFloating { get; set; }
        
        public bool IsSolid { get; set; }
        
        public byte Layer { get; set; }
        
        public byte CreatureType { get; set; }
        
        public byte Material { get; set; }
        
        public Position3D<float> Position { get; set; }
        
        public float Rotation { get; set; }
        
        public byte Kingdom { get; set; }
        
        public long Face { get; set; }
        
        public bool IsBloodKingdom { get; set; }
        
        public CreatureCondition Condition { get; set; }
        
        public byte Rarity { get; set; }

        public override IList<ContextMenuEntry> GetContextMenu(ClientSession session)
        {
            return new List<ContextMenuEntry>
            {
                new ContextMenuEntry(5000, "Move to a random spot"),
                new ContextMenuEntry(5001, "- DELETE CREATURE"),
            };
        }

        public override void OnMenuItemClick(ClientSession session, short itemId)
        {
            var random = new Random();
            var randomX = random.Next(-5, 5);
            var randomY = random.Next(-5, 5);
            var randomRot = (byte)random.Next(255);
            
            switch (itemId)
            {
                case 5000:
                    Move(session.Player.X + randomX, session.Player.Y + randomY, randomRot);
                    break;
                
                case 5001:
                    CurrentZone.RemoveCreature(this);
                    break;
            }
        }

        public void Move(float x, float y, byte rotation)
        {
            Position = new Position3D<float>(x, y, 0);
            Rotation = rotation;
            CurrentZone.CreatureMoved(this);
        }

        protected override ObjectType Type => ObjectType.Creature;
    }
}