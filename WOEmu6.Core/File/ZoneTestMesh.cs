using System;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.File
{
    public class ZoneTestMesh : IMesh
    {
        private const int ZoneSize = 100;
        
        public int MeshSize => 10;
        
        public int GetTile(int x, int y)
        {
            var tile = GetTileValue((short)x, (short)y);
            return tile;
        }

        public Tile GetTileValue(short x, short y)
        {
            int zoneX = x / ZoneSize;
            int zoneY = y / ZoneSize;
            var tileType = (TileType)(((zoneX * 10) + zoneY) % (int)TileType.PotteryBricks);
            
            return new Tile(x, y, 1, tileType == TileType.Hole ? TileType.MineDoorWood : tileType, 0);
        }

        public void SetTile(int x, int y, int value)
        {
        }

        public void SetTile(int x, int y, Tile value)
        {
        }
    }
}