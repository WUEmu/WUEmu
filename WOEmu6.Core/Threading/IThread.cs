namespace WOEmu6.Core.Threading
{
    public interface IThread
    {
        string Name { get; }

        void Run();
    }
}
