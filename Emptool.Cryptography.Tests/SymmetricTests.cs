using Emptool.Cryptography;
//using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using static Emptool.Cryptography.CryptographyFactory;
//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Text;

namespace Tests
{
    public class SymmetricTests
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
            Description = "AES Test Hello world (bytes) with no Key and IV",
            TestOf = typeof(CryptographyFactory))]
        public void AESEncryptStringNoKeyIV()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] keyBytes;
            byte[] ivBytes;
            byte[] hashBytes = f.Encrypt("Hello world", out keyBytes, out ivBytes);

            string keyBytes64 = Convert.ToBase64String(keyBytes);
            string ivBytes64 = Convert.ToBase64String(ivBytes);
            string hashBytes64 = Convert.ToBase64String(hashBytes);

            //Console.WriteLine("KeyBytes[{0}]", keyBytes64);
            //Console.WriteLine("IVBytes[{0}]", ivBytes64);
            //Console.WriteLine("HashBytes[{0}]", hashBytes64);


            //Assert.Fail();
            // Assert
            //Assert.AreEqual("ZOyIygCyaOW6GjVnihtTFtIS9PNmskdyMlNKiuyjfzw=", result);
            Assert.NotZero(keyBytes64.Length);
            Assert.NotZero(ivBytes64.Length);
            Assert.NotZero(hashBytes64.Length);
        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "AES Test Hello world (bytes) with no Key and IV (string)",
            TestOf = typeof(CryptographyFactory))]
        public void AESEncryptStringNoKeyIVAsString()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            string keyBase64;
            string ivBase64;
            byte[] hashBytes = f.Encrypt("Hello world", out keyBase64, out ivBase64);
            string hashBytes64 = Convert.ToBase64String(hashBytes);

            // Assert
            Assert.NotZero(keyBase64.Length);
            Assert.NotZero(ivBase64.Length);
            Assert.NotZero(hashBytes64.Length);
        }


        [Test(
            Author = "ONG ZHI XIAN",
            Description = "AES Test Hello world (bytes) with Key and IV",
            TestOf = typeof(CryptographyFactory))]
        public void AESEncryptStringWithKeyIV()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] keyBytes = Convert.FromBase64String("yfNvMXVJMJXhbgIKtjroQkrYhfXpyjhK0TP5xYdJVPk=");
            byte[] ivBytes = Convert.FromBase64String("7/T4oOkXvkoORPFLAPg13w==");
            byte[] hashBytes = f.Encrypt("Hello world", keyBytes, ivBytes);
            string hashBytes64 = Convert.ToBase64String(hashBytes);

            // Assert
            Assert.AreEqual("dnd6ee2g5NlUFTErWNVGng==", hashBytes64);
        }


        [Test(
            Author = "ONG ZHI XIAN",
            Description = "AES Test Hello world (bytes) with Key and IV",
            TestOf = typeof(CryptographyFactory))]
        public void AESDecryptBytesWithKeyIV()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] keyBytes = Convert.FromBase64String("yfNvMXVJMJXhbgIKtjroQkrYhfXpyjhK0TP5xYdJVPk=");
            byte[] ivBytes = Convert.FromBase64String("7/T4oOkXvkoORPFLAPg13w==");
            byte[] cipherBytes = Convert.FromBase64String("dnd6ee2g5NlUFTErWNVGng==");

            //byte[] hashBytes = f.Decrypt(cipherBytes, keyBytes, ivBytes);
            //string result = System.Text.Encoding.UTF8.GetString(hashBytes);
            string result = f.Decrypt(cipherBytes, keyBytes, ivBytes); ;

            // Assert
            Assert.AreEqual("Hello world", result);
        }


        //[Test(
        //    Author = "ONG ZHI XIAN",
        //    Description = "AES Test Hello world (string)",
        //    TestOf = typeof(CryptographyFactory))]
        //public void AESTestString()
        //{
        //    // Arrange
        //    CryptographyFactory f = new CryptographyFactory();

        //    // Act
        //    byte[] hashBytes = f.Hash("Hello world");
        //    string result = System.Convert.ToBase64String(hashBytes);
        //    //System.Console.WriteLine(base64Result);

        //    // Assert
        //    Assert.AreEqual("ZOyIygCyaOW6GjVnihtTFtIS9PNmskdyMlNKiuyjfzw=", result);

        //}


    }
}