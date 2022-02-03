using System;
using System.Collections.Generic;
using System.Linq;

namespace ShanOS {
    /// <summary>
    /// Blockchain Class to handle all Blockchain features and functionalities
    /// </summary>
    public class Blockchain : Base {

        /// <summary>
        /// Difficulty Level, Cryptocurrency difficulty is a measure of how difficult it is to mine a block in a blockchain for a particular cryptocurrency. A high cryptocurrency difficulty means it takes additional computing power to verify transactions entered on a blockchain—a process called mining.
        /// </summary>
        /// <value>intger value</value>
        public int Difficulty { get; set; }

        /// <summary>
        /// A Datastructure to hold Blocks
        /// </summary>
        /// <typeparam name="Block">Block objects</typeparam>
        /// <returns>List pf Block Objects</returns>
        private List<Block> chain = new List<Block> ();

        /// <summary>
        ///  Constructor for Blockchain class.
        /// On instantiation it creates a Genisis block automatically.
        /// </summary>
        public Blockchain (int difficulty) {
            this.Difficulty = difficulty;
            if (chain.Count == 0) {
                chain.Add (this.CreateGenesisBlock ());
            }
        }

        /// <summary>
        /// Add Block to Blockchain.
        /// This Method typically by-passes the Mining algorithm.
        /// </summary>
        /// <param name="blockToAdd">Block object to be added to Blockchain</param>
        public void AddBlock (Block blockToAdd) {
            Block previousBlock = this.GetLatestBlock ();
            blockToAdd.PreviousHash = previousBlock.CurrentHash;
            // blockToAdd.CurrentHash = GenerateHash (blockToAdd.ToString ());
            blockToAdd.MineNewBlock (this.Difficulty);
            chain.Add (blockToAdd);
        }
        /// <summary>
        /// Get the Latest Block from Blockchain
        /// </summary>
        /// <returns>Block object</returns>
        public Block GetLatestBlock () {
            return chain.Last ();
        }
        /// <summary>
        /// Create Genesis Block with Empty Index, Entry Data and Empty Previous Hash
        /// </summary>
        /// <returns>Block object</returns>
        public Block CreateGenesisBlock () {
            return new Block (0, string.Empty, string.Empty);
        }

        /// <summary>
        /// Is Valid, checks of the Blockchain is valid or not.
        /// Does not Validate the Genesis Block
        /// </summary>
        /// <returns>true if the blockchain is valid, else returns false</returns>
        public bool IsValid () {
            for (var i = 1; i < chain.Count; i++) {
                // Current Block
                Block currentBlock = chain[i];
                // Previous Block
                Block previousBlock = chain[i - 1];

                if (currentBlock.CurrentHash != GenerateHash (currentBlock.ToString ())) {
                    // If CurrentHast does not match with Calculated Hash, it may mean 
                    // that the Block Data must have modified after Block added to Block chain
                    // So Validation must FAIL.
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.CurrentHash) {
                    // If Current Bock's Previous Hash does not match with Previous BLocks current Hash, it may mean 
                    // that the Linking of Blocks in Blockchain has broken. 
                    // So Validation must FAIL.
                    return false;
                }
            }

            // If all Blocks in the Blockchain pass through till this point, 
            // Means the Block is Good - Validation must PASS
            return true;
        }

        /// <summary>
        /// To Print the Entire BlockChain, including the Geneisis Block.
        /// </summary>
        public void ToPrint () {
            foreach (Block b in chain) {
                Console.WriteLine (b.ToPrint ());
                Console.WriteLine ("------------------------------------------");
            }
        }
    }
}