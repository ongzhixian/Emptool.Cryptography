using System;
using System.Collections.Generic;
using System.Text;

// ZX:  Developing it under Emptool.Cryptography for now
//      To migrate it to Emptool
namespace Emptool.Cryptography
{
    public static class StringExtensions
    {
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
    }
}
