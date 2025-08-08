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
}