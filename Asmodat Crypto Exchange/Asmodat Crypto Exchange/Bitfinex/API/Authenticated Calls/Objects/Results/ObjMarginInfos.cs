using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Asmodat.BitfinexV1.API
{
    public class ObjMarginInfos
    {
        /// <summary>
        /// the USD value of all your trading assets (based on last prices)
        /// </summary>
        public decimal margin_balance { get; set; }

        public decimal tradable_balance { get; set; }
        /// <summary>
        /// The unrealized profit/loss of all your open positions
        /// </summary>
        public decimal unrealized_pl { get; set; }
        /// <summary>
        /// The unrealized swap of all your open positions
        /// </summary>
        public decimal unrealized_swap { get; set; }
        /// <summary>
        /// Your net value (the USD value of your trading wallet, including your margin balance, your unrealized P/L and swap)
        /// </summary>
        public decimal net_value { get; set; }
        /// <summary>
        /// The minimum net value to maintain in your trading wallet, under which all of your positions are fully liquidated
        /// </summary>
        public decimal required_margin { get; set; }


        public decimal leverage { get; set; }

        public decimal margin_requirement { get; set; }

        /// <summary>
        /// The list of margin limits for each pair. The array gives you the following information, for each pair:
        /// </summary>
        public ObjMarginLimits[] margin_limits { get; set; }
        

    }
}


/*
 /// <summary>
        /// the USD value of all your trading assets (based on last prices)
        /// </summary>
        public decimal margin_balance { get; set; }
        /// <summary>
        /// The unrealized profit/loss of all your open positions
        /// </summary>
        public decimal unrealized_pl { get; set; }
        /// <summary>
        /// The unrealized swap of all your open positions
        /// </summary>
        public decimal unrealized_swap { get; set; }
        /// <summary>
        /// Your net value (the USD value of your trading wallet, including your margin balance, your unrealized P/L and swap)
        /// </summary>
        public decimal net_value { get; set; }
        /// <summary>
        /// The minimum net value to maintain in your trading wallet, under which all of your positions are fully liquidated
        /// </summary>
        public decimal required_margin { get; set; }
        /// <summary>
        /// The list of margin limits for each pair. The array gives you the following information, for each pair:
        /// </summary>
        public ObjMarginLimits[] margin_limits { get; set; }
*/
