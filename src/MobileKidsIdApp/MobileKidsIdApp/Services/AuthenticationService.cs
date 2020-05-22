using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MobileKidsIdApp.Services
{
    public class AuthenticationService
    {
        private readonly string KeychainHash = "mobilekidsapp";

        public async Task SetAppPassword(string password)
        {
            string hashedString = CreateHash(password);

            await SecureStorage.SetAsync(KeychainHash, hashedString);
        }

        public async Task<bool> VerifyAppPassword(string password)
        {
            string storedHash = await SecureStorage.GetAsync(KeychainHash);
            string hashToVerify = CreateHash(password);

            return StringComparer.OrdinalIgnoreCase.Compare(hashToVerify, storedHash) == 0;
        }

        private string CreateHash(string password)
        {
            byte[] stringData = Encoding.UTF8.GetBytes(password);
            var sha = new SHA512Managed();
            byte[] hashedData = sha.ComputeHash(stringData);
            var sBuilder = new StringBuilder();
            for (int i = 0; i < hashedData.Length; i++)
            {
                sBuilder.Append(hashedData[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
