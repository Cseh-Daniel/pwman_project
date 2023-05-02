using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace PasswordManager.Classes
{
    /*

  https://www.siakabaro.com/how-to-create-aes-encryption-256-bit-key-in-c/

   */

    static class Encrypter
    {

        private static Aes algorithm = Aes.Create();
        /*
         * Encryptor and Decryptor can't be class level members 
         * 'cause they are always created with the keys and vectors 
         * that was set in the algorithm object when creating them.
        */


        //private static ICryptoTransform encryptor = algorithm.CreateEncryptor();
        //private static ICryptoTransform decryptor = algorithm.CreateDecryptor();


        private static String vectorBase64 = "";






        public static String getVector()
        {
            return vectorBase64;
        }

        public static void setVector(String value)
        {
            vectorBase64 = value;
        }


        public static string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA256Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }


        public static string EncryptData(string plainText, string keyBase64)
        {

            //algorithm.Padding = PaddingMode.None;

            /*using (Aes aesAlgorithm = Aes.Create())
            {*/


            /*
             * egy karakter 8bit. A Key 128/256 bit lehet 
             * 128/8=16 karakter 
             * vagy 
             * 256/8=32 karakter 
             * és utána azt base64 formában kell megadni
            */

            algorithm.Key = Convert.FromBase64String(keyBase64);
            algorithm.GenerateIV();

            /*
                Console.WriteLine($"Aes Cipher Mode : {algorithm.Mode}");
                Console.WriteLine($"Aes Padding Mode: {algorithm.Padding}");
                Console.WriteLine($"Aes Key Size : {algorithm.KeySize}");
            */

            //set the parameters with out keyword
            vectorBase64 = Convert.ToBase64String(algorithm.IV);

            // Create encryptor object
            ICryptoTransform encryptor = algorithm.CreateEncryptor();

            byte[] encryptedData;

            //Encryption will be done in a memory stream through a CryptoStream object
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    encryptedData = ms.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedData);
            /*}*/
        }

        public static string DecryptData(string cipherText, string keyBase64, string vectorBase64)
        {
            //algorithm.Padding = PaddingMode.None;

            /* using (Aes aesAlgorithm = Aes.Create())
             {*/
            algorithm.Key = Convert.FromBase64String(keyBase64);
            algorithm.IV = Convert.FromBase64String(vectorBase64);

            Debug.WriteLine(
                "key: " + algorithm.Key +
                "\n IVvector: " + algorithm.IV +
                "\n CipherText: " + cipherText +
                "\n Key: " + keyBase64 +
                "\n vectorBase64: " + vectorBase64
                );


            Debug.WriteLine($"Aes Cipher Mode : {algorithm.Mode}");
            Debug.WriteLine($"Aes Padding Mode: {algorithm.Padding}");
            Debug.WriteLine($"Aes Key Size : {algorithm.KeySize}");
            Debug.WriteLine($"Aes Block Size : {algorithm.BlockSize}");


            // Create decryptor object
            ICryptoTransform decryptor = algorithm.CreateDecryptor();

            byte[] cipher = Convert.FromBase64String(cipherText);

            //Decryption will be done in a memory stream through a CryptoStream object

            using (MemoryStream ms = new MemoryStream(cipher))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {

                        string srTemp = sr.ReadToEnd();
                        Debug.WriteLine("\n\tsr.ReadToEnd(): " + srTemp);

                        //return sr.ReadToEnd();
                        return srTemp;
                    }
                }
            }
        }


        public static string keyGenerator(string passHash, string keyHash)
        {
            string result = "";
            if (passHash.Length != keyHash.Length)
            {
                throw new Exception("The two given strings has different lengths!");
            }

            for (int i = 0; i < passHash.Length; i++)
            {
                if (i % 2 == 0)
                {
                    result += passHash[i];
                }
                else
                {
                    result += keyHash[i];
                }
            }

            return result;
        }


    }

}
