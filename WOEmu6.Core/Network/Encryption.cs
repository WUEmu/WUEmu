using WO.Core.Encryption;

namespace WOEmu6.Core.Network
{
    public class Encryption
    {
        private WORandom encryptRandom, decryptRandom;
        private int e, f, g, remainingDecryptBytes, decryptByte, decryptAddByte;
        
        public Encryption()
        {
            encryptRandom = new WORandom(0x64DF913L);
            decryptRandom = new WORandom(0x64DF913L);
        }
        
        public void Encrypt(byte[] Data, int k, int l)
        {
            for (; k < l; k++)
            {
                if (--e < 0)
                {
                    e = encryptRandom.nextInt(100) + 1;
                    f = (byte)encryptRandom.nextInt(254);
                    g = (byte)encryptRandom.nextInt(254);
                }
                Data[k] = (byte)(Data[k] - g);
                Data[k] ^= (byte)f;
            }
        }

        public void Decrypt(byte[] Data)
        {
            for (int x = 0; x < Data.Length; x++)
            {
                if (--remainingDecryptBytes < 0)
                {
                    remainingDecryptBytes = decryptRandom.nextInt(100) + 1;
                    decryptByte = (byte)decryptRandom.nextInt(254);
                    decryptAddByte = (byte)decryptRandom.nextInt(254);
                }
                Data[x] ^= (byte)decryptByte;
                Data[x] = (byte)(Data[x] + decryptAddByte);
            }
        }
    }
}