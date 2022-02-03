    using System.Collections.Generic;
    using System.Linq;
    using System;

    namespace ShanOS {
        public class Blockchain : Base {
            private List<Block> chain = new List<Block> ();
            public Blockchain () {
                if (chain.Count == 0) {
                    chain.Add (this.CreateGenesisBlock ());
                }
            }
            public void AddBlock (Block blockToAdd) {
                Block previousBlock = this.GetLatestBlock ();
                blockToAdd.PreviousHash = previousBlock.CurrentHash;
                blockToAdd.CurrentHash = GenerateHash (blockToAdd.ToString ());
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