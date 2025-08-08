namespace WOEmu6.Core.Packets.Server
{
    public enum SupportTicketCategory : byte
    {
        None = 0,
        Open = 0xFF,
        Forum = 0xFE,
        Watch = 0xFD,
        Closed = 0xFC
    }
    
    public enum ColorCode : byte
    {
        White,
        Black,
        NavyBlue,
        Green,
        Red,
        Maroon,
        Purple,
        Orange,
        Yellow,
        Lime,
        Teal,
        Cyan,
        RoyalBlue,
        Fuchsia,
        Grey,
        Silver,
        EnchantName,
        EnchantDescription,
        EnchantPower,
        Acid,
        Fire,
        Frost,
        
        System = 100,
        Error = 101
    }

    public enum TileType : byte
    {
        Hole,
        Sand,
        Grass,
        Tree,
        Rock,
        Dirt,
        Clay,
        Field,
        PackedDirt,
        Cobblestone,
        Mycelium,
        MyceliumTree,
        Lava,
        EnchantedGrass,
        EnchantedTree,
        Planks,
        StoneSlabs,
        Gravel,
        Peat,
        Tundra,
        Moss,
        Cliff,
        Steppe,
        Marsh,
        Tar,
        MineDoorWood,
        MineDoorStone,
        MineDoorGold,
        MineDoorSilver,
        MineDoorSteel,
        Snow,
        Bush,
        Kelp,
        Reed,
        EnchantedBush,
        MyceliumBush,
        SlateBricks,
        MarbleSlabs,
        Lawn,
        TarredPlanks,
        MyceliumLawn,
        RoughCobblestone,
        RoundCobblestone,
        Field2,
        SandstoneBricks,
        SandstoneSlabs,
        SlateSlabs,
        MarbleBricks,
        PotteryBricks,
        PreparedBridge,
        
        TreeBirch = 100,
        TreePine,
        TreeOak,
        TreeCedar,
        TreeWillow,
        TreeMaple,
        TreeApple,
        
        // ...
    }
}