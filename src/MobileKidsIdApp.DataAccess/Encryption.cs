using PCLCrypto;
using System;
using System.Text;

namespace MobileKidsIdApp.DataAccess
{
    public static class Encryption
    {
        private static byte[] _iv = new byte[] { 150, 217, 86, 61, 124, 221, 187, 117, 60, 221, 80, 122, 155, 171, 239, 110 };

        /// <summary>
        /// Accepts plaintext key and plaintext data
        /// and returns a Base64 encoded encrpyted blob.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encrypt(string key, string data)
        {
            var keyBytes = CreateDerivedKey(key, _iv);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var cipherText = Encrypt(keyBytes, dataBytes);
            return Convert.ToBase64String(cipherText);

        }

        public static byte[] CreateDerivedKey(string password, byte[] salt, int keyLengthInBytes = 32, int iterations = 1000)
        {
            byte[] key = NetFxCrypto.DeriveBytes.GetBytes(password, salt, iterations, keyLengthInBytes);
            return key;
        }

        public static byte[] Encrypt(byte[] keyMaterial, byte[] data)
        {
            var provider = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesEcbPkcs7);
            var key = provider.CreateSymmetricKey(keyMaterial);
            byte[] cipherText = WinRTCrypto.CryptographicEngine.Encrypt(key, data);
            return cipherText;
        }

        /// <summary>
        /// Accepts a plaintext key and Base64 encoded
        /// data blob and returns decrypted plaintext.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decrypt(string key, string data)
        {
            var keyBytes = CreateDerivedKey(key, _iv);
            var dataBytes = Convert.FromBase64String(data);
            var cipherText = Decrypt(keyBytes, dataBytes);
            return Encoding.UTF8.GetString(cipherText, 0, cipherText.Length);
        }

        public static byte[] Decrypt(byte[] keyMaterial, byte[] cipherText)
        {
            var provider = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesEcbPkcs7);
            var key = provider.CreateSymmetricKey(keyMaterial);
            byte[] plainText = WinRTCrypto.CryptographicEngine.Decrypt(key, cipherText);
            return plainText;
        }
    }
}
