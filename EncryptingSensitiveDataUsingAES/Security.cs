using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptingSensitiveDataUsingAES
{
    public static class Security
    {
        public static string EncryptAES(string data, string encryptionKey)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aesAlg.GenerateIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                byte[] encryptedData;

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                        encryptedData = msEncrypt.ToArray();
                    }
                }

                byte[] ivPlusEncryptedData = new byte[aesAlg.IV.Length + encryptedData.Length];
                aesAlg.IV.CopyTo(ivPlusEncryptedData, 0);
                encryptedData.CopyTo(ivPlusEncryptedData, aesAlg.IV.Length);

                return Convert.ToBase64String(ivPlusEncryptedData);
            }
        }

       public static string DecryptAES(string encryptedData, string encryptionKey)
        {
            byte[] ivPlusEncryptedData = Convert.FromBase64String(encryptedData);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                byte[] iv = new byte[aesAlg.IV.Length];
                byte[] encryptedBytes = new byte[ivPlusEncryptedData.Length - iv.Length];
                Buffer.BlockCopy(ivPlusEncryptedData, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(ivPlusEncryptedData, iv.Length, encryptedBytes, 0, encryptedBytes.Length);

                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new System.IO.MemoryStream(encryptedBytes))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
