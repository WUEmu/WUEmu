using System;
using System.Buffers.Binary;
using System.IO;
using Serilog;
using WO.Core;
using WOEmu6.Core.Objects;

namespace WOEmu6.Core.File
{
    public class FileMesh : IMesh
    {
        private const long MeshFileMagic = 5136955264682433437L;
        
        private readonly string filename;
        private readonly Stream inputStream;
        private readonly BinaryReader reader;
        private byte version;
        private int sizeLevel;
        private int size;
        private int[] data;
        private int linesPerRow;
        
        public FileMesh(string path)
        {
            filename = Path.GetFileNameWithoutExtension(path);
            inputStream = System.IO.File.OpenRead(path);
            var mapDimension = (int)(Math.Sqrt(inputStream.Length) / 2);
            MeshSize = (int)(Math.Log(mapDimension) / Math.Log(2.0d));
            reader = new BinaryReader(inputStream);
            Load();
        }
        
        public int MeshSize { get; }

        public void Load()
        {
            Log.Information("Loading mesh file {fileName}...", filename);
            
            // Read header
            var header = reader.ReadBytes(1024);
            var headerReader = new PacketReader(header);
            var magic = headerReader.PopLong();
            if (magic != MeshFileMagic)
                throw new Exception("Mesh file magic mismatch!");

            version = headerReader.ReadByte();
            if (version == 0)
            {
                sizeLevel = headerReader.ReadByte();
                size = 1 << sizeLevel;
            }
            
            data = new int[size * size + 1];
            linesPerRow = size / 128;

            for (int i = 0; i < size; i++)
            {
                for (int x = 0; x < size; x++)
                    data[(i * size) + x] = BinaryPrimitives.ReverseEndianness(reader.ReadInt32());
            }
        }

        public int GetTile(int x, int y) => data[x | y << sizeLevel];

        public Tile GetTileValue(short x, short y) => new Tile(GetTile(x, y), x, y);

        public void SetTile(int x, int y, int value) => data[x | y << sizeLevel] = value;

        public void SetTile(int x, int y, Tile value) => SetTile(x, y, (int)value);
    }
}
