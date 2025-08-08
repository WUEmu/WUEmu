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
        
        public long NewWurmId()
        {
            return Interlocked.Increment(ref counter);
        }
    }
}
