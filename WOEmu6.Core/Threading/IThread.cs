using System.Threading;

namespace WOEmu6.Core.Threading
{
    public interface IThread
    {
        string Name { get; }

        void Run(CancellationToken cancellationToken);
    }
}
