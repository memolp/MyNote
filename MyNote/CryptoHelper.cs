using System;
using System.Security.Cryptography;
using System.Text;

namespace MyNote
{
    public class CryptoHelper
    {
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="base64Input"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Decrypt(string base64Input, string password)
        {
            byte[] key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] encryptedBytes = Convert.FromBase64String(base64Input);
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                var decryptor = aes.CreateDecryptor();
                byte[] decrypted = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                return Encoding.UTF8.GetString(decrypted);
            }
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText, string password)
        {
            byte[] key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                var encryptor = aes.CreateEncryptor();
                byte[] encrypted = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                return Convert.ToBase64String(encrypted);
            }
        }
    }
}
