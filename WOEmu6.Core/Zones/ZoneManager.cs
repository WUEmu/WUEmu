using System.Collections.Generic;
using Serilog;

namespace WOEmu6.Core.Zones
{
    public class ZoneManager
    {
        private readonly World _world;
        private Dictionary<ZoneId, Zone> loadedZones;
        private object loadedZonesLock = new object();
        
        public ZoneManager(World world, IMesh map)
        {
            _world = world;
            var tileSize = 1 << map.MeshSize;
            loadedZones = new Dictionary<ZoneId, Zone>();
            
            Log.Information("ZoneManager initialized (tile size {size})", tileSize);
        }

        public Zone Load(short tileX, short tileY)
        {
            var id = new ZoneId(tileX, tileY);
            return Load(id);
        }

        public Zone Load(ZoneId id)
        {
            lock (loadedZonesLock)
            {
                if (loadedZones.TryGetValue(id, out var res))
                    return res;
            }

            var zone = new Zone(id, _world);
            lock (loadedZonesLock)
                loadedZones.Add(id, zone);
            
            // TODO placeholder for persistence, load stuff from database here.
            Log.Debug("Loaded new zone {zone}", id);
            return zone;
        }
    }
}
