using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Asmodat.BitfinexV1.API
{
    public class ObjWalletBalances
    {
        /// <summary>
        /// "trading", "deposit" or "exchange".
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Currency
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// How much balance of this currency in this wallet
        /// </summary>
        public decimal amount { get; set; }
        /// <summary>
        /// How much X there is in this wallet that is available to trade.
        /// </summary>
        public decimal available { get; set; }

    }
}
