using System.Security.Cryptography;

namespace MobileKidsIdApp.Services
{
    public partial class FamilyRepository
    {
        private byte[] Encrypt(byte[] dataToEncrypt)
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsa.ExportParameters(false));
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            return encryptedData ?? new byte[0];
        }

        private byte[] Decrypt(byte[] dataToDecrypt)
        {
            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsa.ExportParameters(true));
                decryptedData = rsa.Decrypt(dataToDecrypt, false);
            }

            return decryptedData ?? new byte[0];
        }
    }
}
