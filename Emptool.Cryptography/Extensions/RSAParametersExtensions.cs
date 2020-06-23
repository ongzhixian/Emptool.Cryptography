using System;
using System.Collections.Generic;
using System.Text;

namespace Emptool.Cryptography
{
    public static class RSAParametersExtensions
    {
        public static void ToConsole(this System.Security.Cryptography.RSAParameters rsaParameters)
        {
            if (rsaParameters.D.Length > 0)
                Console.WriteLine("D        = [{0}]", Convert.ToBase64String(rsaParameters.D));         // d, the private exponent      // privateExponent

            if (rsaParameters.DP.Length > 0)
                Console.WriteLine("DP       = [{0}]", Convert.ToBase64String(rsaParameters.DP));        // d mod (p - 1)                // exponent1

            if (rsaParameters.DQ.Length > 0)
                Console.WriteLine("DQ       = [{0}]", Convert.ToBase64String(rsaParameters.DQ));        // d mod (q - 1)                // exponent2

            if (rsaParameters.Exponent.Length > 0)
                Console.WriteLine("Exponent = [{0}]", Convert.ToBase64String(rsaParameters.Exponent));  // e, the public exponent       // publicExponent

            if (rsaParameters.InverseQ.Length > 0)
                Console.WriteLine("InverseQ = [{0}]", Convert.ToBase64String(rsaParameters.InverseQ));  // (InverseQ)(q) = 1 mod p      // coefficient

            if (rsaParameters.Modulus.Length > 0)
                Console.WriteLine("Modulus  = [{0}]", Convert.ToBase64String(rsaParameters.Modulus));   // n                            // modulus

            if (rsaParameters.P.Length > 0)
                Console.WriteLine("P        = [{0}]", Convert.ToBase64String(rsaParameters.P));         // p                            // prime1

            if (rsaParameters.Q.Length > 0)
                Console.WriteLine("Q        = [{0}]", Convert.ToBase64String(rsaParameters.Q));         // q                            // prime2


            //Console.WriteLine("D        = [{0}]", Convert.ToBase64String(rsaParameters.D));         // d, the private exponent      // privateExponent
            //Console.WriteLine("DP       = [{0}]", Convert.ToBase64String(rsaParameters.DP));        // d mod (p - 1)                // exponent1
            //Console.WriteLine("DQ       = [{0}]", Convert.ToBase64String(rsaParameters.DQ));        // d mod (q - 1)                // exponent2
            //Console.WriteLine("Exponent = [{0}]", Convert.ToBase64String(rsaParameters.Exponent));  // e, the public exponent       // publicExponent
            //Console.WriteLine("InverseQ = [{0}]", Convert.ToBase64String(rsaParameters.InverseQ));  // (InverseQ)(q) = 1 mod p      // coefficient
            //Console.WriteLine("Modulus  = [{0}]", Convert.ToBase64String(rsaParameters.Modulus));   // n                            // modulus
            //Console.WriteLine("P        = [{0}]", Convert.ToBase64String(rsaParameters.P));         // p                            // prime1
            //Console.WriteLine("Q        = [{0}]", Convert.ToBase64String(rsaParameters.Q));         // q                            // prime2

        }
    }
}
