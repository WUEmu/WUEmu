using System;
using Serilog;
using WOEmu6.Core.Timers;

namespace WOEmu6.Core.File
{
    public class FileMeshSaveTimer : WorldTimer
    {
        private readonly FileMesh _mesh;

        public FileMeshSaveTimer(FileMesh mesh)
        {
            _mesh = mesh;
        }

        public override string Name => "Mesh Save Timer";
        
        public override string Description => "Periodically saves the map to disk.";
        
        public override TimeSpan Interval => TimeSpan.FromMinutes(5);

        public override void Run()
        {
            Log.Information("Saving mesh file");
        }
    }
}
