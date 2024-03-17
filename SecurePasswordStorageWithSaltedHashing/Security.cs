using System;
using System.Security.Cryptography;

namespace SecurePasswordStorageWithSaltedHashing
{
    public static class Security
    {
       public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16]; // 16 bytes for the salt (adjust size as needed)
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static string HashPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 32 bytes for the hash (adjust size as needed)
                byte[] hashWithSalt = new byte[48]; // 32 bytes hash + 16 bytes salt

                // Combine the hash and salt to store it in the database
                Buffer.BlockCopy(hash, 0, hashWithSalt, 0, 32);
                Buffer.BlockCopy(salt, 0, hashWithSalt, 32, 16);

                return Convert.ToBase64String(hashWithSalt);
            }
        }
    }
}
