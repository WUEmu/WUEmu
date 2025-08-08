namespace WOEmu6.Core.Objects
{
    public enum ObjectType : byte
    {
        Item = 0x02,
        Tile = 0x03,
        Wall = 0x05,
        Fence = 0x07,
        TileBorder = 0x0C,
        Planet = 0x0E,
        Spell = 0x0F,
        Plan = 0x10,
        CaveTile = 0x11,
        Skill = 0x12
    }

    public enum BorderDirection : byte
    {
        Horizontal = 0,
        Vertical = 2,
        Corner = 4
    }
}
