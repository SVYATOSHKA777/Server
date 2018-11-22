using System.Text;
using System.Security.Cryptography;

namespace ServerSide
{
    class EncryptionClass
    {
        private byte[] PrivateKey { get; set; }
        public byte[] PublicKey { get; private set; }
        const int keySize = 1024;
        public string DecriptedMessage { get; private set; }

        public EncryptionClass()
        {
            GenerateKeys();
        }

        void GenerateKeys()
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(keySize))
            {
                PublicKey = RSA.ExportCspBlob(false);
                PrivateKey = RSA.ExportCspBlob(true);
            }
        }

        internal string Decrypt(byte[] Message)
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(keySize))
            {
                RSA.ImportCspBlob(PrivateKey);
                return Encoding.UTF8.GetString(RSA.Decrypt(Message, false));
            }
        }
        internal byte[] Encrypt(string Message)
        {
            byte[] MessageByte = Encoding.UTF8.GetBytes(Message);
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(keySize))
            {
                RSA.ImportCspBlob(PublicKey);
                return RSA.Encrypt(MessageByte, false);
            }
        }
    }
}
