using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Asmodat.BitfinexV1.API
{
    public class ObjMarginLimits
    {
        /// <summary>
        /// The pair for which these limits are valid
        /// </summary>
        public string on_pair { get; set; }
        /// <summary>
        /// The minimum margin (in %) to maintain to open or increase a position
        /// </summary>
        public decimal initial_margin { get; set; }
        /// <summary>
        /// Your tradable balance in USD (the maximum size you can open on leverage for this pair)
        /// </summary>
        public decimal tradable_balance { get; set; }
        /// <summary>
        /// The maintenance margin (% of the USD value of all of your open positions in the current pair to maintain)
        /// </summary>
        public decimal margin_requirement { get; set; }

    }
}


/*
/// <summary>
        /// The pair for which these limits are valid
        /// </summary>
        public string on_pair { get; set; }
        /// <summary>
        /// The minimum margin (in %) to maintain to open or increase a position
        /// </summary>
        public decimal initial_margin { get; set; }
        /// <summary>
        /// Your tradable balance in USD (the maximum size you can open on leverage for this pair)
        /// </summary>
        public decimal tradable_balance { get; set; }
        /// <summary>
        /// The maintenance margin (% of the USD value of all of your open positions in the current pair to maintain)
        /// </summary>
        public decimal margin_requirements { get; set; }
*/
