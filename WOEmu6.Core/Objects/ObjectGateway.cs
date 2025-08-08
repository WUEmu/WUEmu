using System;

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
                    Console.WriteLine($"Coord({coordinate}, dir={direction})");
                    // break;
                    
                    return new TileBorder(id);
                }

                case ObjectType.Skill:
                {
                    Console.WriteLine("Skill");

                    break;
                }

                case ObjectType.Wall:
                {
                    return new StructureWall(id);
                }

                default:
                    Console.WriteLine($"Object not implemented yet for {id}");
                    break;
            }

            return null;
        }
    }
}