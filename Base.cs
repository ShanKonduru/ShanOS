namespace ShanOS {
    public class Base {
        public static string GenerateHash (string inputString) {
            return Hash.SHA256 (inputString);
        }
    }
}