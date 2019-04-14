using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Tz888.Common.DEncrypt
{
    public class DEncrypt
    {
        public static byte[] Decrypt(byte[] encrypted)
        {
            byte[] buffer1 = Encoding.Default.GetBytes("Tz888.CN");
            return Tz888.Common.DEncrypt.DEncrypt.Decrypt(encrypted, buffer1);
        }

        public static string Decrypt(string original)
        {
            return Tz888.Common.DEncrypt.DEncrypt.Decrypt(original, "Tz888.CN", Encoding.Default);
        }

        public static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            TripleDESCryptoServiceProvider provider1 = new TripleDESCryptoServiceProvider();
            provider1.Key = Tz888.Common.DEncrypt.DEncrypt.MakeMD5(key);
            provider1.Mode = CipherMode.ECB;
            return provider1.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }

        public static string Decrypt(string original, string key)
        {
            return Tz888.Common.DEncrypt.DEncrypt.Decrypt(original, key, Encoding.Default);
        }

        public static string Decrypt(string encrypted, string key, Encoding encoding)
        {
            byte[] buffer1 = Convert.FromBase64String(encrypted);
            byte[] buffer2 = Encoding.Default.GetBytes(key);
            return encoding.GetString(Tz888.Common.DEncrypt.DEncrypt.Decrypt(buffer1, buffer2));
        }

        public static string Encrypt(string original)
        {
            return Tz888.Common.DEncrypt.DEncrypt.Encrypt(original, "Tz888.CN");
        }

        public static byte[] Encrypt(byte[] original)
        {
            byte[] buffer1 = Encoding.Default.GetBytes("Tz888.CN");
            return Tz888.Common.DEncrypt.DEncrypt.Encrypt(original, buffer1);
        }

        public static string Encrypt(string original, string key)
        {
            byte[] buffer1 = Encoding.Default.GetBytes(original);
            byte[] buffer2 = Encoding.Default.GetBytes(key);
            return Convert.ToBase64String(Tz888.Common.DEncrypt.DEncrypt.Encrypt(buffer1, buffer2));
        }

        public static byte[] Encrypt(byte[] original, byte[] key)
        {
            TripleDESCryptoServiceProvider provider1 = new TripleDESCryptoServiceProvider();
            provider1.Key = Tz888.Common.DEncrypt.DEncrypt.MakeMD5(key);
            provider1.Mode = CipherMode.ECB;
            return provider1.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }

        public static byte[] MakeMD5(byte[] original)
        {
            byte[] buffer1 = new MD5CryptoServiceProvider().ComputeHash(original);
            return buffer1;
        }
    }
}
