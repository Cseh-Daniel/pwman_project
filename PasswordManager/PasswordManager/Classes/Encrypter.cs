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

    public static class Encrypter
    {

        private static Aes algorithm = Aes.Create();
        
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
            algorithm.Key = Convert.FromBase64String(keyBase64);
            algorithm.GenerateIV();
            vectorBase64 = Convert.ToBase64String(algorithm.IV);

            ICryptoTransform encryptor = algorithm.CreateEncryptor();

            byte[] encryptedData;

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

        public static string DecryptData(string cipherText, string keyBase64, string vectorBase64)
        {
            algorithm.Key = Convert.FromBase64String(keyBase64);
            algorithm.IV = Convert.FromBase64String(vectorBase64);

            ICryptoTransform decryptor = algorithm.CreateDecryptor();

            byte[] cipher = Convert.FromBase64String(cipherText);

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


        public static string keyGenerator(string passHash, string keyHash)
        {
            string result = "";
            if (passHash.Length != keyHash.Length)
            {
                throw new Exception("The two given strings have different lengths!");
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
