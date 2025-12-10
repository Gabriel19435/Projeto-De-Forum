using System.Security.Cryptography;

namespace Blog_Projeto.Services.Profile.ProfExtra
{
    public static class PasswordValidation
    {
        public static (byte[] Passwordhash, byte[] PasswordKey) CrypPassword(string Password)
        {
            byte[] PasswordKey = RandomNumberGenerator.GetBytes(16);
            using (var rfc = new Rfc2898DeriveBytes(Password, PasswordKey, 100000, HashAlgorithmName.SHA256))
            {
                byte[] Passwordhash = rfc.GetBytes(32);
                return (Passwordhash, PasswordKey);
            }
        }
        public static bool VerifyPassword(string Password, byte[] Passwordhash, byte[] PasswordKey)
        {
            using (var rfc = new Rfc2898DeriveBytes(Password, PasswordKey, 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = rfc.GetBytes(32);
                return CryptographicOperations.FixedTimeEquals(hash, Passwordhash);
            }
        }
    }
}
