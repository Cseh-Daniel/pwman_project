using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace PasswordManager.Classes
{
    /*

  https://www.siakabaro.com/how-to-create-aes-encryption-256-bit-key-in-c/

   */


    static class Encrypter
    {

        private static Aes algorithm = Aes.Create();
        private static ICryptoTransform encryptor = algorithm.CreateEncryptor();
        private static ICryptoTransform decryptor = algorithm.CreateDecryptor();
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


        private static string EncryptData(string plainText, string keyBase64, out string vectorBase64)
        {
            using (Aes aesAlgorithm = Aes.Create())
            {
                /*
                 * egy karakter 8bit. A Key 128/256 bit lehet 
                 * 128/8=16 karakter 
                 * vagy 
                 * 256/8=32 karakter 
                 * és utána azt base64 formában kell megadni
                */
                aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
                aesAlgorithm.GenerateIV();
                Console.WriteLine($"Aes Cipher Mode : {aesAlgorithm.Mode}");
                Console.WriteLine($"Aes Padding Mode: {aesAlgorithm.Padding}");
                Console.WriteLine($"Aes Key Size : {aesAlgorithm.KeySize}");

                //set the parameters with out keyword
                vectorBase64 = Convert.ToBase64String(aesAlgorithm.IV);

                // Create encryptor object
                //ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor();

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
            }
        }

        public static string DecryptData(string cipherText, string keyBase64, string vectorBase64)
        {
            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
                aesAlgorithm.IV = Convert.FromBase64String(vectorBase64);

                Console.WriteLine($"Aes Cipher Mode : {aesAlgorithm.Mode}");
                Console.WriteLine($"Aes Padding Mode: {aesAlgorithm.Padding}");
                Console.WriteLine($"Aes Key Size : {aesAlgorithm.KeySize}");
                Console.WriteLine($"Aes Block Size : {aesAlgorithm.BlockSize}");


                // Create decryptor object
                //ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor();

                byte[] cipher = Convert.FromBase64String(cipherText);

                //Decryption will be done in a memory stream through a CryptoStream object
                using (MemoryStream ms = new MemoryStream(cipher))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

     
    }
}
