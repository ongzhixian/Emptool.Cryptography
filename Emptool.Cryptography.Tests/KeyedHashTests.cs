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
    public class KeyedHashTests
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
            Description = "HMACSHA256 Test Hello world (bytes) no Key",
            TestOf = typeof(CryptographyFactory))]
        public void HMACSHA256TestBytesNoKey()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] inputDataBytes = System.Text.Encoding.UTF8.GetBytes("Hello world");
            byte[] keyBytes;
            byte[] hashBytes = f.Hash(inputDataBytes, out keyBytes);

            string keyBase64 = Convert.ToBase64String(keyBytes);
            string resultBase64 = Convert.ToBase64String(hashBytes);
            Console.WriteLine("Key    = [{0}]", keyBase64);
            Console.WriteLine("Result = [{0}]", resultBase64);

            // Assert
            Assert.NotNull(keyBase64);
            Assert.NotNull(resultBase64);
        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "HMACSHA256 Test Hello world (string) no Key",
            TestOf = typeof(CryptographyFactory))]
        public void HMACSHA256TestStringNoKey()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] keyBytes;
            byte[] hashBytes = f.Hash("Hello world", out keyBytes);

            string keyBase64 = Convert.ToBase64String(keyBytes);
            string resultBase64 = Convert.ToBase64String(hashBytes);
            Console.WriteLine("Key    = [{0}]", keyBase64);
            Console.WriteLine("Result = [{0}]", resultBase64);

            // Assert
            Assert.NotNull(keyBase64);
            Assert.NotNull(resultBase64);
        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "HMACSHA256 Test Hello world (bytes)",
            TestOf = typeof(CryptographyFactory))]
        public void HMACSHA256TestBytesWithKey()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] inputDataBytes = System.Text.Encoding.UTF8.GetBytes("Hello world");
            byte[] keyBytes = Convert.FromBase64String("1VjUDZCtOU+sKnGTziG3E4HTlkPOdBMkjtWM1wkQaiA6qS3NkYLAS6swIDTPJYRjZfH0hi2MBWYMU/m+uw3evA==");
            byte[] hashBytes = f.Hash(inputDataBytes, keyBytes);

            string keyBase64 = Convert.ToBase64String(keyBytes);
            string resultBase64 = Convert.ToBase64String(hashBytes);
            Console.WriteLine("Key    = [{0}]", keyBase64);
            Console.WriteLine("Result = [{0}]", resultBase64);

            // Assert
            Assert.AreEqual("gJN9jxH8dPy4x9gezzE+OqkdyLIqMShC9tkw8oKqXcc=", resultBase64);
        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "HMACSHA256 Test Hello world (string)",
            TestOf = typeof(CryptographyFactory))]
        public void HMACSHA256TestStringWithKey()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] keyBytes = Convert.FromBase64String("1VjUDZCtOU+sKnGTziG3E4HTlkPOdBMkjtWM1wkQaiA6qS3NkYLAS6swIDTPJYRjZfH0hi2MBWYMU/m+uw3evA==");
            byte[] hashBytes = f.Hash("Hello world", keyBytes);

            string keyBase64 = Convert.ToBase64String(keyBytes);
            string resultBase64 = Convert.ToBase64String(hashBytes);
            Console.WriteLine("Key    = [{0}]", keyBase64);
            Console.WriteLine("Result = [{0}]", resultBase64);

            // Assert
            Assert.AreEqual("gJN9jxH8dPy4x9gezzE+OqkdyLIqMShC9tkw8oKqXcc=", resultBase64);
        }


        [Test(
            Author = "ONG ZHI XIAN",
            Description = "HMACSHA512 Test Hello world (bytes) no Key",
            TestOf = typeof(CryptographyFactory))]
        public void HMACSHA512TestBytesNoKey()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] inputDataBytes = System.Text.Encoding.UTF8.GetBytes("Hello world");
            byte[] keyBytes;
            byte[] hashBytes = f.Hash(KeyedHashAlgorithmName.HMACSHA512, inputDataBytes, out keyBytes);

            string keyBase64 = Convert.ToBase64String(keyBytes);
            string resultBase64 = Convert.ToBase64String(hashBytes);
            Console.WriteLine("Key    = [{0}]", keyBase64);
            Console.WriteLine("Result = [{0}]", resultBase64);

            // Assert
            Assert.NotNull(keyBase64);
            Assert.NotNull(resultBase64);
        }

        [Test(
            Author = "ONG ZHI XIAN",
            Description = "HMACSHA512 Test Hello world (bytes) no Key",
            TestOf = typeof(CryptographyFactory))]
        public void HMACSHA512TestBytesWithKey()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();

            // Act
            byte[] inputDataBytes = System.Text.Encoding.UTF8.GetBytes("Hello world");
            byte[] keyBytes = Convert.FromBase64String("otkYmuRbaC/sRM7NHTXkN+6ntZTRosrF7t1bQNYQjCM5tor4I9qZMUXOQXZP/+bE/Wjw7t4xAKhEw73SWjqeVVFLfOwpB1ssqWRWDJbGed0mu49XK3Gd/E/luZnmF0KvE/NP103Frdqt9oH2GM1SqvNIIZLm20IytkOEEqX/660=");
            byte[] hashBytes = f.Hash(KeyedHashAlgorithmName.HMACSHA512, inputDataBytes, keyBytes);

            //string keyBase64 = Convert.ToBase64String(keyBytes);
            string resultBase64 = Convert.ToBase64String(hashBytes);
            Console.WriteLine("Result = [{0}]", resultBase64);

            // Assert
            Assert.AreEqual("Ywri+XnoJCV75fBvHEGkMa0OJR8ZoiphQJygP8T7e9r8nLmVVFNkt0ppD+OcMaEDeAiiktCfj2ixRNQByScr6w==", resultBase64);
        }
    }
}