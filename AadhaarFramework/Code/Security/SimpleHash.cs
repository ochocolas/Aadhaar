using System;

using System.Text;

using System.Security.Cryptography;

namespace AadhaarFramework.Code.Security
{
    
    // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    // SAMPLE: Hashing data with salt using MD5 and several SHA algorithms.
    // 
    // To run this sample, create a new Visual Basic.NET project using the Console
    // Application template and replace the contents of the Module1.vb file with
    // the code below.
    // 
    // THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
    // EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
    // WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
    // 
    // Copyright (C) 2002 Obviex(TM). All rights reserved.
    // 


    // Module Module1

    // <summary>
    // This class generates and compares hashes using MD5, SHA1, SHA256, SHA384, 
    // and SHA512 hashing algorithms. Before computing a hash, it appends a
    // randomly generated salt to the plain text, and stores this salt appended
    // to the result. To verify another plain text value against the given hash,
    // this class will retrieve the salt value from the hash string and use it
    // when computing a new hash of the plain text. Appending a salt value to
    // the hash may not be the most efficient approach, so when using hashes in
    // a real-life application, you may choose to store them separately. You may
    // also opt to keep results as byte arrays instead of converting them into
    // base64-encoded strings.
    // </summary>
    public class SimpleHash
    {
        /// <summary>
        /// 
        /// </summary>
        private const string SHA_ALGORITHM = "SHA512";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string HashThisPlease(string plainText)
        {
            return ComputeHash(plainText, SHA_ALGORITHM, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Modulo"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GenerateKeyFor(string Modulo, string ID)
        {
            return ComputeHash(ID, SHA_ALGORITHM, Encoding.UTF8.GetBytes(Modulo));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Modulo"></param>
        /// <param name="ID"></param>
        /// <param name="Licence"></param>
        /// <returns></returns>
        public static bool CheckLicence(string Modulo, string ID, string Licence)
        {
            string Key = GenerateKeyFor(Modulo, ID);
            string SpectedLicence = GenerateLicence(Key);


            return SpectedLicence.Equals(Licence);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string GenerateLicence(string Key)
        {
            string ReHashed = Key;
            for (int x = 0; x <= 2000; x++)
                ReHashed = ComputeHash(ReHashed, SHA_ALGORITHM, Encoding.UTF8.GetBytes("$Siner81@#1"));

            return ReHashed;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool CheckThisHashPlease(string plainText, string hash)
        {
            return VerifyHash(plainText, SHA_ALGORITHM, hash);
        }


        // <summary>
        // Generates a hash for the given plain text value and returns a
        // base64-encoded result. Before the hash is computed, a random salt
        // is generated and appended to the plain text. This salt is stored at
        // the end of the hash value, so it can be used later for hash
        // verification.
        // </summary>
        // <param name="plainText">
        // Plaintext value to be hashed. The function does not check whether
        // this parameter is null.
        // </param>
        // < name="hashAlgorithm">
        // Name of the hash algorithm. Allowed values are: "MD5", "SHA1",
        // "SHA256", "SHA384", and "SHA512" (if any other value is specified
        // MD5 hashing algorithm will be used). This value is case-insensitive.
        // </param>
        // < name="saltBytes">
        // Salt bytes. This parameter can be null, in which case a random salt
        // value will be generated.
        // </param>
        // <returns>
        // Hash value formatted as a base64-encoded string.
        // </returns>
        private static string ComputeHash(string plainText, string hashAlgorithm, byte[] saltBytes)
        {

            // If salt is not specified, generate it on the fly.
            if ((saltBytes == null))
            {

                // Define min and max salt sizes.
                int minSaltSize;
                int maxSaltSize;

                minSaltSize = 4;
                maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random;
                random = new Random();

                int saltSize;
                saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize - 1 + 1];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng;
                rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Convert plain text into a byte array.
            byte[] plainTextBytes;
            plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length - 1 + 1];

            // Copy plain text bytes into resulting array.
            int I;
            for (I = 0; I <= plainTextBytes.Length - 1; I++)
                plainTextWithSaltBytes[I] = plainTextBytes[I];

            // Append salt bytes to the resulting array.
            for (I = 0; I <= saltBytes.Length - 1; I++)
                plainTextWithSaltBytes[plainTextBytes.Length + I] = saltBytes[I];

            // Because we support multiple hashing algorithms, we must define
            // hash object as a common (abstract) base class. We will specify the
            // actual hashing algorithm class later during object creation.
            HashAlgorithm hash;

            // Make sure hashing algorithm name is specified.
            if ((hashAlgorithm == null))
                hashAlgorithm = "";

            // Initialize appropriate hashing algorithm class.
            switch (hashAlgorithm.ToUpper())
            {
                case "SHA1":
                    {
                        hash = new SHA1Managed();
                        break;
                    }

                case "SHA256":
                    {
                        hash = new SHA256Managed();
                        break;
                    }

                case "SHA384":
                    {
                        hash = new SHA384Managed();
                        break;
                    }

                case "SHA512":
                    {
                        hash = new SHA512Managed();
                        break;
                    }

                default:
                    {
                        hash = new MD5CryptoServiceProvider();
                        break;
                    }
            }

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes;
            hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length + saltBytes.Length - 1 + 1];

            // Copy hash bytes into resulting array.
            for (I = 0; I <= hashBytes.Length - 1; I++)
                hashWithSaltBytes[I] = hashBytes[I];

            // Append salt bytes to the result.
            for (I = 0; I <= saltBytes.Length - 1; I++)
                hashWithSaltBytes[hashBytes.Length + I] = saltBytes[I];

            // Convert result into a base64-encoded string.
            string hashValue;
            hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            //ComputeHash = hashValue;
            return hashValue;
        }

        // <summary>
        // Compares a hash of the specified plain text value to a given hash
        // value. Plain text is hashed with the same salt value as the original
        // hash.
        // </summary>
        // <param name="plainText">
        // Plain text to be verified against the specified hash. The function
        // does not check whether this parameter is null.
        // </param>
        // < name="hashAlgorithm">
        // Name of the hash algorithm. Allowed values are: "MD5", "SHA1",
        // "SHA256", "SHA384", and "SHA512" (if any other value is specified
        // MD5 hashing algorithm will be used). This value is case-insensitive.
        // </param>
        // < name="hashValue">
        // Base64-encoded hash value produced by ComputeHash function. This value
        // includes the original salt appended to it.
        // </param>
        // <returns>
        // If computed hash mathes the specified hash the function the return
        // value is true; otherwise, the function returns false.
        // </returns>
        private static bool VerifyHash(string plainText, string hashAlgorithm, string hashValue)
        {

            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes;
            hashWithSaltBytes = Convert.FromBase64String(hashValue);

            // We must know size of hash (without salt).
            int hashSizeInBits;
            int hashSizeInBytes;

            // Make sure that hashing algorithm name is specified.
            if ((hashAlgorithm == null))
                hashAlgorithm = "";

            // Size of hash is based on the specified algorithm.
            switch (hashAlgorithm.ToUpper())
            {
                case "SHA1":
                    {
                        hashSizeInBits = 160;
                        break;
                    }

                case "SHA256":
                    {
                        hashSizeInBits = 256;
                        break;
                    }

                case "SHA384":
                    {
                        hashSizeInBits = 384;
                        break;
                    }

                case "SHA512":
                    {
                        hashSizeInBits = 512;
                        break;
                    }

                default:
                    {
                        hashSizeInBits = 128;
                        break;
                    }
            }

            // Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if ((hashWithSaltBytes.Length < hashSizeInBytes))
                return false;
            //    VerifyHash = false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes - 1 + 1];

            // Copy salt from the end of the hash to the new array.
            int I;
            for (I = 0; I <= saltBytes.Length - 1; I++)
                saltBytes[I] = hashWithSaltBytes[hashSizeInBytes + I];

            // Compute a new hash string.
            string expectedHashString;
            expectedHashString = ComputeHash(plainText, hashAlgorithm, saltBytes);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            //VerifyHash = (hashValue == expectedHashString);
            return (hashValue == expectedHashString);
        }
    }
    
}
