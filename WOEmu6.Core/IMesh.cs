using WOEmu6.Core.Objects;

namespace WOEmu6.Core
{
    public interface IMesh
    {
        int MeshSize { get; }
        
        int GetTile(int x, int y);

        Tile GetTileValue(short x, short y);

        void SetTile(int x, int y, int value);

        void SetTile(int x, int y, Tile value);
    }
}
