using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Asmodat.Abbreviate;

namespace Asmodat.BitfinexV1.API
{
    public class ObjRequestWithdrawl : ObjRequest
    {
        public ObjRequestWithdrawl(string nonce, string withdraw_type, string walletselected, string amount, string address)
        {
            this.nonce = nonce;
            this.withdraw_type = withdraw_type;
            this.walletselected = walletselected;
            this.amount = amount;
            this.address = address;

            this.request = ApiProperties.WithdrawalRequestUrl; 
        }


        /// <summary>
        /// can be "bitcoin", "litecoin" or "darkcoin" or "tether".
        /// </summary>
        public string withdraw_type { get; set; }
        /// <summary>
        /// The wallet to withdraw from, can be "trading", "exchange", or "deposit".
        /// </summary>
        public string walletselected { get; set; }
        /// <summary>
        /// Amount to withdraw.
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// Destination address for withdrawal.
        /// </summary>
        public string address { get; set; }


    }
}
