using System;
using System.Buffers.Binary;
using System.IO;
using System.Net;
using System.Text;

namespace WOEmu6.Core.Network
{
    public class PacketReader
    {
        private readonly BinaryReader reader;
        private readonly MemoryStream stream;
        
        public PacketReader(byte[] inc)
        {
            stream = new MemoryStream(inc);
            reader = new BinaryReader(stream);
        }
        
        public int ReadInt() => BinaryPrimitives.ReverseEndianness(reader.ReadInt32());

        public long ReadLong() => BinaryPrimitives.ReverseEndianness(reader.ReadInt64());

        public byte[] ReadBytes(int size)
        {
            return reader.ReadBytes(size);
        }

        public float ReadFloat()
        {
            byte[] _float = reader.ReadBytes(4);
            Array.Reverse(_float);
            return BitConverter.ToSingle(_float, 0);
        }

        public byte ReadByte() => reader.ReadByte();

        public bool ReadBoolean() => reader.ReadByte() == 1;

        public string ReadBytePrefixedString(Encoding? encoding = null)
        {
            var length = ReadByte();
            return (encoding ?? Encoding.UTF8).GetString(ReadBytes(length));
        }

        public string ReadShortPrefixedString(Encoding? encoding = null)
        {
            var length = ReadShort();
            return (encoding ?? Encoding.UTF8).GetString(ReadBytes(length));
        }

        public short ReadShort()
        {
            return IPAddress.HostToNetworkOrder(reader.ReadInt16());
        }
    }
}
