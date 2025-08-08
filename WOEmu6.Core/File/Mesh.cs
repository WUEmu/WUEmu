using System;
using System.IO;
using System.Net;
using WO.Core;
using WOEmu6.Core.Objects;
using WOEmu6.Core.Packets.Server;

namespace WOEmu6.Core.File
{
    public class Mesh
    {
        private const long MeshFileMagic = 5136955264682433437L;
        
        private readonly string filename;
        private readonly Stream inputStream;
        private readonly BinaryReader reader;
        
        public long FileSize { get; private set; }
        
        public byte Version { get; private set; }
        
        public int SizeLevel { get; private set; }
        
        public int Size { get; private set; }

        public int[] Data { get; private set; }
        
        public int LinesPerRow { get; private set; }
        
        public int MeshSize { get; private set; } 
        public int MapDimension { get; private set;} 
        
        public Mesh(string path)
        {
            filename = Path.GetFileNameWithoutExtension(path);
            inputStream = System.IO.File.OpenRead(path);
            FileSize = inputStream.Length;
            MapDimension = (int)(Math.Sqrt(FileSize) / 2);
            MeshSize = (int)(Math.Log(MapDimension) / Math.Log(2.0d));
            reader = new BinaryReader(inputStream);
        }

        public void Load()
        {
            Console.Write("Loading mesh file {0}... ", filename);
            
            // Read header
            var header = reader.ReadBytes(1024);
            var headerReader = new PacketReader(header);
            var magic = headerReader.PopLong();
            if (magic != MeshFileMagic)
                throw new Exception("Mesh file magic mismatch!");

            Version = headerReader.ReadByte();
            if (Version == 0)
            {
                SizeLevel = headerReader.ReadByte();
                Size = 1 << SizeLevel;
            }
            
            Data = new int[Size * Size + 1];
            LinesPerRow = Size / 128;

            for (int i = 0; i < Size; i++)
            {
                for (int x = 0; x < Size; x++)
                    Data[(i * Size) + x] = IPAddress.HostToNetworkOrder(reader.ReadInt32());
                // Console.Write(".");
            }
            Console.WriteLine("done!");
        }

        public int GetTile(int x, int y) => Data[x | y << SizeLevel];

        public Tile GetTileValue(int x, int y) => new Tile(GetTile(x, y), x, y);

        public void SetTile(int x, int y, int value) => Data[x | y << SizeLevel] = value;

        public void SetTileValue(int x, int y, Tile value) => SetTile(x, y, value);
    }
}
