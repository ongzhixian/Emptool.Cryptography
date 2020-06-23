using System;

namespace Emptool.Cryptography
{
    public class CryptographyFactory
    {
        // data_privacy         aes
        // data_integrity       hmacsha256, hmacsha512
        // digital_signature    rsa
        // key_exchange         rsa
        // Random number generation
        // Generating a key from a password

        System.Security.Cryptography.Aes aes;
        System.Security.Cryptography.RSA rsa;
        System.Security.Cryptography.SHA256 sha256;
        System.Security.Cryptography.SHA512 sha512;
        System.Security.Cryptography.HMACSHA256 hmac256;
        System.Security.Cryptography.HMACSHA512 hmac512;
        System.Security.Cryptography.RNGCryptoServiceProvider rng;
        System.Security.Cryptography.Rfc2898DeriveBytes pbkdf;

        Random rnd = new Random();

        //public dynamic Get(string algName)
        //{

        //    if (!Valid(algName))
        //        return null;

        //    string upperCaseName = algName.ToUpperInvariant();

        //    switch (upperCaseName)
        //    {
        //        case "AES":
        //            return new System.Security.Cryptography.AesCryptoServiceProvider();
        //        case "RSA":
        //            return new System.Security.Cryptography.RSACryptoServiceProvider();
        //        case "SHA256":
        //            return new System.Security.Cryptography.SHA256CryptoServiceProvider();
        //        case "SHA512":
        //            return new System.Security.Cryptography.SHA512CryptoServiceProvider();
        //        case "HMACSHA256":
        //            return new System.Security.Cryptography.HMACSHA256();
        //        case "HMACSHA512":
        //            return new System.Security.Cryptography.HMACSHA512();
        //        case "RNG":
        //            return new System.Security.Cryptography.RNGCryptoServiceProvider();
        //        //case "PBKDF":
        //        //    return new System.Security.Cryptography.Rfc2898DeriveBytes();
        //        default:
        //            return null;
        //    }
        //}





        public enum AlgorithmName
        {
            AES,
            RSA,
            SHA256,
            SHA512,
            HMACSHA256,
            HMACSHA512,
            RNG,
            PBKDF
        }

        private bool Valid(string algName)
        {
            bool result = false;

            string upperCaseName = algName.ToUpperInvariant();

            switch (upperCaseName)
            {
                case "AES":
                case "RSA":
                case "SHA256":
                case "SHA512":
                case "HMACSHA256":
                case "HMACSHA512":
                case "RNG":
                    //case "PBKDF":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }

        //public enum Symmetric
        //{
        //    AES
        //}

        //public void Get(Symmetric alg)
        //{
        //}

        //public enum Asymmetric
        //{
        //    RSA
        //}
        //public void Get(Asymmetric alg)
        //{
        //}

        //public enum Hash
        //{
        //    SHA256,
        //    SHA512
        //}
        //public void Get(Hash alg)
        //{
        //}
        //public enum HMAC
        //{
        //    HMACSHA256,
        //    HMACSHA512
        //}

        //public void Get(HMAC alg)
        //{
        //}

        //public void GetRng()
        //{

        //}

        //public void GetPBKDF()
        //{

        //}


        public byte[] Encrypt(string plainText, byte[] keyBytes, byte[] ivBytes)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (keyBytes == null || keyBytes.Length <= 0)
                throw new ArgumentNullException("Key");
            if (ivBytes == null || ivBytes.Length <= 0)
                throw new ArgumentNullException("IV");

            System.IO.MemoryStream memoryStream;

            using (System.Security.Cryptography.AesCryptoServiceProvider csp = new System.Security.Cryptography.AesCryptoServiceProvider())
            {
                csp.Key = keyBytes;
                csp.IV = ivBytes;
                //csp.CreateEncryptor

                // Create an encryptor to perform the stream transform.
                System.Security.Cryptography.ICryptoTransform cryptoTransformer = csp.CreateEncryptor(csp.Key, csp.IV);

                // Create the streams used for encryption.
                using (memoryStream = new System.IO.MemoryStream())
                using (System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, cryptoTransformer, System.Security.Cryptography.CryptoStreamMode.Write))
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(cryptoStream))
                {
                    sw.AutoFlush = true;
                    sw.Write(plainText);
                }
            }

            return memoryStream.ToArray();
        }

        public byte[] Encrypt(string plainText, out byte[] keyBytes, out byte[] ivBytes)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");

            System.IO.MemoryStream memoryStream;

            using (System.Security.Cryptography.AesCryptoServiceProvider csp = new System.Security.Cryptography.AesCryptoServiceProvider())
            {
                csp.GenerateKey();
                csp.GenerateIV();

                keyBytes = csp.Key;
                ivBytes = csp.IV;
                //csp.CreateEncryptor

                // Create an encryptor to perform the stream transform.
                System.Security.Cryptography.ICryptoTransform cryptoTransformer = csp.CreateEncryptor(csp.Key, csp.IV);

                // Create the streams used for encryption.
                using (memoryStream = new System.IO.MemoryStream())
                using (System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, cryptoTransformer, System.Security.Cryptography.CryptoStreamMode.Write))
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(cryptoStream))
                {
                    sw.AutoFlush = true;
                    sw.Write(plainText);
                }
            }

            return memoryStream.ToArray();
        }

        public byte[] Encrypt(string plainText, out string keyBase64, out string ivBase64)
        {
            byte[] keyBytes;
            byte[] ivBytes;
            byte[] result = Encrypt(plainText, out keyBytes, out ivBytes);

            keyBase64 = Convert.ToBase64String(keyBytes);
            ivBase64 = Convert.ToBase64String(ivBytes);

            return result;
        }

        public string Decrypt(byte[] inputDataBytes, byte[] keyBytes, byte[] ivBytes)
        {
            if (inputDataBytes == null || inputDataBytes.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (keyBytes == null || keyBytes.Length <= 0)
                throw new ArgumentNullException("Key");
            if (ivBytes == null || ivBytes.Length <= 0)
                throw new ArgumentNullException("IV");

            System.IO.MemoryStream memoryStream;

            using (System.Security.Cryptography.AesCryptoServiceProvider csp = new System.Security.Cryptography.AesCryptoServiceProvider())
            {
                csp.Key = keyBytes;
                csp.IV = ivBytes;
                //csp.CreateEncryptor

                // Create an encryptor to perform the stream transform.
                System.Security.Cryptography.ICryptoTransform cryptoTransformer = csp.CreateDecryptor(csp.Key, csp.IV);

                // Create the streams used for encryption.
                using (memoryStream = new System.IO.MemoryStream(inputDataBytes))
                using (System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, cryptoTransformer, System.Security.Cryptography.CryptoStreamMode.Read))
                using (System.IO.StreamReader sr = new System.IO.StreamReader(cryptoStream))
                {
                    return sr.ReadToEnd();
                }
            }
        }


        public enum KeyedHashAlgorithmName
        {
            HMACSHA256,
            HMACSHA512
        }

        public byte[] Hash(KeyedHashAlgorithmName algName, byte[] inputDataBytes, byte[] keyBytes)
        {
            switch (algName)
            {
                case KeyedHashAlgorithmName.HMACSHA512:
                    using (System.Security.Cryptography.HMACSHA512 hasher = new System.Security.Cryptography.HMACSHA512(keyBytes))
                    {
                        return hasher.ComputeHash(inputDataBytes);
                    }
                case KeyedHashAlgorithmName.HMACSHA256:
                default:
                    using (System.Security.Cryptography.HMACSHA256 hasher = new System.Security.Cryptography.HMACSHA256(keyBytes))
                    {
                        return hasher.ComputeHash(inputDataBytes);
                    }
            }
        }

        public byte[] Hash(KeyedHashAlgorithmName algName, byte[] inputDataBytes, out byte[] keyBytes)
        {
            switch (algName)
            {
                case KeyedHashAlgorithmName.HMACSHA512:
                    using (System.Security.Cryptography.HMACSHA512 hasher = new System.Security.Cryptography.HMACSHA512())
                    {
                        keyBytes = hasher.Key;
                        return hasher.ComputeHash(inputDataBytes);
                    }
                case KeyedHashAlgorithmName.HMACSHA256:
                default:
                    using (System.Security.Cryptography.HMACSHA256 hasher = new System.Security.Cryptography.HMACSHA256())
                    {
                        keyBytes = hasher.Key;
                        return hasher.ComputeHash(inputDataBytes);
                    }
            }
        }

        public byte[] Hash(byte[] inputDataBytes, byte[] keyBytes)
        {
            return Hash(KeyedHashAlgorithmName.HMACSHA256, inputDataBytes, keyBytes);
        }

        public byte[] Hash(byte[] inputDataBytes, out byte[] keyBytes)
        {
            return Hash(KeyedHashAlgorithmName.HMACSHA256, inputDataBytes, out keyBytes);
        }

        public byte[] Hash(string inputString, byte[] keyBytes)
        {
            byte[] inputDataBytes = System.Text.Encoding.UTF8.GetBytes(inputString);
            return Hash(inputDataBytes, keyBytes);
        }

        public byte[] Hash(string inputString, out byte[] keyBytes)
        {
            byte[] inputDataBytes = System.Text.Encoding.UTF8.GetBytes(inputString);
            return Hash(inputDataBytes, out keyBytes);
        }

        public enum HashAlgorithmName
        {
            MD5,
            SHA256,
            SHA512
        }

        public byte[] Hash(HashAlgorithmName algName, byte[] inputDataBytes)
        {
            switch (algName)
            {
                case HashAlgorithmName.SHA256:
                    {
                        using (System.Security.Cryptography.SHA256CryptoServiceProvider hasher = new System.Security.Cryptography.SHA256CryptoServiceProvider())
                        {
                            return hasher.ComputeHash(inputDataBytes);
                        }
                    }
                case HashAlgorithmName.SHA512:
                    {
                        using (System.Security.Cryptography.SHA512CryptoServiceProvider hasher = new System.Security.Cryptography.SHA512CryptoServiceProvider())
                        {
                            return hasher.ComputeHash(inputDataBytes);
                        }
                    }
                case HashAlgorithmName.MD5:
                default:
                    {
                        using (System.Security.Cryptography.MD5CryptoServiceProvider hasher = new System.Security.Cryptography.MD5CryptoServiceProvider()) // hash size 128
                        {
                            return hasher.ComputeHash(inputDataBytes);
                        }
                    }
            }
        }

        public byte[] Hash(HashAlgorithmName algName, string inputString)
        {
            byte[] inputDataBytes = System.Text.Encoding.UTF8.GetBytes(inputString);
            return Hash(algName, inputDataBytes);
        }

        public byte[] Hash(byte[] inputDataBytes)
        {
            return Hash(HashAlgorithmName.SHA256, inputDataBytes);
        }

        public byte[] Hash(string inputString)
        {
            byte[] inputDataBytes = System.Text.Encoding.UTF8.GetBytes(inputString);
            return Hash(inputDataBytes);
        }

        public byte[] PasswordBasedKey(int keyLength, string password, out byte[] saltBytes, out int iterationCount)
        {
            saltBytes = new byte[32];               // 256 bits = 32 bytes
            iterationCount = rnd.Next(1000, 10000); // 1000 to 9999

            using (System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            using (System.Security.Cryptography.Rfc2898DeriveBytes pbk = new System.Security.Cryptography.Rfc2898DeriveBytes(
                password, saltBytes, iterationCount))
            {
                return pbk.GetBytes(keyLength);
            }
        }

        public byte[] PasswordBasedKey(int keyLength, string password, byte[] saltBytes, int iterationCount)
        {
            using (System.Security.Cryptography.Rfc2898DeriveBytes pbk = new System.Security.Cryptography.Rfc2898DeriveBytes(
                password, saltBytes, iterationCount))
            {
                return pbk.GetBytes(keyLength);
            }
        }


    }




    public class TestBed
    {
        public void DoWork()
        {
            CryptographyFactory f = new CryptographyFactory();
            //f.GetHashCode()
            System.Text.Encoding.UTF8.GetBytes("helloworld");
            //f.Encrypt("Hello world");

            // password-based key derivation functionality
            // Get password-based key
            

        }
    }
}
