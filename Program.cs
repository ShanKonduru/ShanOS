using System;

namespace ShanOS {
    class Program {
        static void Main (string[] args) {
            Blockchain chain = new Blockchain ();

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