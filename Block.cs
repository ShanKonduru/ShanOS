using System;
namespace ShanOS {
    public class Block : Base {
        public UInt64 Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Data { get; set; }
        public string PreviousHash { get; set; }
        public string CurrentHash { get; private set; }

        private UInt64 Nonce { get; set; }

        override public string ToString () {
            return string.Format ("{0}{1}{2}{3}",
                this.Index,
                this.TimeStamp.ToString ("yyyyddMMhhmmss"),
                this.Data,
                this.Nonce);
        }
        public string ToPrint () {
            return string.Format (
                "Index: {0}\r\nTime Stamp: {1}\r\nData: {2}\r\nPrevious Hash: {3}\r\nCurrent Hash: {4}\r\nNonce :{5}",
                this.Index,
                this.TimeStamp.ToString ("yyyyddMMhhmmss"),
                this.Data,
                this.PreviousHash,
                this.CurrentHash,
                this.Nonce);
        }

        public Block (UInt64 index, string data) {
            this.Index = index;
            this.TimeStamp = DateTime.Now;
            this.Data = data;
            this.PreviousHash = string.Empty;
            this.CurrentHash = GenerateHash (this.ToString ());
            this.Nonce = 0;
        }

        public Block (UInt64 index, string data, string previousHash) {
            this.Index = index;
            this.TimeStamp = DateTime.Now;
            this.Data = data;
            if (index == 0) {
                this.PreviousHash = string.Empty;
            } else {
                this.PreviousHash = previousHash;
            }
            this.CurrentHash = GenerateHash (this.ToString ());
        }
    }
}