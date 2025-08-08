using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;

namespace WO.Core
{
    public class PacketWriter
    {
        public PacketWriter()
        {
            stream = new MemoryStream();
            writer = new BinaryWriter(stream);
        }

        public void PushSByte(sbyte b)
        {
            writer.Write(b);
        }

        public void Dispose()
        {
            stream.Close();
            writer.Close();
        }
           
        public void PushByte(byte p)
        {
            writer.Write(p);
        }

        public void PushInt(int p)
        {
            writer.Write(IPAddress.HostToNetworkOrder(p));
        }

        public void PushLong(long p)
        {
            writer.Write(IPAddress.HostToNetworkOrder(p));
        }

        public void PushFloat(float p)
        {
            byte[] _f = BitConverter.GetBytes(p);
            Array.Reverse(_f);
            writer.Write(_f);
        }

        public void PushShort(short p)
        {
            writer.Write(IPAddress.HostToNetworkOrder(p));
        }

        public void PushBytes(byte[] p)
        {
            writer.Write(p);
        }

        public void WriteBytePrefixedString(string str)
        {
            PushByte((byte)str.Length);
            PushBytes(Encoding.UTF8.GetBytes(str));
        }

        public void WriteShortPrefixedString(string str)
        {
            PushShort((short)str.Length);
            PushBytes(Encoding.UTF8.GetBytes(str));
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

        private MemoryStream stream;
        private BinaryWriter writer;
    }
}