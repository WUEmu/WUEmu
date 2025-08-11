using System;
using Serilog;

namespace WOEmu6.Core.Objects
{
    public class ObjectGateway
    {
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
                    lock (world.creaturesLock)
                    {
                        if (world.creatures.TryGetValue(id, out var creature))
                            return creature;
                    }
                    
                    Log.Warning("Creature with ID {id} not found", id);
                    break;
                }

                default:
                    Log.Warning("Object not implemented yet for {id}", id);
                    break;
            }

            return null;
        }
    }
}