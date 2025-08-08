namespace WOEmu6.Core.BML
{
    public class BmlForm
    {
        public short Id { get; }
        public string Title { get; }
        public string Contents { get; }
        public short Width { get; }
        public short Height { get; }
        public bool Resizable { get; }
        public float X { get; }
        public float Y { get; }
        public bool Closeable { get; }
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

        public BmlForm(short id, string title, string contents = null, short width = 512, short height = 512, bool resizable = false,
            float x = 0.25f, float y = 0.25f, bool closeable = true, byte r = 0xFF, byte g = 0xFF, byte b = 0xFF)
        {
            Id = id;
            Title = title;
            Contents = contents;
            Width = width;
            Height = height;
            Resizable = resizable;
            X = x;
            Y = y;
            Closeable = closeable;
            R = r;
            G = g;
            B = b;
        }
    }
}