using System;
using ShanOS.Utilities;
namespace ShanOS {
    /// <summary>
    /// Program Entry
    /// </summary>
    public class Program {
        static void Main (string[] args) {

            bool DEBUG_PRINT = false;

            /// <summary>
            /// Change this Difficulty number to increase the time to insert a new block into main network
            /// </summary>
            int difficulty = 0;

            for (difficulty = 0; difficulty <= 5; difficulty++) {

                // Initialize StopWatch to get elapsed Time
                string guid = StopWatch.StartTimer ();

                // Instantiate Blockchain Object
                Blockchain chain = new Blockchain (difficulty);

                UInt64 index = 1;

                // Create a new Block and Add (post minting) it to Chain
                Block b1 = new Block (index++, "First Block");
                if (DEBUG_PRINT) {
                    Console.WriteLine (b1.ToPrint ());
                }
                chain.AddBlock (b1);

                // Create a new Block and Add (post minting) it to Chain
                Block b2 = new Block (index++, "First Block", b1.CurrentHash);
                if (DEBUG_PRINT) {
                    Console.WriteLine (b2.ToPrint ());
                }
                chain.AddBlock (b2);

                // To Print the Blockchain contents
                if (DEBUG_PRINT) {
                    chain.ToPrint ();
                }
                // To validate of the Blockchain is valid
                if (DEBUG_PRINT) {
                    Console.WriteLine (chain.IsValid ());
                }
                long milliseconds = StopWatch.StopTimer (guid);
                Console.WriteLine ("With difficulty: [{0}] Total Time taken to process : [{1}]", difficulty, StopWatch.ToConvertString (milliseconds));
            }
        }
    }
}