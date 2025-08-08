namespace WOEmu6.Core.Objects
{
    public enum ObjectType : byte
    {
        Tile = 0x03,
        Wall = 0x05,
        Fence = 0x07,
        TileBorder = 0x0C,
        Planet = 0x0E
    }

    public enum BorderDirection : byte
    {
        Horizontal = 0,
        Vertical = 2,
        Corner = 4
    }
}
