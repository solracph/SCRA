using System;
using System.Security.Cryptography;
using System.Text;

namespace SCRA.Common.Utilities
{
    public class CryptographyHelper
    {
        public static string ComputeHash(string text, HashType hashType)
        {
            StringBuilder builder = new StringBuilder();
            using (HashAlgorithm algorithm = HashAlgorithm.Create(hashType.ToString()))
            {
                byte[] hashBuffer = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));

                foreach (byte b in hashBuffer)
                {
                    builder.Append(b.ToString("x2"));
                }
            }

            return builder.ToString();
        }

        public static bool VerifyHash(string hash, string text, HashType hashType)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(ComputeHash(text, hashType), hash) == 0;
        }

        public static string Encrypt(string text, string key, CipherMode mode, PaddingMode padding)
        {
            byte[] textBuffer = Encoding.UTF8.GetBytes(text);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider { Key = Encoding.UTF8.GetBytes(key), Mode = mode, Padding = padding };

            ICryptoTransform transform = tripleDES.CreateEncryptor();
            byte[] resultBuffer = transform.TransformFinalBlock(textBuffer, 0, textBuffer.Length);
            tripleDES.Clear();

            return Convert.ToBase64String(resultBuffer, 0, resultBuffer.Length);
        }

        public static string Encrypt(string text, string key)
        {
            return Encrypt(text, key, CipherMode.ECB, PaddingMode.PKCS7);
        }

        public static string Decrypt(string text, string key, CipherMode mode, PaddingMode padding)
        {
            byte[] textBuffer = Convert.FromBase64String(text);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider { Key = Encoding.UTF8.GetBytes(key), Mode = mode, Padding = padding };

            ICryptoTransform transform = tripleDES.CreateDecryptor();
            byte[] resultArray = transform.TransformFinalBlock(textBuffer, 0, textBuffer.Length);
            tripleDES.Clear();

            return Encoding.UTF8.GetString(resultArray);
        }

        public static string Decrypt(string text, string key)
        {
            return Decrypt(text, key, CipherMode.ECB, PaddingMode.PKCS7);
        }
    }
}
