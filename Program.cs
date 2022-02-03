using System;

namespace ShanOS {
    class Program {
        static void Main (string[] args) {
            /// <summary>
            /// Change this Difficulty number to increase the time to insert a new block into main network
            /// </summary>
            int difficulty = 1;

            Blockchain chain = new Blockchain (difficulty);

            UInt64 index = 1;
            Block b1 = new Block (index++, "First Block");
            Console.WriteLine (b1.ToPrint ());
            chain.AddBlock (b1);

            Block b2 = new Block (index++, "First Block", b1.CurrentHash);
            Console.WriteLine (b2.ToPrint ());
            chain.AddBlock (b2);

            chain.ToPrint ();
            Console.WriteLine (chain.IsValid ());

            b2.Data = "I am a Hacker!!! ";
            chain.ToPrint ();
            Console.WriteLine (chain.IsValid ());
        }
    }
}