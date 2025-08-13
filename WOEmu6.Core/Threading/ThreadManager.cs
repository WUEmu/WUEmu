using System;
using System.Collections.Generic;

namespace WOEmu6.Core.Threading
{
    public class ThreadManager
    {
        // private List<EngineThread> threads;
        private readonly Dictionary<Guid, EngineThread> threads;
        private object threadLock = new object();
        private bool allowNewThreads = true;
        
        public ThreadManager()
        {
            threads = new Dictionary<Guid, EngineThread>();
        }

        public Guid Start(IThread thread)
        {
            if (!allowNewThreads)
                return Guid.Empty;
            
            var id = Guid.NewGuid();
            var engineThread = new EngineThread(thread);
            
            lock (threadLock)
                threads.Add(id, engineThread);

            engineThread.Start();
            return id;
        }

        public void Stop(Guid id)
        {
            lock (threadLock)
                threads.Remove(id);
        }

        public void StopAllThreads()
        {
            allowNewThreads = false;
            lock (threadLock)
            {
                foreach (var thread in threads.Values)
                    thread.Stop();
            }
        }
    }
}