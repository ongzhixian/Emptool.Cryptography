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
    public class RSAParametersTests
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
            Description = "RSAParameters Test XML serialization",
            TestOf = typeof(System.Security.Cryptography.RSAParameters))]
        public void RSAParametersXmlSerialization()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();
            System.Security.Cryptography.RSAParameters rsaParameters;
            using (System.Security.Cryptography.RSACryptoServiceProvider csp = new System.Security.Cryptography.RSACryptoServiceProvider())
            {
                rsaParameters = csp.ExportParameters(true);
            }

            // Act
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Security.Cryptography.RSAParameters));
            System.IO.MemoryStream ms;

            using (ms = new System.IO.MemoryStream())
            {
                serializer.Serialize(ms, rsaParameters);
            }

            byte[] serializedBytes = ms.ToArray();
            string xml = System.Text.Encoding.UTF8.GetString(serializedBytes);
            Console.WriteLine(xml);

            // Assert
            Assert.NotZero(serializedBytes.Length);
        
        }


        [Test(
            Author = "ONG ZHI XIAN",
            Description = "RSAParameters Test JSON serialization",
            TestOf = typeof(System.Security.Cryptography.RSAParameters))]
        public void RSAParametersJsonSerialization()
        {
            // Arrange
            CryptographyFactory f = new CryptographyFactory();
            System.Security.Cryptography.RSAParameters rsaParameters;
            using (System.Security.Cryptography.RSACryptoServiceProvider csp = new System.Security.Cryptography.RSACryptoServiceProvider())
            {
                rsaParameters = csp.ExportParameters(true);
            }

            // Act
            System.Text.Json.JsonSerializerOptions opts = new System.Text.Json.JsonSerializerOptions();
            opts.WriteIndented = true;
            string json = System.Text.Json.JsonSerializer.Serialize(rsaParameters.ToDictionary(), opts);
            Console.WriteLine(json);

            // Assert
            Assert.NotNull(json);

        }

    }
}