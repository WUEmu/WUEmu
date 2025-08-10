using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.File
{
    public class EmptyMesh : IMesh
    {
        public int MeshSize => 10;
        
        public int GetTile(int x, int y)
        {
            var tile = GetTileValue((short)x, (short)y);
            return tile;
        }

        public Tile GetTileValue(short x, short y) => new Tile(x, y, 0, TileType.MineDoorGold, 0);

        public void SetTile(int x, int y, int value)
        {
        }

        public void SetTile(int x, int y, Tile value)
        {
        }
    }
}