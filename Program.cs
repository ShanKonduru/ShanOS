using System;

namespace ShanOS {
    /// <summary>
    /// Program Entry
    /// </summary>
    public class Program {
        static void Main (string[] args) {
            /// <summary>
            /// Change this Difficulty number to increase the time to insert a new block into main network
            /// </summary>
            int difficulty = 0;

            // Instantiate Blockchain Object
            Blockchain chain = new Blockchain (difficulty);

            UInt64 index = 1;

            // Create a new Block and Add (post minting) it to Chain
            Block b1 = new Block (index++, "First Block");
            Console.WriteLine (b1.ToPrint ());
            chain.AddBlock (b1);

            // Create a new Block and Add (post minting) it to Chain
            Block b2 = new Block (index++, "First Block", b1.CurrentHash);
            Console.WriteLine (b2.ToPrint ());
            chain.AddBlock (b2);

            // To Print the Blockchain contents
            chain.ToPrint ();

            // To validate of the Blockchain is valid
            Console.WriteLine (chain.IsValid ());
        }
    }
}