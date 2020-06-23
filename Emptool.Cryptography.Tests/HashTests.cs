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
    public class HashTests
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
            Description = "SHA256 Test Hello world (string)",
            TestOf = typeof(CryptographyFactory))]
        public void SHA256TestString()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] hashBytes = f.Hash("Hello world");
            string result = System.Convert.ToBase64String(hashBytes);
            //System.Console.WriteLine(base64Result);

            // Assert
            Assert.AreEqual("ZOyIygCyaOW6GjVnihtTFtIS9PNmskdyMlNKiuyjfzw=", result);

        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "SHA256 Test Hello world (bytes)",
            TestOf = typeof(CryptographyFactory))]
        public void SHA256TestBytes()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes("Hello world");
            byte[] hashBytes = f.Hash(inputBytes);
            string result = System.Convert.ToBase64String(hashBytes);

            // Assert
            Assert.AreEqual("ZOyIygCyaOW6GjVnihtTFtIS9PNmskdyMlNKiuyjfzw=", result);

        }


        [Test(
            Author = "ONG ZHI XIAN",
            Description = "MD5 Test Hello world (string)",
            TestOf = typeof(CryptographyFactory))]
        public void MD5TestString()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] hashBytes = f.Hash(HashAlgorithmName.MD5, "Hello world");
            string result = System.Convert.ToBase64String(hashBytes);

            // Assert
            Assert.AreEqual("PiWWCnnbxptnTNTsZ6csYg==", result);

        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "MD5 Test Hello world (bytes)",
            TestOf = typeof(CryptographyFactory))]
        public void MD5TestBytes()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes("Hello world");
            byte[] hashBytes = f.Hash(HashAlgorithmName.MD5, inputBytes);
            string result = System.Convert.ToBase64String(hashBytes);

            // Assert
            Assert.AreEqual("PiWWCnnbxptnTNTsZ6csYg==", result);

        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "SHA512 Test Hello world (string)",
            TestOf = typeof(CryptographyFactory))]
        public void SHA512TestString()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] hashBytes = f.Hash(HashAlgorithmName.SHA512, "Hello world");
            string result = System.Convert.ToBase64String(hashBytes);
            //Console.WriteLine(result);

            // Assert
            Assert.AreEqual("t/eDuu2Cl/DbkXRiGE/08I5pwtXl95qUJgD5cl9Yzh8pwYE5v4CwbA//K900c4RS7PQMSIwip+PYDN9vnBwNRw==", result);

        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "SHA512 Test Hello world (bytes)",
            TestOf = typeof(CryptographyFactory))]
        public void SHA512TestBytes()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes("Hello world");
            byte[] hashBytes = f.Hash(HashAlgorithmName.SHA512, inputBytes);
            string result = System.Convert.ToBase64String(hashBytes);

            // Assert
            Assert.AreEqual("t/eDuu2Cl/DbkXRiGE/08I5pwtXl95qUJgD5cl9Yzh8pwYE5v4CwbA//K900c4RS7PQMSIwip+PYDN9vnBwNRw==", result);

        }
    }
}