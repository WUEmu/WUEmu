using System;
using System.Threading;
using Serilog;

namespace WOEmu6.Core.Threading
{
    public class EngineThread
    {
        private readonly IThread _thread;
        private readonly Thread internalThread;
        private readonly CancellationTokenSource cancellationTokenSource;

        public EngineThread(IThread thread)
        {
            _thread = thread;
            cancellationTokenSource = new CancellationTokenSource();
            internalThread = new Thread(RunWrapper);
        }

        internal void Start()
        {
            Log.Debug("Starting thread {thread}", _thread.Name);
            internalThread.Start();
        }

        internal void Stop()
        {
            cancellationTokenSource.Cancel();
        }

        private void RunWrapper()
        {
            try
            {
                _thread.Run(cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception in thread {thread}", _thread.Name);
            }
        }
    }
}