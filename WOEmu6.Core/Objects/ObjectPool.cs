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

        public ObjectPool()
        {
            creatures = new Dictionary<WurmId, Creature>();
            structures = new List<Structure>();
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
    }
}
