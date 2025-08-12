using System;
using Serilog;

namespace WOEmu6.Core.Objects
{
    public class ObjectGateway
    {
        private readonly ObjectPool _pool;

        public ObjectGateway(ObjectPool pool)
        {
            _pool = pool;
        }
        
        public ObjectBase GetObject(WurmId id)
        {
            var world = ServerContext.Instance.Value.World;
            switch (id.Type)
            {
                case ObjectType.Tile:
                {
                    var coordinate = id.ToTileCoordinate();
                    return world.TopLayer.GetTileValue(coordinate.Item1, coordinate.Item2);
                }

                case ObjectType.TileBorder:
                {
                    var coordinate = id.ToTileCoordinate();
                    var direction = id.ToDirection();
                    Log.Debug("Coord({coordinate}, dir={direction})", coordinate, direction);
                    // break;
                    
                    return new TileBorder(id);
                }

                case ObjectType.Wall:
                {
                    return new StructureWall(id);
                }

                case ObjectType.Creature:
                {
                    var res = _pool.GetCreature(id);
                    if (res != null)
                        return res;
                    break;
                }

                case ObjectType.Item:
                {
                    var obj = world.GetItem(id);
                    if (obj != null)
                        return obj;
                    break;
                }

                default:
                    Log.Warning("Object not implemented yet for {id}", id);
                    break;
            }

            Log.Warning("Object with ID {id} not found", id);
            return null;
        }
    }
}