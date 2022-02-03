using System;
namespace ShanOS {
    public class Block : Base {
        /// <summary>
        /// Index indicate the position of the Block.
        /// If Index is ZERO then it must be a Genesis Block
        /// Else it must be a Genuine Block
        /// </summary>
        /// <value>unsigned long integer</value>
        public UInt64 Index { get; set; }

        /// <summary>
        /// Indicates the Timestamp of when the Block has been Created
        /// </summary>
        /// <value>DateTime Object</value>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Data can be a Simple string or a Complex Transaction Object
        /// </summary>
        /// <value>string or a complex object</value>
        public string Data { get; set; }

        /// <summary>
        /// Previous Hash string (HexaDecimal) string 
        /// Address of Previous Block
        /// </summary>
        /// <value>HexaDecimal string </value>
        public string PreviousHash { get; set; }

        /// <summary>
        /// Current Hash string (HexaDecimal) string 
        /// Address of Current Block
        /// </summary>
        /// <value>HexaDecimal string </value>
        public string CurrentHash { get; set; }

        /// <summary>
        /// Nonce is rather calculated by counting the number of transactions sent from an address.
        /// </summary>
        /// <value>unsigned long integer</value>
        private UInt64 Nonce { get; set; }

        override public string ToString () {
            return string.Format ("{0}{1}{2}{3}",
                this.Index,
                this.TimeStamp.ToString (DATE_TIME_FORMAT),
                this.Data,
                this.Nonce);
        }
        public string ToPrint () {
            return string.Format (
                "Index: {0}\r\nTime Stamp: {1}\r\nData: {2}\r\nPrevious Hash: {3}\r\nCurrent Hash: {4}\r\nNonce :{5}",
                this.Index,
                this.TimeStamp.ToString (DATE_TIME_FORMAT),
                this.Data,
                string.IsNullOrEmpty (this.PreviousHash) ? "NULL" : this.PreviousHash,
                this.CurrentHash,
                this.Nonce);
        }

        public Block (UInt64 index, string data, string previousHash = null) {
            // Assign Index
            this.Index = index;
            // Assign Time Stamp 
            this.TimeStamp = DateTime.Now;

            // Check the Block we are creating is a Genisis  Block of Genuine Block
            if (index == 0 &&
                string.IsNullOrEmpty (data) &&
                string.IsNullOrEmpty (previousHash)) {
                // When Index is ZERO, Data is NULL, Previous Hash is also NULL
                // Then this must be a Genesis Block
                this.Data = "Genesis Block";
                this.PreviousHash = string.Empty;
            } else {
                // When Index is NOT ZERO, Data is NOT NULL, Previous Hash is also NOT NULL
                // Then this must be Genuine Block
                this.Data = data;
                this.PreviousHash = previousHash;
            }

            // Always Generate Hash based on This Object
            this.CurrentHash = GenerateHash (this.ToString ());

        }

        /// <summary>
        /// Add Block to Blockchain.
        /// This Method mines the block before adding it to Blockchain.
        /// </summary>
        /// <param name="blockToAdd">Block object to be added to Blockchain</param>
        public void MineNewBlock (int  difficulty) {
            if (difficulty > 0) {
                while (this.CurrentHash.Substring (0, difficulty) !=
                    string.Empty.PadLeft (difficulty, '0')) {
                    this.Nonce++;
                    this.CurrentHash = GenerateHash (this.ToString ());
                }
            } else {
                this.CurrentHash = GenerateHash (this.ToString ());
            }
            // Console.WriteLine ("Block Mined : {0}", this.CurrentHash);
        }
    }
}