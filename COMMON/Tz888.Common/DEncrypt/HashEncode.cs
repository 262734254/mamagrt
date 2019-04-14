using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Tz888.Common.DEncrypt
{
    public class HashEncode
    {
        public static string GetRandomValue()
        {
            return new Random().Next(1, 0x7fffffff).ToString();
        }

        public static string GetSecurity()
        {
            return HashEncode.HashEncoding(HashEncode.GetRandomValue());
        }

        public static string HashEncoding(string Security)
        {
            byte[] buffer2 = new UnicodeEncoding().GetBytes(Security);
            byte[] buffer1 = new SHA512Managed().ComputeHash(buffer2);
            Security = "";
            foreach (byte num1 in buffer1)
            {
                Security = Security + ((int)num1) + "O";
            }
            return Security;
        }
    }
}
