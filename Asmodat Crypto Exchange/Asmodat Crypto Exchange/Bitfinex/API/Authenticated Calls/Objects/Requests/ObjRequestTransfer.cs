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
    public class ObjRequestTransfer : ObjRequest
    {
        public ObjRequestTransfer(string nonce, decimal amount, string currency, string walletfrom, string walletto)
        {
            this.nonce = nonce;
            this.amount = amount.ToString();
            this.currency = currency;
            this.walletfrom = walletfrom;
            this.walletto = walletto;

            this.request = ApiProperties.TransferRequestUrl; 
        }

        /// <summary>
        /// Amount to transfer.
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// Currency of funds to transfer.
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// Wallet to transfer from.
        /// </summary>
        public string walletfrom { get; set; }
        /// <summary>
        /// Wallet to transfer to.
        /// </summary>
        public string walletto { get; set; }


    }
}
