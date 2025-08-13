using System;
using System.Buffers.Binary;
using System.IO;
using System.Text;

namespace WOEmu6.Core.Network
{
    public class PacketWriter
    {
        private readonly MemoryStream stream;
        private readonly BinaryWriter writer;
        
        public PacketWriter()
        {
            stream = new MemoryStream();
            writer = new BinaryWriter(stream);
        }

        public void WriteByte(sbyte b) => writer.Write(b);
           
        public void WriteByte(byte p) => writer.Write(p);

        public void WriteBoolean(bool b) => writer.Write((byte)(b ? 1 : 0));

        public void WriteInt(int p) => writer.Write(BinaryPrimitives.ReverseEndianness(p));

        public void WriteLong(long p) => writer.Write(BinaryPrimitives.ReverseEndianness(p));

        public void WriteFloat(float p)
        {
            byte[] _f = BitConverter.GetBytes(p);
            Array.Reverse(_f);
            writer.Write(_f);
        }

        public void WriteShort(short p) => writer.Write(BinaryPrimitives.ReverseEndianness(p));

        public void WriteShort(ushort p) => writer.Write(BinaryPrimitives.ReverseEndianness(p));

        public void WriteBytes(byte[] p)
        {
            writer.Write(p);
        }

        public void WriteBytePrefixedString(string str)
        {
            if (str == null)
            {
                WriteByte(0);
                return;
            }
            
            if (str.Length > 255)
                throw new ArgumentOutOfRangeException(nameof(str), "String can not be longer than 255 characters.");
            WriteByte((byte)str.Length);
            WriteBytes(Encoding.UTF8.GetBytes(str));
        }

        public void WriteShortPrefixedString(string str)
        {
            WriteShort((short)str.Length);
            WriteBytes(Encoding.UTF8.GetBytes(str));
        }

        public byte[] Finish()
        {
            var bytes = stream.ToArray();
            writer.Close();
            stream.Dispose();

            var encapsulated = new byte[bytes.Length + 2];
            byte[] length = BitConverter.GetBytes((short)bytes.Length);
            encapsulated[0] = length[1];
            encapsulated[1] = length[0];
            Array.Copy(bytes, 0, encapsulated, 2, bytes.Length);
            
            return encapsulated;
        }
    }
}