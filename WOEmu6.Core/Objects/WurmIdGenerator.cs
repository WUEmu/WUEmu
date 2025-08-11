using System.Threading;

namespace WOEmu6.Core.Objects
{
    public class WurmIdGenerator
    {
        private long counter;

        public WurmIdGenerator(long current)
        {
            counter = current;
        }
        
        public WurmId NewWurmId(ObjectType type)
        {
            // TODO: have a counter per object type.
            var id = Interlocked.Increment(ref counter);
            return new WurmId(type, 0, id);
        }
    }
}
