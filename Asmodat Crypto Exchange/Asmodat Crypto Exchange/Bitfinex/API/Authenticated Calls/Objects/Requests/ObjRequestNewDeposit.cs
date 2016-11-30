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
    public class ObjRequestNewDeposit : ObjRequest
    {
        public ObjRequestNewDeposit(string nonce, string method, string wallet_name, int renew = 0)
        {
            this.nonce = nonce;
            this.method = method;
            this.wallet_name = wallet_name;

            if(renew == 0 || renew == 1)
                this.renew = renew;

            this.request = ApiProperties.NewDepositRequestUrl; 
        }

        /// <summary>
        /// Method of deposit (methods accepted: "bitcoin", "litecoin", "darkcoin", "mastercoin" (tethers)).
        /// </summary>
        public string method { get; set; }

        /// <summary>
        /// Wallet to deposit in (accepted: "trading", "exchange", "deposit"). Your wallet needs to already exist
        /// </summary>
        public string wallet_name { get; set; }

        /// <summary>
        /// (optional) Default is 0. If set to 1, will return a new unused deposit address
        /// </summary>
        public int renew { get; set; } = 0;
    }
}
