namespace WOEmu6.Core.Objects
{
    public class Color
    {
        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(float r, float g, float b)
        {
            R = (byte)(255 * r);
            G = (byte)(255 * g);
            B = (byte)(255 * b);
        }
        
        public byte R { get; }
        
        public byte G { get; }
        
        public byte B { get; }

        public static Color White = new Color(0xFF, 0xFF, 0xFF);
        public static Color Red = new Color(0xFF, 0x00, 0x00);
        public static Color Black = new Color(0x00, 0x00, 0x00);
    }
}
