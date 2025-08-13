using System;
using System.Collections.Generic;
using System.Linq;

namespace WOEmu6.Core.Objects
{
    public class ObjectPool
    {
        private readonly Dictionary<WurmId, Creature> creatures;
        private readonly object creaturesLock = new object();

        private List<Structure> structures;
        private object structuresLock = new object();

        private readonly Dictionary<WurmId, Item> items;
        private object itemsLock = new object();
        
        public ObjectPool()
        {
            creatures = new Dictionary<WurmId, Creature>();
            structures = new List<Structure>();
            items = new Dictionary<WurmId, Item>();
        }

        public void AddCreature(Creature creature)
        {
            lock (creaturesLock)
                creatures.Add(creature.Id, creature);
        }

        public void RemoveCreature(Creature creature)
        {
            lock (creaturesLock)
                creatures.Remove(creature.Id);
        }

        public Creature GetCreature(WurmId id)
        {
            lock (creaturesLock)
            {
                if (creatures.TryGetValue(id, out var creature))
                    return creature;
            }

            return null;
        }

        public Creature[] GetAllCreatures()
        {
            Creature[] res;
            lock (creaturesLock)
                res = creatures.Values.ToArray();
            return res;
        }

        public void AddItem(Item item)
        {
            lock (itemsLock)
                items.Add(item.Id, item);
        }
        
        public void RemoveItem(Item item)
        {
            lock (itemsLock)
                items.Remove(item.Id);
        }

        public Item GetItem(WurmId id)
        {
            lock (itemsLock)
            {
                if (items.TryGetValue(id, out var item))
                    return item;
            }

            return null;
        }
    }
}
