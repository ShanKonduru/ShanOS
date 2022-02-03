using System;

namespace ShanOS {
    /// <summary>
    /// Transaction Class
    /// </summary>
    public class Transaction {
        /// <summary>
        /// From Address, The address of the person who initiated this transaction.
        /// </summary>
        /// <value>unsigned long integer</value>
        public UInt64 FromAddress { get; set; }
        /// <summary>
        /// To Address, The address of the person who benefited from this transaction.
        /// </summary>
        /// <value>unsigned long integer</value>
        public UInt64 ToAddress { get; set; }

        /// <summary>
        /// The transaction amount involved in this transaction.
        /// Units of this Transaction amount is in Wei's.
        /// Use the following table for more understanding
        /// Unit	    wei value	wei	                        ether value
        /// wei	        1 wei	    1	                        10^-18 ETH
        /// kwei	    10^3 wei	1,000	                    10^-15 ETH
        /// mwei	    10^6 wei	1,000,000	                10^-12 ETH
        /// gwei	    10^9 wei	1,000,000,000	            10^-9 ETH
        /// microether	10^12 wei	1,000,000,000,000	    10^-6 ETH
        /// milliether	10^15 wei	1,000,000,000,000,000	10^-3 ETH
        /// ether	    10^18 wei	1,000,000,000,000,000,000	1 ETH
        /// </summary>
        /// <value>unsigned long integer</value>
        public UInt64 Value { get; set; }

       /// <summary>
        /// The Transaction Fee paid by the FromAddress in order to commit this transaction.
        /// Transaction Fee is in Wei's 
        /// Use the following table for more understanding
        /// Unit	    wei value	wei	                        ether value
        /// wei	        1 wei	    1	                        10^-18 ETH
        /// kwei	    10^3 wei	1,000	                    10^-15 ETH
        /// mwei	    10^6 wei	1,000,000	                10^-12 ETH
        /// gwei	    10^9 wei	1,000,000,000	            10^-9 ETH
        /// microether	10^12 wei	1,000,000,000,000	    10^-6 ETH
        /// milliether	10^15 wei	1,000,000,000,000,000	10^-3 ETH
        /// ether	    10^18 wei	1,000,000,000,000,000,000	1 ETH
        /// </summary>
        /// <value>unsigned long integer</value>
        public UInt64 TransactionFee { get; set; }

        /// <summary>
        /// The Gas price paid by the FromAddress in order to execute this transaction.
        /// Gas price is in Wei's 
        /// Use the following table for more understanding
        /// Unit	    wei value	wei	                        ether value
        /// wei	        1 wei	    1	                        10^-18 ETH
        /// kwei	    10^3 wei	1,000	                    10^-15 ETH
        /// mwei	    10^6 wei	1,000,000	                10^-12 ETH
        /// gwei	    10^9 wei	1,000,000,000	            10^-9 ETH
        /// microether	10^12 wei	1,000,000,000,000	    10^-6 ETH
        /// milliether	10^15 wei	1,000,000,000,000,000	10^-3 ETH
        /// ether	    10^18 wei	1,000,000,000,000,000,000	1 ETH
        /// </summary>
        /// <value>unsigned long integer</value>
        public UInt64 GasPrice { get; set; }
    }
}