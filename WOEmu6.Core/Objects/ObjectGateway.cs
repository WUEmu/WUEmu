using System;

namespace WOEmu6.Core.Objects
{
    public class ObjectGateway
    {
        private readonly ServerContext context;

        public ObjectGateway(ServerContext context)
        {
            this.context = context;
        }
        
        public void GetObject(WurmId id)
        {
            switch (id.Type)
            {
                case ObjectType.Tile:
                {
                    var coordinate = id.ToTileCoordinate();
                    Console.WriteLine(coordinate);
                    break;
                }

                case ObjectType.TileBorder:
                {
                    var coordinate = id.ToTileCoordinate();
                    var direction = id.ToDirection();
                    Console.WriteLine($"Coord({coordinate}, dir={direction})");
                    break;
                }

                case ObjectType.Skill:
                {
                    Console.WriteLine("Skill");

                    break;
                }
                
                default:
                    Console.WriteLine($"Object not implemented yet for {id}");
                    break;
            }
        }
    }
}