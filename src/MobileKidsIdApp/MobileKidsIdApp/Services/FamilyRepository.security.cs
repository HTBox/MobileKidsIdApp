using System.IO;
using System.Security.Cryptography;

namespace MobileKidsIdApp.Services
{
    public partial class FamilyRepository
    {
        private readonly byte[] IV = new byte[] { 150, 217, 86, 61, 124, 221, 187, 117, 60, 221, 80, 122, 155, 171, 239, 110 };

        private byte[] Key => new Rfc2898DeriveBytes(Settings.Identity, new byte[] { 0x84, 0x62, 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14 }).GetBytes(16);

        private byte[] Encrypt(string data)
        {
            byte[] encryptedData;

            using (var aesAlg = AesManaged.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using var msEncrypt = new MemoryStream();
                using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(data);
                }
                encryptedData = msEncrypt.ToArray();
            }

            return encryptedData ?? new byte[0];
        }

        private string Decrypt(byte[] data)
        {
            string decryptedData = null;

            using (var aesAlg = AesManaged.Create())
            {
                aesAlg.Padding = PaddingMode.None;
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using var msDecrypt = new MemoryStream(data);
                using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                decryptedData = srDecrypt.ReadToEnd();
            }

            return decryptedData;
        }
    }
}
