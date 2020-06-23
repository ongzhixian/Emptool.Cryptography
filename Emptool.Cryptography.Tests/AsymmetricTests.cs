using Emptool.Cryptography;
//using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
//using System.Security.Cryptography;
using static Emptool.Cryptography.CryptographyFactory;
//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Text;

namespace Tests
{
    public class AsymmetricTests
    {

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "RSA Test Hello world (bytes) no Key",
            TestOf = typeof(CryptographyFactory))]
        public void RsaEncryptBytesNoKey()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] inputDataBytes = System.Text.Encoding.UTF8.GetBytes("Hello world");
            System.Security.Cryptography.RSAParameters rsaParameters;
            byte[] cipherBytes = f.Encrypt(inputDataBytes, out rsaParameters);

            string resultBase64 = Convert.ToBase64String(cipherBytes);
            Console.WriteLine("Result = [{0}]", resultBase64);
            Console.WriteLine("Params [{0}]", rsaParameters);
            //PrintRsaParameters(rsaParameters);
            rsaParameters.ToConsole();

            // Assert
            Assert.NotNull(resultBase64);
        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "RSA Test Hello world (bytes) no Key",
            TestOf = typeof(CryptographyFactory))]
        public void RsaEncryptBytesWithKey()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] inputDataBytes = System.Text.Encoding.UTF8.GetBytes("Hello world");
            System.Security.Cryptography.RSAParameters rsaParameters = new System.Security.Cryptography.RSAParameters
            {
                Exponent = Convert.FromBase64String("AQAB"),
                Modulus = Convert.FromBase64String("31BWO1MiwU4cOteyYVbMnfjLa3dqRkpY26LSfqp6gkUBSyW+CBoSKUK/1XmlkiHLhYyjo38dd/zWH4sP6+fiaXfQFsV7dhzyvS023I6hixg6PFl5wy1qkRXp6IVjRfbrd29ebCuHe6AFz3aOiahtmKPKUBwoPvk5Ak7hgxPIEs0=")
            };
            byte[] hashBytes = f.Encrypt(inputDataBytes, rsaParameters);

            string resultBase64 = Convert.ToBase64String(hashBytes);
            Console.WriteLine("Result = [{0}]", resultBase64);

            // Assert
            Assert.NotNull(resultBase64);
        }


        [Test(
            Author = "ONG ZHI XIAN",
            Description = "RSA Test Hello world (bytes) no Key",
            TestOf = typeof(CryptographyFactory))]
        public void RsaDecryptBytesWithKey()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] inputDataBytes = Convert.FromBase64String("uZj8Rm8xW0ISZICUKeQnvNGTMaG81zyhMG8f8DmThs4uTegvWYI0q6JPg1jj0Y+IsQSZHkv/XGLNUJSKrrwnkQYuS90a3OkCoqFiLw8HQnni07bp9TkzDIRQWN+RkZC+7yhIHpQvdQZYl6CSjs3/LaD+LIXHObyXvjMwXLl803I=");
            System.Security.Cryptography.RSAParameters rsaParameters = new System.Security.Cryptography.RSAParameters
            {
                D = Convert.FromBase64String("fJY0+ECA7KN+RYl0qNsN/mwW2mVndFUTgXZ+CIfGleayMq2R5Y5TzngExcwHaYv9m99s6n9M9c+aDP33RB542z4q2OFgrucbeTKAwRhJlbOYNuLGDuCPmcejPy51JNginjkOtw31+Pn7QinMpgwNG+5n7aQrQwTi2jLI5KUoEpU="),
                DP = Convert.FromBase64String("EJGDjg0DYMTwU8EGNztrqOriZWFvHKidBZj6C0PUo6nx54DzBG9TdNaGj+o0zkUA6cXzf4x1jHYqV+yzG5Njmw=="),
                DQ = Convert.FromBase64String("GiRgLL/RiYS793OD5u/rcw6mYUXIw5bW42krYR2gV7JVrVOi2r7nHNV65StGwmfhwPNnDqwHDefVVFXSxu+O6Q=="),

                Exponent = Convert.FromBase64String("AQAB"),
                InverseQ = Convert.FromBase64String("N/6gNxkobfLf5MaqWwX9Y7hu4UT+urVWC6CASgYwmqsTxBZGGsizVZ3ocq1A814Lo9S+REgKYFYdqh6agXEYOQ=="),
                Modulus = Convert.FromBase64String("wmkOrKR16oKeDz+9mUqCUOw9jdwDDusrzHH7CEtuWt2XmC6Yu5fG+fh5QquLLF1aC9fyKbr126NsJ2zPbSkejI7grUghDC71D25PCz8sY3bpbMhzXDr8XxM4WSvg3edsSsOhvYzkRa+yZkhWxiaQ+Z0Vb0tTYNyRPi34YLmQZCU="),

                P = Convert.FromBase64String("zvIZ1lx6Qa++2cQVrNguqNbWMziSRrtWUcWISBrtYuzm8aYOm10JbKdq0oRBZspwDyrAyvajGbLBmi2FvwlHZw=="),
                Q = Convert.FromBase64String("8H5JWPl4W6THX5Fw7HHta7x+fOpeV6q1MU4Bzpb6ld9rphD3v6r5F06dojdWTdujv8o94ezx1tm84TWVOpX8kw==")

            };
            byte[] plainTextBytes = f.Decrypt(inputDataBytes, rsaParameters);

            string resultBase64 = System.Text.Encoding.UTF8.GetString(plainTextBytes);
            Console.WriteLine("Result = [{0}]", resultBase64);

            // Assert
            Assert.AreEqual("Hello world", resultBase64);
        }


        //private void PrintRsaParameters(System.Security.Cryptography.RSAParameters rsaParameters)
        //{
        //                                                                                                                            // PKCS #1 field
        //    Console.WriteLine("D        = [{0}]", Convert.ToBase64String(rsaParameters.D));         // d, the private exponent      // privateExponent
        //    Console.WriteLine("DP       = [{0}]", Convert.ToBase64String(rsaParameters.DP));        // d mod (p - 1)                // exponent1
        //    Console.WriteLine("DQ       = [{0}]", Convert.ToBase64String(rsaParameters.DQ));        // d mod (q - 1)                // exponent2

        //    Console.WriteLine("Exponent = [{0}]", Convert.ToBase64String(rsaParameters.Exponent));  // e, the public exponent       // publicExponent
        //    Console.WriteLine("InverseQ = [{0}]", Convert.ToBase64String(rsaParameters.InverseQ));  // (InverseQ)(q) = 1 mod p      // coefficient
        //    Console.WriteLine("Modulus  = [{0}]", Convert.ToBase64String(rsaParameters.Modulus));   // n                            // modulus

        //    Console.WriteLine("P        = [{0}]", Convert.ToBase64String(rsaParameters.P));         // p                            // prime1
        //    Console.WriteLine("Q        = [{0}]", Convert.ToBase64String(rsaParameters.Q));         // q                            // prime2

        //}


    }
}