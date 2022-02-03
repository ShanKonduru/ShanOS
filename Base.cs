namespace ShanOS {
    /// <summary>
    /// Base Class
    /// </summary>
    public class Base {
        /// <summary>
        /// DATE TIME FROMAT STRING 
        /// </summary>
        public static string DATE_TIME_FORMAT = "yyyyddMMhhmmss";
        /// <summary>
        /// Generate Hash method generates SHA-256 hash string 
        /// </summary>
        /// <param name="inputString">content or message to be hashed</param>
        /// <returns>hexadecimal string of the input string</returns>
        public static string GenerateHash (string inputString) {
            return Hash.SHA256 (inputString);
        }
    }
}