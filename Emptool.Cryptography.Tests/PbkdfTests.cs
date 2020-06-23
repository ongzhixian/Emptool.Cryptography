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
    public class PbkdfTests
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
            Description = "PBKDF Test Hello world (string) with no salt and iteration",
            TestOf = typeof(CryptographyFactory))]
        public void PbkdfStringNoSaltIteration()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            int iterationCount;
            byte[] saltBytes;
            byte[] resultBytes = f.PasswordBasedKey(10, "Hello world", out saltBytes, out iterationCount);

            string saltBase64 = Convert.ToBase64String(saltBytes);
            string resultBase64 = Convert.ToBase64String(resultBytes);

            //Console.WriteLine("salt  Base64[{0}]", saltBase64);
            //Console.WriteLine("resultBase64[{0}]", resultBase64);
            //Console.WriteLine("iterationCount[{0}]", iterationCount);


            //Assert.Fail();
            // Assert
            //Assert.AreEqual("ZOyIygCyaOW6GjVnihtTFtIS9PNmskdyMlNKiuyjfzw=", result);
            Assert.NotZero(saltBase64.Length);
            Assert.NotZero(resultBase64.Length);
            
        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "PBKDF Test Hello world (string) with no salt and iteration",
            TestOf = typeof(CryptographyFactory))]
        public void PbkdfStringWithSaltIteration()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            int iterationCount = 3050;
            byte[] saltBytes = Convert.FromBase64String("cPpP4ISgNAIuMZGncgwlCHvE0bf0JQdWrZPXoH+g4e8=");
            byte[] resultBytes = f.PasswordBasedKey(10, "Hello world", saltBytes, iterationCount);

            string saltBase64 = Convert.ToBase64String(saltBytes);
            string resultBase64 = Convert.ToBase64String(resultBytes);

            //Console.WriteLine("salt  Base64[{0}]", saltBase64);
            //Console.WriteLine("resultBase64[{0}]", resultBase64);
            //Console.WriteLine("iterationCount[{0}]", iterationCount);


            //Assert.Fail();
            // Assert
            //Assert.AreEqual("ZOyIygCyaOW6GjVnihtTFtIS9PNmskdyMlNKiuyjfzw=", result);
            //Assert.NotZero(saltBase64.Length);
            //Assert.NotZero(resultBase64.Length);
            Assert.AreEqual("sMYk7SkvF9PElA==", resultBase64);

        }



    }
}