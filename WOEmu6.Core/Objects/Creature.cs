using System;
using System.Collections.Generic;
using WOEmu6.Core.Packets;
using WOEmu6.Core.Packets.Server;
using WOEmu6.Core.Utilities;

namespace WOEmu6.Core.Objects
{
    public class Creature : ObjectBase
    {
        public Creature(WurmId id)
        {
            Id = id;
            lock (ServerContext.Instance.Value.World.creaturesLock)
                ServerContext.Instance.Value.World.creatures.TryAdd(Id, this);
        }

        public Creature() : this(ServerContext.Instance.Value.WurmIdGenerator.NewWurmId(ObjectType.Creature))
        {
        }
        
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
                    session.Send(new MoveCreaturePacket(Id, new Position2D<float>(session.Player.Y + randomY, session.Player.X + randomX), randomRot));
                    break;
                
                case 5001:
                    session.Send(new RemoveCreaturePacket(Id));
                    break;
            }
        }

        protected override ObjectType Type => ObjectType.Creature;
    }
}