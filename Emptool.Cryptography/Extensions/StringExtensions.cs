using System;
using System.Text;

// ZX:  Developing it under Emptool.Cryptography for now
//      To migrate it to Emptool
namespace Emptool.Cryptography
{
    public static class StringExtensions
    {
        private static System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create();

        public static byte[] FromBase64String(this string inputString)
        {
            return Convert.FromBase64String(inputString);
        }

        public static byte[] ToUtf8Bytes(this string inputString)
        {
            return Encoding.UTF8.GetBytes(inputString);
        }

        public static byte[] ToBytes(this string inputString)
        {
            return inputString.ToUtf8Bytes();
        }

        public static byte[] SHA1(this string inputString)
        {
            return sha1.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string SHA1Base64String(this string inputString)
        {
            return Convert.ToBase64String(inputString.SHA1());
        }
    }
}
