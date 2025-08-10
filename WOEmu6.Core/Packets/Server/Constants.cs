namespace WOEmu6.Core.Packets.Server
{
    public enum ClientFeature : byte
    {
        Compass = 0,
        Binoculars = 1,
        Toolbelt = 2
    }

    public enum MapAnnotationCommand : byte
    {
        Create = 0,
        Delete,
        GetPermissions
    }

    public enum MapAnnotationType : byte
    {
        Player,
        Village,
        Alliance
    }

    public enum StructureType : byte
    {
        House,
        Bridge
    }

    public enum StructureFloorType : byte
    {
        Floor = 10,
        Door,
        Opening,
        Roof,
        Solid,
        Staircase,
        WideStaircase,
        RightStaircase,
        LeftStaircase,
        WideStaircaseRight,
        WideStaircaseLeft,
        WideStaircaseBoth,
        ClockwiseStaircase,
        AnticlockwiseStaircase,
        ClockwiseStaircaseWithBanisters,
        AnticlockwiseStaircaseWithBanisters
    }

    public enum StructureFloorState : byte
    {
        Planning = 0xFF,
        Building = 0,
        Completed = 0b10000000
    }

    public enum StructureFloorMaterial : byte
    {
        Wood,
        StoneBrick,
        SandstoneSlab,
        SlateSlab,
        Thatch,
        MetalIron,
        MetalSteel,
        MetalCopper,
        ClayBrick,
        MetalGold,
        MetalSilver,
        MarbleSlab,
        Standalone, // ?
        StoneSlab
    }

    public enum WallType : byte
    {
        Solid,
        Window,
        Door,
        DoubleDoor,
        Arched,
        NarrowWindow,
        Portcullis,
        Barred,
        Rubble,
        Balcony,
        Jetty,
        Oriel,
        CanopyDoor,
        WideWindow,
        ArchedLeft,
        ArchedRight,
        ArchedT,
        Scaffolding,
        Fence,
        // ...
        Plan = 127
    }

    public enum EffectType : short
    {
        Light,
        Fire,
        Transparent,
        Glow,
        Flames
    }

    public enum CreatureCondition : byte
    {
        Fierce = 1,
        Angry,
        Raging,
        Slow,
        Alert,
        Greenish,
        Lurking,
        Sly,
        Hardened,
        Scared,
        Diseased
    }

    public enum TileEffectType : byte
    {
        Tentacles = 34,
        FirePillar = 35,
        IcePillar = 36,
        FungusTrap = 37,
        Lava = 51,
        Snow = 53
    }
    
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

    public enum FishingRodType : byte
    {
        Pole,
        BasicRod,
        FineRod,
        DeepWaterRod,
        DeepSeaRod,
        BasicRodWithLine,
        FineRodWithLine,
        DeepWaterRodWithLine,
        DeepSeaRodWithLine
    }

    public enum FishType : byte
    {
        None,
        Roach,
        Perch,
        Trout,
        Pike,
        Catfish,
        Snook,
        Herring,
        Carp,
        Bass,
        Salmon,
        Octopus,
        Marlin,
        Blueshark,
        Dorado,
        Sailfish,
        Whiteshark,
        Tuna,
        Minnow,
        Loach,
        Wurmfish,
        Sardine,
        Clam
    }

    public enum FishingFloatType : byte
    {
        None,
        Feather,
        Twig,
        Moss,
        Bark
    }

    public enum FishingBaitType : byte
    {
        None,
        Fly,
        Cheese,
        Dough,
        Wurm,
        Sardine,
        Roach,
        Perch,
        Minnow,
        FishBait,
        Grub,
        Wheat,
        Corn
    }

    public enum FishingReelType : byte
    {
        None,
        Light,
        Medium,
        DeepWater,
        Professional
    }

    public enum FishingHookType : byte
    {
        None,
        Wood,
        Metal,
        Bone
    }

    public enum FishingSubCommand : byte
    {
        StartFishing
    }
}
