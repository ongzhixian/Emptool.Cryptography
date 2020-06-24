using System;
using System.Collections.Generic;
using System.Text;

// ZX:  Developing it under Emptool.Cryptography for now
//      To migrate it to Emptool
namespace Emptool.Cryptography
{
    public static class ByteArrayExtensions
    {
        public static string ToBase64String(this byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }
    }
}
