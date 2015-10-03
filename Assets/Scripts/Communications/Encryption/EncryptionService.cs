namespace MarvelUniverse.Communications.Encryption
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// The encryption service.
    /// </summary>
    public class EncryptionService
    {
        /// <summary>
        /// Creates a MD5 hash of the string passed.
        /// </summary>
        /// <param name="stringToEncrypt">The string to encrypt.</param>
        /// <returns>The MD5 hash.</returns>
        public string MD5Hash(string stringToEncrypt)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] stringBytes = encoding.GetBytes(stringToEncrypt);
            
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(stringBytes);
            
            string hashString = string.Empty;

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            }

            return hashString.PadLeft(32, '0');
        }
    }
}
