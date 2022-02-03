using System;
using System.Security.Cryptography;
using System.Text;

namespace ShanOS {
    /// <summary>
    /// Hash Class
    /// SHA-256 Crypto Hash
    /// </summary>
    public static class Hash {
        /// <summary>
        /// SHA256 Hash crypto hash algorithm
        /// </summary>
        /// <param name="randomString">random string to Hashed</param>
        /// <returns>Crypto hashed string</returns>
        public static string SHA256 (string randomString) {
            var crypt = new System.Security.Cryptography.SHA256Managed ();
            var hash = new System.Text.StringBuilder ();
            byte[] crypto = crypt.ComputeHash (Encoding.UTF8.GetBytes (randomString));
            foreach (byte theByte in crypto) {
                hash.Append (theByte.ToString ("X"));
            }

            // Crypto hash to return
            return hash.ToString ();
        }
    }
}