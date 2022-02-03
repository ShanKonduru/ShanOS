using System;
using System.Security.Cryptography;
using System.Text;
namespace ShanOS {
    public static class Hash {
        public static string SHA256 (string randomString) {
            var crypt = new System.Security.Cryptography.SHA256Managed ();
            var hash = new System.Text.StringBuilder ();
            byte[] crypto = crypt.ComputeHash (Encoding.UTF8.GetBytes (randomString));
            foreach (byte theByte in crypto) {
                hash.Append (theByte.ToString ("X"));
            }
            return hash.ToString ();
        }
    }
}