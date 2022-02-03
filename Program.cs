using System;

namespace ShanOS
{
    class Program
    {
        static void Main(string[] args)
        {
            UInt64 index=0;
            Block genesisBlock = new Block(index++, "Genesis Block");
            Console.WriteLine(genesisBlock.ToPrint());
            Block b1 = new Block(index++, "First Block", genesisBlock.CurrentHash );
            Console.WriteLine(b1.ToPrint());
            Block b2 = new Block(index++, "First Block", b1.CurrentHash );
            Console.WriteLine(b2.ToPrint());
            b1.Data="Made a Change";
            Console.WriteLine(b2.ToPrint());
        }
    }
}
