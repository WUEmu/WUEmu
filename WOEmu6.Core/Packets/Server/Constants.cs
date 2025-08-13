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
        Completed = 127
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

    public enum TreeType : byte
    {
        Birch,
        Pine,
        Oak,
        Cedar,
        Willow,
        Maple,
        Apple,
        Lemon,
        Olive,
        Cherry,
        Chestnut,
        Walnut,
        Fir,
        Linden,
        Orange
    }

    public enum SelectionMenuAction : short
    {
        Open = 3,
        Close = 4
    }

    public enum ItemIcon
    {
        SHEET_ICONS = 0,

        SHEET_MISC = 1,

        SHEET_RESOURCE = 2,

        SHEET_TOOLS = 3,

        SHEET_ARMOR = 4,

        SHEET_WEAPONS = 5,

        SHEET_RESOURCE2 = 6,

        SHEET_NEXT = 7,

        ICONS_PER_SHEET = 240,

        ICONS_PER_LINE = 20,

        MAX_ICON_NUMBER = 1679,

        ICON_ICON_BODY_FULL = 0,

        ICON_ICON_BODY_TORSO = 1,

        ICON_ICON_BODY_HEAD = 2,

        ICON_ICON_BODY_ARM = 3,

        ICON_ICON_BODY_HAND = 4,

        ICON_ICON_BODY_LEG = 5,

        ICON_ICON_BODY_FOOT = 6,

        ICON_ICON_INVENTORY = 20,

        ICON_ICON_QUESTIONMARK = 60,

        ICON_ICON_UNFINISHED_ITEM = 60,

        ICON_CORPSE_HUMAN = 40,

        ICON_NONE = 60,

        ICON_HEART = 516,

        ICON_ARMOR_TORSO_CLOTH = 960,

        ICON_ARMOR_LEG_CLOTH = 961,

        ICON_ARMOR_ARM_CLOTH = 962,

        ICON_ARMOR_HEAD_CLOTH = 963,

        ICON_ARMOR_HAND_CLOTH = 964,

        ICON_ARMOR_FOOT_CLOTH = 965,

        ICON_ARMOR_TORSO_LEATHER = 980,

        ICON_ARMOR_LEG_LEATHER = 981,

        ICON_ARMOR_ARM_LEATHER = 982,

        ICON_ARMOR_HEAD_LEATHER = 983,

        ICON_ARMOR_HAND_LEATHER = 984,

        ICON_ARMOR_FOOT_LEATHER = 985,

        ICON_ARMOR_TORSO_STUDDED = 1000,

        ICON_ARMOR_LEG_STUDDED = 1001,

        ICON_ARMOR_ARM_STUDDED = 1002,

        ICON_ARMOR_HEAD_STUDDED = 1003,

        ICON_ARMOR_HAND_STUDDED = 1004,

        ICON_ARMOR_FOOT_STUDDED = 1005,

        ICON_ARMOR_TORSO_SCALE_DRAGON = 1020,

        ICON_ARMOR_LEG_SCALE_DRAGON = 1021,

        ICON_ARMOR_ARM_SCALE_DRAGON = 1022,

        ICON_ARMOR_HEAD_SCALE_DRAGON = 1023,

        ICON_ARMOR_HAND_SCALE_DRAGON = 1024,

        ICON_ARMOR_FOOT_SCALE_DRAGON = 1025,

        ICON_ARMOR_TORSO_CHAIN = 1040,

        ICON_ARMOR_LEG_CHAIN = 1041,

        ICON_ARMOR_ARM_CHAIN = 1042,

        ICON_ARMOR_HEAD_CHAIN = 1043,

        ICON_ARMOR_HAND_CHAIN = 1044,

        ICON_ARMOR_FOOT_CHAIN = 1045,

        ICON_ARMOR_TORSO_LEATHER_DRAKE = 1060,

        ICON_ARMOR_LEG_LEATHER_DRAKE = 1061,

        ICON_ARMOR_ARM_LEATHER_DRAKE = 1062,

        ICON_ARMOR_HEAD_LEATHER_DRAKE = 1063,

        ICON_ARMOR_HAND_LEATHER_DRAKE = 1064,

        ICON_ARMOR_FOOT_LEATHER_DRAKE = 1065,

        ICON_ARMOR_SCABBARD_LEATHER = 762,

        ICON_ARMOR_TORSO_METAL = 1080,

        ICON_ARMOR_LEG_METAL = 1081,

        ICON_ARMOR_ARM_METAL = 1082,

        ICON_ARMOR_HEAD_METAL = 1083,

        ICON_ARMOR_HAND_METAL = 1084,

        ICON_ARMOR_FOOT_METAL = 1085,

        ICON_ARMOR_HEAD_METAL_OPEN = 966,

        ICON_ARMOR_HEAD_METAL_BASINET = 967,

        ICON_ARMOR_HEAD_STEELCROWN = 969,

        ICON_ARMOR_HEAD_METAL_GREAT = 968,

        ICON_SHIELD_WOOD_SMALL = 970,

        ICON_SHIELD_WOODMETAL_SMALL = 990,

        ICON_SHIELD_METAL_SMALL = 1010,

        ICON_SHIELD_WOOD_MEDIUM = 971,

        ICON_SHIELD_WOODMETAL_MEDIUM = 991,

        ICON_SHIELD_METAL_MEDIUM = 1011,

        ICON_SHIELD_WOOD_LARGE = 972,

        ICON_SHIELD_WOODMETAL_LARGE = 992,

        ICON_SHIELD_METAL_LARGE = 1012,

        ICON_CONTAINER_WATERSKIN = 240,

        ICON_CONTAINER_BACKPACK = 241,

        ICON_CONTAINER_BAG = 242,

        ICON_CONTAINER_GIFT = 243,

        ICON_CONTAINER_CHEST = 244,

        ICON_CONTAINER_CHEST_LARGE = 244,

        ICON_CONTAINER_BARREL_LARGE = 245,

        ICON_CONTAINER_BARREL_SMALL = 245,

        ICON_CONTAINER_BUCKET_SMALL = 265,

        ICON_TOOL_FRUITPRESS = 246,

        ICON_TOOL_PAPYRUSPRESS = 246,

        ICON_TOOL_CHEESEDRILL = 266,

        ICON_TOOL_WHEEL = 247,

        ICON_TOOL_WHEEL_AXLE = 267,

        ICON_DECO_NECKLACE_GOLD = 248,

        ICON_DECO_NECKLACE_SILVER = 268,

        ICON_DECO_RING = 249,

        ICON_DECO_ARMRING = 250,

        ICON_DECO_CANDELABRA = 251,

        ICON_DECO_RING_GOLD = 249,

        ICON_DECO_RING_SILVER = 269,

        ICON_DECO_ARMRING_GOLD = 250,

        ICON_DECO_ARMRING_SILVER = 270,

        ICON_DECO_CANDELABRA_GOLD = 251,

        ICON_DECO_CANDELABRA_SILVER = 271,

        ICON_DECO_STATUETTE = 282,

        ICON_DECO_STATUETTE_GOLD = 283,

        ICON_WOOD_SIGN_SMALL = 252,

        ICON_WOOD_SIGN_LARGE = 272,

        ICON_WOOD_SIGN_POINTING = 292,

        ICON_WOOD_BED_HEADBOARD = 253,

        ICON_WOOD_BED_FOOTBOARD = 273,

        ICON_WOOD_BED_FRAME = 293,

        ICON_STONE_COFFIN = 254,

        ICON_DECO_ARCHERYTARGET = 255,

        ICON_DECO_RAFT_SMALL = 256,

        ICON_SCROLL_BLANK = 320,

        ICON_SCROLL_TEXT = 321,

        ICON_SCROLL_HOUSE = 322,

        ICON_SCROLL_VILLAGE = 340,

        ICON_HEALING_COVER = 341,

        ICON_MISC_POTION = 260,

        ICON_MISC_FLASK_GLASS = 261,

        ICON_SALVE_FARMERS = 262,

        ICON_TRADER_CONTRACT = 324,

        ICON_GOO_RED = 647,

        ICON_WAND_SILVER = 400,

        ICON_WAND_EBONY = 946,

        ICON_TWIG_FARWALKER = 759,

        ICON_AMULET_FARWALKER = 779,

        ICON_STONE_FARWALKER = 799,

        ICON_FOOD_SEED = 480,

        ICON_FOOD_WHEAT = 481,

        ICON_HERB_ONION = 482,

        ICON_HERB_GARLIC = 483,

        ICON_WOOD_TREESPROUT = 484,

        ICON_FOOD_CHERRIES = 485,

        ICON_FOOD_POTATO = 500,

        ICON_FOOD_PUMPKIN = 501,

        ICON_FOOD_CORN = 502,

        ICON_FOOD_MEAT = 503,

        ICON_FOOD_FISH = 504,

        ICON_FOOD_BREAD = 505,

        ICON_DECO_CHAIN = 520,

        ICON_FOOD_EGG = 521,

        ICON_FOOD_EGGLARGE = 522,

        ICON_FOOD_MEAT_COOKED = 523,

        ICON_FOOD_STEAK = 562,

        ICON_FOOD_FISH_FILET = 524,

        ICON_FOOD_DOUGH = 525,

        ICON_FOOD_RICE = 480,

        ICON_LIQUID_WATER = 540,

        ICON_LIQUID_TEA = 540,

        ICON_LIQUID_LEMONADE = 540,

        ICON_LIQUID_JAM = 540,

        ICON_LIQUID_LYE = 540,

        ICON_LIQUID_DYE = 540,

        ICON_LIQUID_MILK = 541,

        ICON_DECO_GEM_DIAMOND = 542,

        ICON_DECO_GEM_EMERALD = 543,

        ICON_DECO_GEM_RUBY = 544,

        ICON_FOOD_GRAPES_GREEN = 545,

        ICON_FIREWORKS = 60,

        ICON_FOOD_CHEESE = 561,

        ICON_DECO_GEM_OPAL = 563,

        ICON_DECO_GEM_SAPPHIRE = 564,

        ICON_FOOD_GRAPES_BLUE = 565,

        ICON_LIQUID_DYE_BLUE = 580,

        ICON_LIQUID_DYE_GREEN = 581,

        ICON_LIQUID_DYE_RED = 582,

        ICON_LIQUID_DYE_BLACK = 583,

        ICON_LIQUID_DYE_WHITE = 584,

        ICON_LIQUID_TAR = 585,

        ICON_COTTON = 600,

        ICON_FEATHER = 601,

        ICON_LEATHER_SKIN = 602,

        ICON_BODY_PELT = 602,

        ICON_BODY_FUR = 603,

        ICON_ARMOUR_CHAIN = 604,

        ICON_STRING = 620,

        ICON_WEMP_ROPE = 621,

        ICON_LEATHER_STRIP = 622,

        ICON_LEATHER_PIECES = 623,

        ICON_CLOTH_BOLT = 640,

        ICON_ASH = 641,

        ICON_FOOD_FLOUR = 642,

        ICON_FOOD_SALT = 643,

        ICON_FLOWER_ROSE = 660,

        ICON_FLOWER_LAVENDER = 661,

        ICON_GRASS_MIX = 702,

        ICON_HERB_BELLADONNA = 680,

        ICON_FLOWER_1 = 681,

        ICON_FLOWER_2 = 681,

        ICON_FLOWER_3 = 681,

        ICON_FLOWER_4 = 681,

        ICON_FLOWER_5 = 681,

        ICON_FLOWER_6 = 681,

        ICON_FLOWER_7 = 681,

        ICON_FLOWER_WOAD = 700,

        ICON_FOOD_MUSHROOM_RED = 486,

        ICON_FOOD_MUSHROOM_GREEN = 506,

        ICON_FOOD_MUSHROOM_YELLOW = 526,

        ICON_FOOD_MUSHROOM_BROWN = 546,

        ICON_FOOD_MUSHROOM_BLUE = 566,

        ICON_FOOD_MUSHROOM_BLACK = 586,

        ICON_WOOD_LOG = 606,

        ICON_WOOD_PLANK = 626,

        ICON_WOOD_SHINGLE = 626,

        ICON_WOOD_SHAFT = 646,

        ICON_WOOD_STAFFRUBY = 646,

        ICON_WOOD_STAFFEMERALD = 646,

        ICON_WOOD_STAFFOPAL = 646,

        ICON_WOOD_STAFFDIAMOND = 646,

        ICON_WOOD_STAFFSAPPHIRE = 646,

        ICON_WOOD_HANDLE = 666,

        ICON_WOOD_SCRAP = 686,

        ICON_HERB_ACORN = 487,

        ICON_FOOD_NUT_HAZEL = 507,

        ICON_HERB_NETTLES = 527,

        ICON_MOSS = 549,

        ICON_HERB_OREGANO = 703,

        ICON_HERB_PARSLEY = 704,

        ICON_HERB_BASIL = 627,

        ICON_HERB_THYME = 705,

        ICON_HERB_ROSEMARY = 706,

        ICON_HERB_CAMELLIA = 707,

        ICON_HERB_OLEANDER = 708,

        ICON_HERB_SASSAFRAS = 710,

        ICON_HERB_LOVAGE = 711,

        ICON_HERB_SAGE = 712,

        ICON_FOOD_LEMON = 488,

        ICON_FOOD_APPLE_GREEN = 508,

        ICON_FRUIT_STRAWBERRIES = 489,

        ICON_FRUIT_LINGONBERRY = 509,

        ICON_FRUIT_BLUEBERRY = 529,

        ICON_POTTERY_JAR_CLAY = 490,

        ICON_POTTERY_JAR = 510,

        ICON_POTTERY_BOWL_CLAY = 491,

        ICON_POTTERY_BOWL = 511,

        ICON_POTTERY_FLASK_CLAY = 492,

        ICON_POTTERY_FLASK = 512,

        ICON_POTTERY_BRICK_CLAY = 574,

        ICON_POTTERY_BRICK = 575,

        ICON_POTTERY_SHINGLE_CLAY = 576,

        ICON_POTTERY_SHINGLE = 577,

        ICON_KEY_MOLD = 493,

        ICON_KEY_FORM = 513,

        ICON_BODY_EYE = 494,

        ICON_BODY_TAIL = 514,

        ICON_BODY_HOOF = 534,

        ICON_BODY_TOOTH = 495,

        ICON_BODY_BLADDER = 515,

        ICON_BODY_PAW = 535,

        ICON_BODY_HORN = 496,

        ICON_BODY_BONES = 536,

        ICON_LIQUID_BLOOD = 582,

        ICON_BODY_SKULL = 556,

        ICON_COIN_GOLD = 570,

        ICON_COIN_SILVER = 571,

        ICON_COIN_IRON = 573,

        ICON_COIN_COPPER = 572,

        ICON_DIRT_PILE = 590,

        ICON_CLAY_PILE = 591,

        ICON_COAL_LUMP = 592,

        ICON_SAND_PILE = 593,

        ICON_MORTAR_PILE = 594,

        ICON_ROCK_PILE = 610,

        ICON_METAL_GOLD_ORE = 611,

        ICON_METAL_GOLD_LUMP = 631,

        ICON_METAL_GOLD_SCRAP = 651,

        ICON_METAL_SILVER_ORE = 612,

        ICON_METAL_SILVER_LUMP = 632,

        ICON_METAL_SILVER_SCRAP = 652,

        ICON_METAL_IRON_ORE = 613,

        ICON_ROCK_IRON_ORE = 618,

        ICON_METAL_IRON_LUMP = 633,

        ICON_METAL_IRON_SCRAP = 653,

        ICON_METAL_LEAD_ORE = 614,

        ICON_METAL_LEAD_LUMP = 634,

        ICON_METAL_LEAD_SCRAP = 654,

        ICON_METAL_ZINC_ORE = 615,

        ICON_METAL_ZINC_LUMP = 635,

        ICON_METAL_ZINC_SCRAP = 655,

        ICON_METAL_COPPER_ORE = 616,

        ICON_METAL_COPPER_LUMP = 636,

        ICON_METAL_COPPER_SCRAP = 656,

        ICON_METAL_TIN_ORE = 617,

        ICON_METAL_TIN_LUMP = 637,

        ICON_METAL_TIN_SCRAP = 657,

        ICON_METAL_ADAMANTINE_ORE = 596,

        ICON_METAL_ADAMANTINE_BOULDER = 60,

        ICON_METAL_ADAMANTINE_LUMP = 639,

        ICON_METAL_ADAMANTINE_SCRAP = 60,

        ICON_METAL_SERYLL_LUMP = 630,

        ICON_METAL_GLIMMERSTEEL_ORE = 595,

        ICON_METAL_GLIMMERSTEEL_BOULDER = 60,

        ICON_METAL_GLIMMERSTEEL_LUMP = 638,

        ICON_METAL_GLIMMERSTEEL_SCRAP = 60,

        ICON_ROCK_BRICK = 670,

        ICON_PEAT = 690,

        ICON_METAL_BRONZE_LUMP = 671,

        ICON_METAL_BRONZE_SCRAP = 691,

        ICON_METAL_STEEL_LUMP = 672,

        ICON_METAL_STEEL_SCRAP = 692,

        ICON_METAL_BRASS_LUMP = 673,

        ICON_METAL_BRASS_SCRAP = 693,

        ICON_CORNUCOPIA = 496,

        ICON_STONE_SLAB = 689,

        ICON_METAL_BAND = 709,

        ICON_METAL_CLAPPER_LARGE = 60,

        ICON_METAL_CLAPPER_SMALL = 60,

        ICON_METAL_BELL_HUGE = 298,

        ICON_METAL_BELL_SMALL = 278,

        ICON_WOOD_BELLCOT = 309,

        ICON_WOOD_BELLTOWER = 310,

        ICON_WOOD_BEAM = 553,

        ICON_PYLON = 60,

        ICON_SHRINE = 60,

        ICON_OBELISQUE = 60,

        ICON_TEMPLE = 60,

        ICON_SPIRITGATE = 60,

        ICON_PILLAR = 60,

        ICON_TOOL_KNIFE_BLADE = 720,

        ICON_TOOL_KNIFE = 740,

        ICON_TOOL_CARVING_KNIFE_BLADE = 720,

        ICON_TOOL_CARVING_KNIFE = 740,

        ICON_TOOL_BUTCHERING_KNIFE_BLADE = 735,

        ICON_TOOL_BUTCHERING_KNIFE = 755,

        ICON_TOOL_HAMMER_HEAD_WOODEN = 721,

        ICON_TOOL_HAMMER_WOODEN = 741,

        ICON_TOOL_HAMMER_HEAD_METAL = 722,

        ICON_TOOL_HAMMER_METAL = 742,

        ICON_TOOL_LEGGAT = 862,

        ICON_TOOL_PICKAXE_HEAD = 723,

        ICON_TOOL_PICKAXE = 743,

        ICON_TOOL_AXE_HEAD = 724,

        ICON_TOOL_AXE = 744,

        ICON_TOOL_RAKE_HEAD = 725,

        ICON_TOOL_RAKE = 745,

        ICON_TOOL_SHOVEL_HEAD = 726,

        ICON_TOOL_SHOVEL = 746,

        ICON_TOOL_SAW_HEAD = 727,

        ICON_TOOL_SAW = 747,

        ICON_TOOL_SCISSOR_BLADE = 728,

        ICON_TOOL_SCISSORS = 748,

        ICON_TOOL_FILE_BLADE = 729,

        ICON_TOOL_FILE = 749,

        ICON_TOOL_TROWEL_BLADE = 730,

        ICON_TOOL_TROWEL = 750,

        ICON_TOOL_CHISEL_BLADE = 731,

        ICON_TOOL_CHISEL = 751,

        ICON_WEAPON_SICKLE_BLADE = 732,

        ICON_WEAPON_SICKLE = 752,

        ICON_WEAPON_SCYTHE_BLADE = 733,

        ICON_WEAPON_SCYTHE = 753,

        ICON_TOOL_AWL_BLADE = 734,

        ICON_TOOL_AWL = 754,

        ICON_CONTAINER_QUIVER = 760,

        ICON_TOY_YOYO = 761,

        ICON_DECO_BOWL = 764,

        ICON_WOOD_HANDLE_LEATHER = 765,

        ICON_TOOL_KNIFE_LEATHER = 766,

        ICON_TOOL_FOOD_FORK = 767,

        ICON_TOOL_FOOD_SPOON = 768,

        ICON_TOOL_LOCKPICKS = 769,

        ICON_METAL_STUD = 770,

        ICON_TOOL_PLIERS = 780,

        ICON_TOOL_NAILS = 781,

        ICON_TOOL_SHAFT = 782,

        ICON_TOOL_FLINT_AND_STEEL = 783,

        ICON_TOOL_SAUCE_PAN = 784,

        ICON_TOOL_FRYING_PAN = 784,

        ICON_TOOL_HOOK = 785,

        ICON_TOOL_HOOK_METAL = 785,

        ICON_TOOL_FISHING_POLE = 786,

        ICON_TOOL_SPINDLE_EMPTY = 787,

        ICON_TOOL_NEEDLE = 788,

        ICON_TOOL_KEY = 789,

        ICON_TOOL_KEY_COPPER = 809,

        ICON_TOOL_LOCK = 790,

        ICON_TOOL_ANVIL = 791,

        ICON_TOOL_COMPASS = 792,

        ICON_DECO_BALL_COPPER = 793,

        ICON_DECO_BALL = 813,

        ICON_DECO_BALL_IRON = 813,

        ICON_TOOL_GRINDSTONE = 800,

        ICON_DECO_PENDULUM = 801,

        ICON_WOOD_TOOL_CLAY = 802,

        ICON_TOOL_WHETSTONE = 803,

        ICON_TOOL_CAULDRON = 804,

        ICON_TOOL_HOOK_WOOD = 805,

        ICON_DECO_MEDALLION = 464,

        ICON_TOOL_SPINDLE_FULL = 807,

        ICON_WOOD_SPATULA = 808,

        ICON_TOOL_TORCH_UNLIT = 820,

        ICON_TOOL_TORCH_LIT = 840,

        ICON_TOOL_CANDLE_UNLIT = 821,

        ICON_TOOL_CANDLE_LIT = 841,

        ICON_TOOL_LANTERN_UNLIT = 822,

        ICON_TOOL_LANTERN_LIT = 842,

        ICON_TOOL_LAMP_UNLIT = 823,

        ICON_TOOL_LAMP_LIT = 843,

        ICON_DECO_METAL_LAMP = 825,

        ICON_TOOL_SPYGLASS = 860,

        ICON_TOOL_ROPEMAKING = 880,

        ICON_DECO_PRACTICEDOLL = 881,

        ICON_TOOL_RANGE_POLE = 776,

        ICON_TOOL_PROTRACTOR = 422,

        ICON_TOOL_DIOPTRA = 775,

        ICON_TOOL_SIGHT = 421,

        ICON_WEAPON_KNIFE_BLADE = 1200,

        ICON_WEAPON_KNIFE = 1201,

        ICON_WEAPON_SWORD_BLADE_SHORT = 1203,

        ICON_WEAPON_SWORD_SHORT = 1204,

        ICON_WEAPON_SWORD_BLADE_LONG = 1223,

        ICON_WEAPON_SWORD_LONG = 1224,

        ICON_WEAPON_SWORD_BLADE_TWO = 1243,

        ICON_WEAPON_SWORD_TWO = 1244,

        ICON_WEAPON_SPEAR_LONG = 1221,

        ICON_WEAPON_SPEAR_TIP = 1220,

        ICON_WEAPON_SPEAR_STEEL = 60,

        ICON_WEAPON_HALBERD = 1247,

        ICON_WEAPON_HALBERD_BLADE = 1246,

        ICON_WEAPON_STAFF = 60,

        ICON_WEAPON_AXE_BLADE = 1206,

        ICON_WEAPON_AXE = 1207,

        ICON_WEAPON_AXE_DUAL_BLADE = 1226,

        ICON_WEAPON_AXE_DUAL = 1227,

        ICON_WEAPON_MACE_HEAD = 1209,

        ICON_WEAPON_MACE = 1210,

        ICON_WEAPON_MACE_SPIKED_HEAD = 1229,

        ICON_WEAPON_MACE_SPIKED = 1230,

        ICON_WEAPON_HAMMER_HEAD = 1212,

        ICON_WEAPON_HAMMER = 1213,

        ICON_WEAPON_MAUL_SMALL = 1213,

        ICON_WEAPON_MAUL_HEAD_SMALL = 1212,

        ICON_WEAPON_MAUL_MEDIUM = 1213,

        ICON_WEAPON_MAUL_HEAD_MEDIUM = 1212,

        ICON_WEAPON_HAMMER_LARGE_HEAD = 1232,

        ICON_WEAPON_HAMMER_LARGE = 1233,

        ICON_WEAPON_MAUL_HEAD_LARGE = 1232,

        ICON_WEAPON_MAUL_LARGE = 1233,

        ICON_WEAPON_CLUB_HUGE = 1239,

        ICON_WEAPON_BOW_SHORT = 1214,

        ICON_WEAPON_BOW_MEDIUM = 1234,

        ICON_WEAPON_BOW_LONG = 1254,

        ICON_WEAPON_ARROW_WAR = 1215,

        ICON_WEAPON_ARROW_HUNTING = 1235,

        ICON_WEAPON_ARROW_SHAFT = 1255,

        ICON_WEAPON_ARROWHEAD_HUNTING = 1236,

        ICON_WEAPON_ARROWHEAD_WAR = 1216,

        ICON_TOOL_TUNINGFORK = 739,

        ICON_ROCK_FLINT = 863,

        ICON_FOOD_OLIVES = 548,

        ICON_LIQUID_HONEY = 587,

        ICON_LIQUID_TANNIN = 583,

        ICON_LIQUID_TRANSMUTATION = 588,

        ICON_FOOD_STEW = 587,

        ICON_FOOD_CASSEROLE = 531,

        ICON_FOOD_SOUP = 531,

        ICON_FOOD_PORRIDGE = 608,

        ICON_FOOD_CAKE = 530,

        ICON_FOOD_GULASCH = 607,

        ICON_FOOD_PIGFOOD = 624,

        ICON_LIQUID_DISHWATER = 589,

        ICON_LIQUID_LAMPOIL = 60,

        ICON_LIQUID_MAPLE_SYRUP = 587,

        ICON_LIQUID_MAPLE_SAP = 587,

        ICON_LIQUID_FRUITJUICE = 582,

        ICON_LIQUID_OLIVEOIL = 587,

        ICON_LIQUID_WINERED = 582,

        ICON_LIQUID_WINEWHITE = 584,

        ICON_WEMP_PLANT = 547,

        ICON_WEMP_FIBRE = 547,

        ICON_REED_FIBRE = 60,

        ICON_REED_PEN = 275,

        ICON_LEATHER_BELT = 861,

        ICON_LEATHER_TOOLBELT = 861,

        ICON_WHIP_ONE = 1359,

        ICON_BODY_TALLOW = 498,

        ICON_BODY_DRAGON_SCAILS = 554,

        ICON_BODY_GLAND = 515,

        ICON_BODY_HORN_TWISTED = 496,

        ICON_BODY_HORN_LONG = 60,

        ICON_RESO_SHEET_STEEL = 675,

        ICON_RESO_SHEET_COPPER = 675,

        ICON_RESO_SHEET_IRON = 675,

        ICON_RESO_SHEET_SILVER = 676,

        ICON_RESO_SHEET_GOLD = 674,

        ICON_RESO_SHEET_TIN = 1447,

        ICON_RESO_SHEET_LEAD = 1446,

        ICON_RESO_FENCEBARS = 625,

        ICON_WOOD_BELAYINGPIN = 774,

        ICON_WOOD_JOISTS = 300,

        ICON_WOOD_WEAPONSRACKPOLEARMS = 60,

        ICON_WOOD_WEAPONSRACK = 60,

        ICON_WOOD_FLOORBOARDS = 293,

        ICON_WOOD_BUILDMARKER = 900,

        ICON_STRUCT_MINEDOORWOOD = 317,

        ICON_STRUCT_MINEDOORSTONE = 337,

        ICON_STRUCT_MINEDOORGOLD = 257,

        ICON_STRUCT_MINEDOORSILVER = 277,

        ICON_STRUCT_MINEDOORSTEEL = 297,

        ICON_WOOD_BOARD_VILLAGETOKEN = 60,

        ICON_METAL_WIRES = 555,

        ICON_METAL_HOOK = 845,

        ICON_METAL_DREDGELIP = 556,

        ICON_DECO_TABLE_ROUND = 60,

        ICON_DECO_STOOL_ROUND = 274,

        ICON_DECO_TABLE_SQUARE_SMALL = 60,

        ICON_DECO_CHAIR = 274,

        ICON_DECO_TABLE_SQUARE_LARGE = 60,

        ICON_DECO_CHAIR_ARMCHAIR = 274,

        ICON_DECO_RES_STONE = 463,

        ICON_DECORATION_SCEPTRE = 60,

        ICON_DECORATION_CROWN = 60,

        ICON_PART_CROWSNEST = 276,

        ICON_CONTAINER_MAILBOX_WOOD_1 = 60,

        ICON_CONTAINER_MAILBOX_WOOD_2 = 60,

        ICON_CONTAINER_MAILBOX_STONE_1 = 60,

        ICON_CONTAINER_MAILBOX_STONE_2 = 60,

        ICON_TOOL_STEELBRUSH = 882,

        ICON_TOOL_GROOMINGBRUSH = 902,

        ICON_TOOL_FOOD_KNIFE = 940,

        ICON_LARGE_CRATE = 311,

        ICON_SMALL_CRATE = 312,

        ICON_ARMOR_SUMMERHAT = 973,

        ICON_ARMOR_TORSO_KINGCLOAK = 60,

        ICON_ARMOR_TORSO_CLOAK_EMPEROR = 975,

        ICON_ARMOR_CLAW_EMPEROR = 1015,

        ICON_ARMOR_CROWN_THORNS = 995,

        ICON_ARMOR_TORSO_CLOAK_CHANCELLOR = 1095,

        ICON_ARMOR_CIRCLET_CHANCELLOR = 1115,

        ICON_ARMOR_SCEPTRE_CHANCELOOR = 1135,

        ICON_ARTIFACT_RODBEGUILING = 1259,

        ICON_ARTIFACT_CROWNMIGHT = 974,

        ICON_ARTIFACT_CHARM_FO = 859,

        ICON_ARTIFACT_EYE_VYNORA = 919,

        ICON_ARTIFACT_EAR_VYNORA = 879,

        ICON_ARTIFACT_MOUTH_VYNORA = 899,

        ICON_ARTIFACT_FINGER_FO = 1299,

        ICON_ARTIFACT_SWORD_MAGRANON = 1319,

        ICON_ARTIFACT_HAMMER_MAGRANON = 1339,

        ICON_ARTIFACT_SCAIL_LIBILA = 839,

        ICON_ARTIFACT_ORB_DOOM = 819,

        ICON_ARTIFACT_SCEPTRE_ASCENSION = 1279,

        ICON_ARTIFACT_VALREI = 462,

        ICON_RIDE_SADDLE = 757,

        ICON_RIDE_SADDLE_LARGE = 777,

        ICON_ARMOR_BARDING = 1120,

        ICON_RIDE_BARDING_CLOTH_LARGE = 1120,

        ICON_RIDE_BARDING_CHAIN_LARGE = 1120,

        ICON_RIDE_BARDING_LEATHER_LARGE = 1120,

        ICON_RIDE_BARDING_CLOTH_SMALL = 1120,

        ICON_RIDE_BARDING_CHAIN_SMALL = 1120,

        ICON_RIDE_BARDING_LEATHER_SMALL = 1120,

        ICON_RIDE_SADDLE_SEAT = 797,

        ICON_RIDE_SADDLE_SEAT_LARGE = 817,

        ICON_RIDE_GIRTH = 897,

        ICON_RIDE_BIT = 877,

        ICON_RIDE_STIRRUPS = 837,

        ICON_RIDE_HORSESHOE = 737,

        ICON_RIDE_BRIDLE = 917,

        ICON_RIDE_REINS = 957,

        ICON_RIDE_HEADSTALL = 937,

        ICON_CARPET_MEDITATION = 901,

        ICON_PUPPET_FO = 306,

        ICON_PUPPET_VYNORA = 303,

        ICON_PUPPET_MAGRANON = 305,

        ICON_PUPPET_LIBILA = 304,

        ICON_MISC_HANDMIRROR = 920,

        ICON_MISC_GOLDEN_MIRROR = 921,

        ICON_LIBRAM_NIGHT = 330,

        ICON_TOME_MAGIC_GREEN = 327,

        ICON_TOME_MAGIC_RED = 325,

        ICON_TOME_MAGIC_BLACK = 328,

        ICON_TOME_MAGIC_BLUE = 326,

        ICON_TOME_MAGIC_WHITE = 329,

        ICON_TOME_MAGIC_INCINERATION = 325,

        ICON_SCROLL_BINDING = 331,

        ICON_TOOL_SACRIFICIAL_KNIFE = 1379,

        ICON_FOOD_CHERRY_WHITE = 60,

        ICON_FOOD_CHERRY_RED = 713,

        ICON_FOOD_CHERRY_GREEN = 60,

        ICON_ROD_ERUPTION = 60,

        ICON_WAND_SEAS = 60,

        ICON_FOOD_CHESTNUT = 559,

        ICON_POTTERY_FLOWERPOT = 510,

        ICON_MARBLE_PLANTER = 60,

        ICON_WOUND_BITE = 80,

        ICON_WOUND_CRUSH = 81,

        ICON_WOUND_BURN = 82,

        ICON_WOUND_SLASH = 83,

        ICON_WOUND_PIERCE = 84,

        ICON_WOUND_INFECTION = 85,

        ICON_WOUND_POISON = 86,

        ICON_WOUND_COLD = 87,

        ICON_WOUND_WATER = 88,

        ICON_WOUND_INTERNAL = 89,

        ICON_WOUND_ACID = 90,

        ICON_WOUND_WOUND = 81,

        ICON_ARMOR_TABARD_CLOTH = 307,

        ICON_METAL_COPPER_BRAZIER_STAND = 557,

        ICON_METAL_COPPER_BRAZIER_BOWL = 302,

        ICON_DECO_MARBLE_BRAZIER_PILLAR = 60,

        ICON_METAL_LARGE_GOLD_BRAZIER_BOWL = 302,

        ICON_DECO_COPPER_BRAZIER = 301,

        ICON_TOOL_SPINNING_WHEEL = 826,

        ICON_FURN_LOUNGE_CHAIR = 274,

        ICON_FURN_ROYAL_OUNGE_CHAISE = 274,

        ICON_CONTAINER_CUPBOARD = 60,

        ICON_FURN_ROUND_MARBLE_TABLE = 60,

        ICON_FURN_SQUARE_MARBLE_TABLE = 60,

        ICON_MASKS = 465,

        ICON_ARMOR_HEAD_MASK_ENLIGHTENED = 465,

        ICON_ARMOR_HEAD_MASK_RAVAGER = 465,

        ICON_ARMOR_HEAD_MASK_PALE = 465,

        ICON_ARMOR_HEAD_MASK_SHADOW = 465,

        ICON_ARMOR_HEAD_MASK_CHALLENGE = 465,

        ICON_ARMOR_HEAD_MASK_ISLES = 465,

        ICON_FURN_TAPESTRY_STAND = 60,

        ICON_FURN_TAPESTRY = 60,

        ICON_PLANET_SOL = 60,

        ICON_PLANET_VALREI = 60,

        ICON_PLANET_JACKAL = 60,

        ICON_PLANET_SERIS = 60,

        ICON_PLANET_HAVEN = 60,

        ICON_PLANNED_ROOF_FLOOR = 60,

        ICON_ROOF_CLAY = 60,

        ICON_ROOF_SLATE = 60,

        ICON_ROOF_WOOD = 60,

        ICON_ROOF_THATCH = 60,

        ICON_ROOF_BRICK = 60,

        ICON_FLOOR_BRICK = 60,

        ICON_FLOOR_BRICK_CLAY = 60,

        ICON_FLOOR_WOOD = 60,

        ICON_FLOOR_MARBLE = 60,

        ICON_FLOOR_SANDSTONE = 60,

        ICON_FLOOR_SLAB = 60,

        ICON_FLOOR_SLATE = 60,

        ICON_FENCE_WOODEN = 60,

        ICON_FENCE_CRUDE = 60,

        ICON_FENCE_GATE_CRUDE = 60,

        ICON_FENCE_PALISADE = 60,

        ICON_FENCE_STONE_WALL = 60,

        ICON_FENCE_WOODEN_GATE = 60,

        ICON_FENCE_PALISADE_GATE = 60,

        ICON_FENCE_STONE_WALL_HIGH = 60,

        ICON_FENCE_IRON = 60,

        ICON_FENCE_IRON_GATE = 60,

        ICON_FENCE_WOVEN = 60,

        ICON_FENCE_STONE = 60,

        ICON_FENCE_MEDIUM_CHAIN = 60,

        ICON_FENCE_ROPE_LOW = 60,

        ICON_FENCE_ROPE_HIGH = 60,

        ICON_FENCE_GARDSGARD_LOW = 60,

        ICON_FENCE_GARDSGARD_HIGH = 60,

        ICON_FENCE_GARDSGARD_GATE = 60,

        ICON_FENCE_CURBE = 60,

        ICON_FENCE_IRON_HIGH = 60,

        ICON_FENCE_IRON_HIGH_GATE = 60,

        ICON_FENCE_PORTCULLIS = 60,

        ICON_FENCE_SIEGEWALL = 60,

        ICON_PARAPET_WOODEN = 60,

        ICON_PARAPET_STONE = 60,

        ICON_PARAPET_STONE_IRON = 60,

        ICON_WALL_RUBBLE = 60,

        ICON_FENCE_RUBBLE = 60,

        ICON_WALL_PLAN = 60,

        ICON_WALL_WOODEN_WALL = 60,

        ICON_WALL_WOODEN_WINDOW = 60,

        ICON_WALL_WOODEN_DOOR = 60,

        ICON_WALL_WOODEN_DOUBLE_DOOR = 60,

        ICON_WALL_WOODEN_ARCHED = 60,

        ICON_WALL_WOODEN_PORTCULLIS = 60,

        ICON_WALL_WOODEN_CANOPY = 60,

        ICON_WALL_WOODEN_WIDE_WINDOW = 60,

        ICON_WALL_WOODEN_ARCHED_LEFT = 60,

        ICON_WALL_WOODEN_ARCHED_RIGHT = 60,

        ICON_WALL_WOODEN_ARCHED_T = 60,

        ICON_WALL_STONE_WALL = 60,

        ICON_WALL_STONE_WINDOW = 60,

        ICON_WALL_STONE_DOOR = 60,

        ICON_WALL_STONE_DOUBLE_DOOR = 60,

        ICON_WALL_STONE_ARCHED = 60,

        ICON_WALL_STONE_PORTCULLIS = 60,

        ICON_WALL_STONE_ORIEL = 60,

        ICON_WALL_STONE_ARCHED_LEFT = 60,

        ICON_WALL_STONE_ARCHED_RIGHT = 60,

        ICON_WALL_STONE_ARCHED_T = 60,

        ICON_WALL_PLAIN_STONE_WALL = 60,

        ICON_WALL_PLAIN_STONE_WINDOW = 60,

        ICON_WALL_PLAIN_STONE_NARROW_WINDOW = 60,

        ICON_WALL_PLAIN_STONE_DOOR = 60,

        ICON_WALL_PLAIN_STONE_DOUBLE_DOOR = 60,

        ICON_WALL_PLAIN_STONE_ARCHED = 60,

        ICON_WALL_PLAIN_STONE_PORTCULLIS = 60,

        ICON_WALL_PLAIN_STONE_BARRED = 60,

        ICON_WALL_PLAIN_STONE_ORIEL = 60,

        ICON_WALL_PLAIN_STONE_ARCHED_LEFT = 60,

        ICON_WALL_PLAIN_STONE_ARCHED_RIGHT = 60,

        ICON_WALL_PLAIN_STONE_ARCHED_T = 60,

        ICON_WALL_SLATE_WALL = 60,

        ICON_WALL_SLATE_WINDOW = 60,

        ICON_WALL_SLATE_NARROW_WINDOW = 60,

        ICON_WALL_SLATE_DOOR = 60,

        ICON_WALL_SLATE_DOUBLE_DOOR = 60,

        ICON_WALL_SLATE_ARCHED = 60,

        ICON_WALL_SLATE_PORTCULLIS = 60,

        ICON_WALL_SLATE_BARRED = 60,

        ICON_WALL_SLATE_ORIEL = 60,

        ICON_WALL_SLATE_ARCHED_LEFT = 60,

        ICON_WALL_SLATE_ARCHED_RIGHT = 60,

        ICON_WALL_SLATE_ARCHED_T = 60,

        ICON_WALL_ROUNDED_STONE_WALL = 60,

        ICON_WALL_ROUNDED_STONE_WINDOW = 60,

        ICON_WALL_ROUNDED_STONE_NARROW_WINDOW = 60,

        ICON_WALL_ROUNDED_STONE_DOOR = 60,

        ICON_WALL_ROUNDED_STONE_DOUBLE_DOOR = 60,

        ICON_WALL_ROUNDED_STONE_ARCHED = 60,

        ICON_WALL_ROUNDED_STONE_PORTCULLIS = 60,

        ICON_WALL_ROUNDED_STONE_BARRED = 60,

        ICON_WALL_ROUNDED_STONE_ORIEL = 60,

        ICON_WALL_ROUNDED_STONE_ARCHED_LEFT = 60,

        ICON_WALL_ROUNDED_STONE_ARCHED_RIGHT = 60,

        ICON_WALL_ROUNDED_STONE_ARCHED_T = 60,

        ICON_WALL_POTTERY_WALL = 60,

        ICON_WALL_POTTERY_WINDOW = 60,

        ICON_WALL_POTTERY_NARROW_WINDOW = 60,

        ICON_WALL_POTTERY_DOOR = 60,

        ICON_WALL_POTTERY_DOUBLE_DOOR = 60,

        ICON_WALL_POTTERY_ARCHED = 60,

        ICON_WALL_POTTERY_PORTCULLIS = 60,

        ICON_WALL_POTTERY_BARRED = 60,

        ICON_WALL_POTTERY_ORIEL = 60,

        ICON_WALL_POTTERY_ARCHED_LEFT = 60,

        ICON_WALL_POTTERY_ARCHED_RIGHT = 60,

        ICON_WALL_POTTERY_ARCHED_T = 60,

        ICON_WALL_SANDSTONE_WALL = 60,

        ICON_WALL_SANDSTONE_WINDOW = 60,

        ICON_WALL_SANDSTONE_NARROW_WINDOW = 60,

        ICON_WALL_SANDSTONE_DOOR = 60,

        ICON_WALL_SANDSTONE_DOUBLE_DOOR = 60,

        ICON_WALL_SANDSTONE_ARCHED = 60,

        ICON_WALL_SANDSTONE_PORTCULLIS = 60,

        ICON_WALL_SANDSTONE_BARRED = 60,

        ICON_WALL_SANDSTONE_ORIEL = 60,

        ICON_WALL_SANDSTONE_ARCHED_LEFT = 60,

        ICON_WALL_SANDSTONE_ARCHED_RIGHT = 60,

        ICON_WALL_SANDSTONE_ARCHED_T = 60,

        ICON_WALL_RENDERED_WALL = 60,

        ICON_WALL_RENDERED_WINDOW = 60,

        ICON_WALL_RENDERED_NARROW_WINDOW = 60,

        ICON_WALL_RENDERED_DOOR = 60,

        ICON_WALL_RENDERED_DOUBLE_DOOR = 60,

        ICON_WALL_RENDERED_ARCHED = 60,

        ICON_WALL_RENDERED_PORTCULLIS = 60,

        ICON_WALL_RENDERED_BARRED = 60,

        ICON_WALL_RENDERED_ORIEL = 60,

        ICON_WALL_RENDERED_ARCHED_LEFT = 60,

        ICON_WALL_RENDERED_ARCHED_RIGHT = 60,

        ICON_WALL_RENDERED_ARCHED_T = 60,

        ICON_WALL_MARBLE_WALL = 60,

        ICON_WALL_MARBLE_WINDOW = 60,

        ICON_WALL_MARBLE_NARROW_WINDOW = 60,

        ICON_WALL_MARBLE_DOOR = 60,

        ICON_WALL_MARBLE_DOUBLE_DOOR = 60,

        ICON_WALL_MARBLE_ARCHED = 60,

        ICON_WALL_MARBLE_PORTCULLIS = 60,

        ICON_WALL_MARBLE_BARRED = 60,

        ICON_WALL_MARBLE_ORIEL = 60,

        ICON_WALL_MARBLE_ARCHED_LEFT = 60,

        ICON_WALL_MARBLE_ARCHED_RIGHT = 60,

        ICON_WALL_MARBLE_ARCHED_T = 60,

        ICON_WALL_TIMBER_FRAMED_WALL = 60,

        ICON_WALL_TIMBER_FRAMED_WINDOW = 60,

        ICON_WALL_TIMBER_FRAMED_DOOR = 60,

        ICON_WALL_TIMBER_FRAMED_DOUBLE_DOOR = 60,

        ICON_WALL_TIMBER_FRAMED_ARCHED = 60,

        ICON_WALL_TIMBER_FRAMED_BALCONY = 60,

        ICON_WALL_TIMBER_FRAMED_JETTY = 60,

        ICON_WALL_TIMBER_FRAMED_ARCHED_LEFT = 60,

        ICON_WALL_TIMBER_FRAMED_ARCHED_RIGHT = 60,

        ICON_WALL_TIMBER_FRAMED_ARCHED_T = 60,

        ICON_FLOWERBED_BLUE = 60,

        ICON_FLOWERBED_GREENISH_YELLOW = 60,

        ICON_FLOWERBED_ORANGE_RED = 60,

        ICON_FLOWERBED_PURPLE = 60,

        ICON_FLOWERBED_WHITE = 60,

        ICON_FLOWERBED_WHITE_DOTTED = 60,

        ICON_FLOWERBED_YELLOW = 60,

        ICON_HEDGE_LAVENDER_LOW = 60,

        ICON_HEDGE_LAVENDER_MEDIUM = 60,

        ICON_HEDGE_LAVENDER_HIGH = 60,

        ICON_HEDGE_OLEANDER_LOW = 60,

        ICON_HEDGE_OLEANDER_MEDIUM = 60,

        ICON_HEDGE_OLEANDER_HIGH = 60,

        ICON_HEDGE_CAMELLIA_LOW = 60,

        ICON_HEDGE_CAMELLIA_MEDIUM = 60,

        ICON_HEDGE_CAMELLIA_HIGH = 60,

        ICON_HEDGE_ROSE_LOW = 60,

        ICON_HEDGE_ROSE_MEDIUM = 60,

        ICON_HEDGE_ROSE_HIGH = 60,

        ICON_HEDGE_THORN_LOW = 60,

        ICON_HEDGE_THORN_MEDIUM = 60,

        ICON_HEDGE_THORN_HIGH = 60,

        ICON_HEDGE_CEDAR_LOW = 60,

        ICON_HEDGE_CEDAR_MEDIUM = 60,

        ICON_HEDGE_CEDAR_HIGH = 60,

        ICON_HEDGE_MAPLE_LOW = 60,

        ICON_HEDGE_MAPLE_MEDIUM = 60,

        ICON_HEDGE_MAPLE_HIGH = 60,

        ICON_FENCE_MAGIC_STONE = 60,

        ICON_FENCE_MAGIC_FIRE = 60,

        ICON_FENCE_MAGIC_ICE = 60,

        ICON_TILE_HOLE = 60,

        ICON_TILE_SAND = 60,

        ICON_TILE_GRASS = 60,

        ICON_TILE_TREE = 60,

        ICON_TILE_BUSH = 60,

        ICON_TILE_ENCHANTED_GRASS = 60,

        ICON_TILE_ENCHANTED_TREE = 60,

        ICON_TILE_ENCHANTED_BUSH = 60,

        ICON_TILE_MYCELIUM = 60,

        ICON_TILE_MYCELIUM_TREE = 60,

        ICON_TILE_MYCELIUM_BUSH = 60,

        ICON_TILE_ROCK = 60,

        ICON_TILE_DIRT = 60,

        ICON_TILE_DIRT_PACKED = 60,

        ICON_TILE_CLAY = 60,

        ICON_TILE_FIELD = 60,

        ICON_TILE_LAVA = 60,

        ICON_TILE_PLANKS = 60,

        ICON_TILE_STONE_SLABS = 60,

        ICON_TILE_GRAVEL = 60,

        ICON_TILE_PEAT = 60,

        ICON_TILE_TUNDRA = 60,

        ICON_TILE_MOSS = 60,

        ICON_TILE_CLIFF = 60,

        ICON_TILE_STEPPE = 60,

        ICON_TILE_MARSH = 60,

        ICON_TILE_TAR = 60,

        ICON_TILE_SNOW = 60,

        ICON_TILE_KELP = 60,

        ICON_TILE_REED = 60,

        ICON_TILE_SLATE_SLAB = 60,

        ICON_TILE_MARBLE_SLAB = 60,

        ICON_TILE_LAWN = 60,

        ICON_TILE_PLANK_TARRED = 60,

        ICON_TILE_MYCELIUM_LAWN = 60,

        ICON_TILE_COBBLESTONE = 60,

        ICON_TILE_COBBLESTONE_ROUGH = 60,

        ICON_TILE_COBBLESTONE_ROUND = 60,

        ICON_TILE_SANDSTONE_BRICK = 60,

        ICON_TILE_SANDSTONE_SLAB = 60,

        ICON_TILE_SLATE_BRICK = 60,

        ICON_TILE_MARBLE_BRICK = 60,

        ICON_TILE_POTTERY_BRICK = 60,

        ICON_TILE_COBBLESTONE_NW = 60,

        ICON_TILE_COBBLESTONE_NE = 60,

        ICON_TILE_COBBLESTONE_SE = 60,

        ICON_TILE_COBBLESTONE_SW = 60,

        ICON_TILE_MINE_DOOR_WOOD = 60,

        ICON_TILE_MINE_DOOR_STONE = 60,

        ICON_TILE_MINE_DOOR_GOLD = 60,

        ICON_TILE_MINE_DOOR_SILVER = 60,

        ICON_TILE_MINE_DOOR_STEEL = 60,

        ICON_TILE_CAVE = 60,

        ICON_TILE_CAVE_EXIT = 60,

        ICON_TILE_CAVE_WALL = 60,

        ICON_TILE_CAVE_WALL_REINFORCED = 60,

        ICON_TILE_CAVE_WALL_LAVA = 60,

        ICON_TILE_CAVE_WALL_SLATE = 60,

        ICON_TILE_CAVE_WALL_MARBLE = 60,

        ICON_TILE_CAVE_FLOOR_REINFORCED = 60,

        ICON_TILE_CAVE_WALL_ORE_GOLD = 60,

        ICON_TILE_CAVE_WALL_ORE_SILVER = 60,

        ICON_TILE_CAVE_WALL_ORE_IRON = 1234,

        ICON_TILE_CAVE_WALL_ORE_COPPER = 60,

        ICON_TILE_CAVE_WALL_ORE_LEAD = 60,

        ICON_TILE_CAVE_WALL_ORE_ZINC = 60,

        ICON_TILE_CAVE_WALL_ORE_TIN = 60,

        ICON_TILE_CAVE_WALL_ORE_ADAMANTINE = 60,

        ICON_TILE_CAVE_WALL_ORE_GLIMMERSTEEL = 60,

        ICON_WEAPON_ORB_ACID = 60,

        ICON_WEAPON_ORB_FIRE = 60,

        ICON_WEAPON_ORB_LIGHTNING = 60,

        ICON_WEAPON_ORB_ICE = 60,

        ICON_WOOL = 558,

        ICON_BRIDGE_WOOD_ABUTMENT = 440,

        ICON_BRIDGE_WOOD_CROWN = 441,

        ICON_BRIDGE_WOOD_SUPPORT = 442,

        ICON_BRIDGE_BRICK_ABUTMENT = 443,

        ICON_BRIDGE_BRICK_BRACING = 444,

        ICON_BRIDGE_BRICK_CROWN = 445,

        ICON_BRIDGE_BRICK_DOUBLE_BRACING = 446,

        ICON_BRIDGE_BRICK_DOUBLE_ABUTMENT = 447,

        ICON_BRIDGE_BRICK_FLOATING = 448,

        ICON_BRIDGE_BRICK_SUPPORT = 449,

        ICON_BRIDGE_MARBLE_ABUTMENT = 450,

        ICON_BRIDGE_MARBLE_BRACING = 451,

        ICON_BRIDGE_MARBLE_CROWN = 452,

        ICON_BRIDGE_MARBLE_DOUBLE_BRACING = 453,

        ICON_BRIDGE_MARBLE_DOUBLE_ABUTMENT = 454,

        ICON_BRIDGE_MARBLE_FLOATING = 455,

        ICON_BRIDGE_MARBLE_SUPPORT = 456,

        ICON_BRIDGE_ROPE_ABUTMENT = 457,

        ICON_BRIDGE_ROPE_CROWN = 458,

        ICON_BRIDGE_ROPE_DOUBLE_ABUTMENT = 459,

        ICON_BRIDGE_SLATE_ABUTMENT = 430,

        ICON_BRIDGE_SLATE_BRACING = 431,

        ICON_BRIDGE_SLATE_CROWN = 432,

        ICON_BRIDGE_SLATE_DOUBLE_BRACING = 433,

        ICON_BRIDGE_SLATE_DOUBLE_ABUTMENT = 434,

        ICON_BRIDGE_SLATE_FLOATING = 435,

        ICON_BRIDGE_SLATE_SUPPORT = 436,

        ICON_BRIDGE_ROUNDED_STONE_ABUTMENT = 410,

        ICON_BRIDGE_ROUNDED_STONE_BRACING = 411,

        ICON_BRIDGE_ROUNDED_STONE_CROWN = 412,

        ICON_BRIDGE_ROUNDED_STONE_DOUBLE_BRACING = 413,

        ICON_BRIDGE_ROUNDED_STONE_DOUBLE_ABUTMENT = 414,

        ICON_BRIDGE_ROUNDED_STONE_FLOATING = 415,

        ICON_BRIDGE_ROUNDED_STONE_SUPPORT = 416,

        ICON_BRIDGE_POTTERY_ABUTMENT = 390,

        ICON_BRIDGE_POTTERY_BRACING = 391,

        ICON_BRIDGE_POTTERY_CROWN = 392,

        ICON_BRIDGE_POTTERY_DOUBLE_BRACING = 393,

        ICON_BRIDGE_POTTERY_DOUBLE_ABUTMENT = 394,

        ICON_BRIDGE_POTTERY_FLOATING = 395,

        ICON_BRIDGE_POTTERY_SUPPORT = 396,

        ICON_BRIDGE_SANDSTONE_ABUTMENT = 370,

        ICON_BRIDGE_SANDSTONE_BRACING = 371,

        ICON_BRIDGE_SANDSTONE_CROWN = 372,

        ICON_BRIDGE_SANDSTONE_DOUBLE_BRACING = 373,

        ICON_BRIDGE_SANDSTONE_DOUBLE_ABUTMENT = 374,

        ICON_BRIDGE_SANDSTONE_FLOATING = 375,

        ICON_BRIDGE_SANDSTONE_SUPPORT = 376,

        ICON_BRIDGE_RENDERED_ABUTMENT = 350,

        ICON_BRIDGE_RENDERED_BRACING = 351,

        ICON_BRIDGE_RENDERED_CROWN = 352,

        ICON_BRIDGE_RENDERED_DOUBLE_BRACING = 353,

        ICON_BRIDGE_RENDERED_DOUBLE_ABUTMENT = 354,

        ICON_BRIDGE_RENDERED_FLOATING = 355,

        ICON_BRIDGE_RENDERED_SUPPORT = 356,

        ICON_POTTERY_AMPHORA_CLAY = 662,

        ICON_POTTERY_AMPHORA = 682,

        ICON_CONCH = 342,

        ICON_BIRDCAGE = 361,

        ICON_DECO_BED_STANDARD = 313,

        ICON_CART = 332,

        ICON_DECO_TAPESTRY = 333,

        ICON_DECO_YULEGOAT = 334,

        ICON_DECO_GRAVESTONE = 335,

        ICON_DECO_SNOWLANTERN = 336,

        ICON_DECO_STOOL = 274,

        ICON_TOOL_SMALL_TACKLE = 827,

        ICON_TOOL_LARGE_TACKLE = 828,

        ICON_TOOL_OAR = 829,

        ICON_TOOL_LARGE_CHAINLINK = 830,

        ICON_TOOL_YOKE = 830,

        ICON_FOOD_WALNUT = 579,

        ICON_THATCH = 599,

        ICON_KELP = 599,

        ICON_HORN = 497,

        ICON_FAT = 498,

        ICON_SHOULDER_1 = 1140,

        ICON_SHOULDER_2 = 1140,

        ICON_SHOULDER_3 = 1140,

        ICON_SHOULDER_4 = 1140,

        ICON_SHOULDER_5 = 1140,

        ICON_SHOULDER_6 = 1140,

        ICON_SHOULDER_7 = 1140,

        ICON_SHOULDER_8 = 1140,

        ICON_SHOULDER_9 = 1140,

        ICON_SHOULDER_10 = 1140,

        ICON_SHOULDER_11 = 1140,

        ICON_SHOULDER_12 = 1140,

        ICON_SHOULDER_13 = 1140,

        ICON_SHOULDER_14 = 1140,

        ICON_SHOULDER_15 = 1140,

        ICON_SHOULDER_16 = 1140,

        ICON_SHOULDER_17 = 1140,

        ICON_DECO_RING_RIFT_1 = 249,

        ICON_DECO_RING_RIFT_2 = 249,

        ICON_DECO_RING_RIFT_3 = 249,

        ICON_DECO_RING_RIFT_4 = 249,

        ICON_DECO_RING_RIFT_5 = 249,

        ICON_DECO_ARMRING_RIFT1 = 250,

        ICON_DECO_ARMRING_RIFT2 = 250,

        ICON_DECO_ARMRING_RIFT3 = 250,

        ICON_DECO_ARMRING_RIFT4 = 250,

        ICON_DECO_ARMRING_RIFT5 = 250,

        ICON_DECO_NECKLACE_RIFT1 = 268,

        ICON_DECO_NECKLACE_RIFT2 = 268,

        ICON_DECO_NECKLACE_RIFT3 = 268,

        ICON_DECO_NECKLACE_RIFT4 = 268,

        ICON_DECO_NECKLACE_RIFT5 = 268,

        ICON_HERB_FENNEL = 569,

        ICON_HERB_MINT = 701,

        ICON_FENNEL_PLANT = 569,

        ICON_FOOD_CABBAGE = 715,

        ICON_FOOD_CARROT = 714,

        ICON_FOOD_CUCUMBER = 684,

        ICON_FOOD_LETTUCE = 718,

        ICON_FOOD_PEAPOD = 719,

        ICON_FOOD_SUGAR = 642,

        ICON_FOOD_SUGARBEET = 717,

        ICON_FOOD_TOMATO = 716,

        ICON_FOOD_ORANGE = 658,

        ICON_SPICE_CUMIN = 694,

        ICON_SPICE_GINGER = 696,

        ICON_SPICE_NUTMEG = 697,

        ICON_SPICE_PAPRIKA = 698,

        ICON_SPICE_TURMERIC = 699,

        ICON_FOOD_COCOA_BEAN = 518,

        ICON_FOOD_PEA = 683,

        ICON_CAKE_TIN = 263,

        ICON_MEASURING_JUG_CLAY = 294,

        ICON_MEASURING_JUG = 314,

        ICON_PIE_DISH_CLAY = 491,

        ICON_PIE_DISH = 511,

        ICON_PLATE_WOOD = 295,

        ICON_ROASTING_DISH_CLAY = 264,

        ICON_ROASTING_DISH = 284,

        ICON_BAKING_STONEWARE = 285,

        ICON_BEER_STEIN_CLAY = 258,

        ICON_BEER_STEIN = 259,

        ICON_SMALL_SKULL = 296,

        ICON_SKULL_CUP = 315,

        ICON_BEE_SMOKER = 736,

        ICON_BEESWAX = 498,

        ICON_WOOD_HIVE = 287,

        ICON_MORTAR_AND_PESTLE = 756,

        ICON_COPPER_STILL = 290,

        ICON_SEALING_KIT = 498,

        ICON_SNOWBALL = 632,

        ICON_CONTAINER_LARDER = 286,

        ICON_FOOD_COCONUT = 500,

        ICON_FOOD_SWEET = 1442,

        ICON_COOKER_FORGE = 288,

        ICON_COOKER_OVEN = 289,

        ICON_COOKER_CAMPFIRE = 291,

        ICON_FOOD_BACON = 663,

        ICON_FOOD_BATTER = 584,

        ICON_FOOD_BISCUIT = 532,

        ICON_FOOD_BISCUIT_MIX = 525,

        ICON_FOOD_BREADCRUMBS = 538,

        ICON_FOOD_BUTTER = 609,

        ICON_FOOD_CAKE_MIX = 525,

        ICON_FOOD_COCOA = 518,

        ICON_FOOD_CHEESECAKE = 533,

        ICON_FOOD_CHOCOLATE = 624,

        ICON_FOOD_CHOCOLATE_NUT = 624,

        ICON_LIQUID_CREAM = 541,

        ICON_FOOD_CRISPS = 537,

        ICON_FOOD_CROUTONS = 538,

        ICON_FOOD_CURRY = 539,

        ICON_FOOD_CHIPS = 685,

        ICON_LIQUID_GELATINE = 587,

        ICON_FOOD_HAGGIS = 578,

        ICON_FOOD_HOGROAST = 597,

        ICON_FOOD_ICING = 642,

        ICON_FOOD_JELLY = 628,

        ICON_FOOD_LAMBSPIT = 629,

        ICON_FOOD_MEATBALLS = 648,

        ICON_FOOD_MUFFIN = 644,

        ICON_FOOD_MUSHY_PEA = 683,

        ICON_FOOD_NORI = 645,

        ICON_FOOD_OMELETTE = 649,

        ICON_LIQUID_PASSATA = 582,

        ICON_FOOD_PASTA = 659,

        ICON_FOOD_PASTRY = 664,

        ICON_FOOD_PASTY = 665,

        ICON_LIQUID_PESTO = 581,

        ICON_FOOD_PICKLE = 667,

        ICON_FOOD_PIE = 668,

        ICON_FOOD_PINENUT = 519,

        ICON_FOOD_PINEAPPLE = 669,

        ICON_FOOD_PIZZA = 678,

        ICON_FOOD_PUDDING = 679,

        ICON_FRUIT_RASPBERRIES = 677,

        ICON_FOOD_RATONASTICK = 687,

        ICON_FOOD_SALAD = 688,

        ICON_FOOD_SAUSAGE = 695,

        ICON_FOOD_SAUSAGE_SKIN = 695,

        ICON_FOOD_SCONE = 1440,

        ICON_FOOD_SCONE_MIX = 525,

        ICON_FOOD_BREADSLICE = 505,

        ICON_FOOD_SPAGHETTI = 659,

        ICON_FOOD_STIRFRY = 539,

        ICON_FOOD_SUSHI = 1441,

        ICON_FOOD_TART = 1442,

        ICON_FOOD_TOAST = 1444,

        ICON_FOOD_KETCHUP = 582,

        ICON_LIQUID_BEER = 568,

        ICON_LIQUID_BRANDY = 568,

        ICON_LIQUID_CIDER = 550,

        ICON_LIQUID_COOKING_OIL = 587,

        ICON_LIQUID_CUSTARD = 608,

        ICON_LIQUID_GIN = 551,

        ICON_LIQUID_GRAVY = 568,

        ICON_HONEY_WATER = 587,

        ICON_FUDGE_SAUCE = 584,

        ICON_LIQUID_MEAD = 608,

        ICON_LIQUID_MOONSHINE = 551,

        ICON_LIQUID_STOCK = 568,

        ICON_LIQUID_VINEGAR = 552,

        ICON_LIQUID_VODKA = 551,

        ICON_LIQUID_WHISKY = 552,

        ICON_LIQUID_WHITE_SAUCE = 584,

        ICON_LIQUID_WORT = 568,

        ICON_FOOD_ICECREAM = 598,

        ICON_FOOD_COOKIE = 532,

        IRON_RUNE_MAG = 381,

        IRON_RUNE_FO = 382,

        IRON_RUNE_VYN = 383,

        IRON_RUNE_LIB = 384,

        IRON_RUNE_JACKAL = 385,

        ICON_RECIPE_BAKED_APPLE = 1445,

        ICON_CONTAINER_WINE_BARREL_RACK = 401,

        ICON_CONTAINER_SMALL_BARREL_RACK = 402,

        ICON_CONTAINER_PLANTER_RACK = 421,

        ICON_CONTAINER_AMPHORA_RACK = 422,

        ICON_CONTAINER_LUNCHBOX = 423,

        ICON_CONTAINER_THERMOS = 425,

        ICON_CONTAINER_FOODTIN = 426,

        ICON_CONTAINER_XMAS_LUNCHBOX = 424,

        ICON_TRELLIS = 420,

        ICON_LEAD_ANCHOR = 460,

        ICON_MOORING_ANCHOR = 461,

        ICON_KEYSTONE = 466,

        ICON_HOTA_STATUE = 467,

        ICON_FSB = 468,

        ICON_BSB = 469,

        ICON_METAL_LARGE_CHAIN_LINK = 470,

        ICON_ROAD_WAYSTONE = 361,

        ICON_ROAD_CATSEYE = 362,

        ICON_TOOL_CROWBAR = 738,

        ICON_HIGHWAY_POINTER = 363,

        ICON_SANDSTONE_PILE = 1449,

        ICON_SANDSTONE_BRICK = 1450,

        ICON_ROUNDED_BRICK = 1451,

        ICON_SLATE_BRICK = 1452,

        ICON_SANDSTONE_SLAB = 1453,

        ICON_ALMANAC = 1454,

        ICON_ALMANAC_FOLDER = 1455,

        ICON_FRAGMENT_UNIDENTIFIED = 1460,

        ICON_FRAGMENT_MARBLE = 1461,

        ICON_FRAGMENT_STONE = 1462,

        ICON_FRAGMENT_SANDSTONE = 1463,

        ICON_FRAGMENT_SLATE = 1464,

        ICON_FRAGMENT_POTTERY = 1465,

        ICON_FRAGMENT_WOOD = 1466,

        ICON_FRAGMENT_IRON = 1467,

        ICON_FRAGMENT_GOLD = 1468,

        ICON_FRAGMENT_SILVER = 1469,

        ICON_FRAGMENT_COPPER = 1470,

        ICON_FRAGMENT_BRASS = 1471,

        ICON_FRAGMENT_ZINC = 1472,

        ICON_FRAGMENT_LEAD = 1473,

        ICON_FRAGMENT_TIN = 1474,

        ICON_CONTAINER_NET_KEEP = 343,

        ICON_CONTAINER_NET_FISH = 885,

        ICON_TOOL_FISHING_ROD = 846,

        ICON_TOOL_FISHING_ROD_WITH_REEL = 866,

        ICON_TOOL_FISHING_ROD_WITH_REEL_AND_LINE = 886,

        ICON_TOOL_ISLET = 1488,

        ICON_FLOAT_FEATHER = 1489,

        ICON_FLOAT_TWIG = 1490,

        ICON_FLOAT_BARK = 1491,

        ICON_TOOL_HOOK_BONE = 865,

        ICON_BAIT_FLY = 1480,

        ICON_FLOAT_MOSS = 1500,

        ICON_BAIT_CHEESE = 1481,

        ICON_BAIT_DOUGH = 1482,

        ICON_BAIT_WURM = 1483,

        ICON_BAIT_FISH = 1484,

        ICON_BAIT_GRUB = 1485,

        ICON_BAIT_WHEAT = 1486,

        ICON_BAIT_CORN = 1487,

        ICON_REEL = 1494,

        ICON_FISHING_REEL = 1495,

        ICON_FINE_FISHING_REEL = 1496,

        ICON_WATER_FISHING_REEL = 1497,

        ICON_SEA_FISHING_REEL = 1498,

        ICON_DEAD_CLAM = 1499,

        ICON_WOOD_FISHING_ROD_RACK = 60,

        ICON_TOOL_FISHING_ROD_OLD = 806,

        ICON_TOOL_FISHING_FINE_OLD = 786,

        ICON_JOURNAL = 1456,

        ICON_BOOK = 1457,

        ICON_TOKEN = 471,

        ICON_CAGE_EMPTY = 363,

        ICON_CAGE_FULL = 364,

        ICON_CHICKEN_COOP = 403,

        ICON_CREATURE_HEN = 404,

        ICON_EMPTY_SLOT_PARENT = 279,

        ICON_TACKLEBOX_COMPARTMENT = 244,

        ICON_WOOD_FISH_TROPHY = 626,

        ICON_LIGHT_BUOY = 245,

        ICON_DECO_NECKLACE_PEARL = 268,

        ICON_DECO_GEM_PEARL = 563,
    }
}