    using System.Collections.Generic;
    using System.Linq;
    using System;

    namespace ShanOS {
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

            public Block GetLatestBlock () {
                return chain.Last ();
            }
            public Block CreateGenesisBlock () {
                return new Block (0, string.Empty, string.Empty);
            }
            public bool IsValid () {
                for (var i = 1; i < chain.Count; i++) {
                    Block currentBlock = chain[i];
                    Block previousBlock = chain[i - 1];

                    if (currentBlock.CurrentHash != GenerateHash (currentBlock.ToString ())) {
                        return false;
                    }

                    if (currentBlock.PreviousHash != previousBlock.CurrentHash) {
                        return false;
                    }
                }

                return true;
            }

            public void ToPrint () {
                foreach (Block b in chain) {
                    Console.WriteLine (b.ToPrint ());
                }
            }
        }
    }