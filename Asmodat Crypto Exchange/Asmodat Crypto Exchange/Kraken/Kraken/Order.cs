using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;
using Asmodat.Types;
using System.ComponentModel;
//using PennedObjects.RateLimiting;

using Asmodat.Extensions;
using Asmodat.Extensions.Collections.Generic;

namespace Asmodat.Kraken
{
    
    public partial class Kraken
    {




        public enum OrderKind : int
        {
            [Description("buy")]
            Buy = 0,
            [Description("sell")]
            Sell = 1
        }

        public enum OrderType : int
        {
            [Description("market")]
            Market = 0,
            /// <summary>
            /// (price = limit price)
            /// </summary>
            [Description("limit")]
            Limit = 1,
            /// <summary>
            /// (price = stop loss price)
            /// </summary>
            [Description("stop-loss")]
            StopLoss = 2,
            /// <summary>
            /// (price = take profit price)
            /// </summary>
            [Description("take-profit")]
            TakeProfit = 3,
            /// <summary>
            /// (price = stop loss price, price2 = take profit price)
            /// </summary>
            [Description("stop-loss-profit")]
            StopLossProfit = 4,
            /// <summary>
            /// (price = stop loss price, price2 = take profit price)
            /// </summary>
            [Description("stop-loss-profit-limit")]
            StopLossProfitLimit = 5,
            /// <summary>
            /// (price = stop loss trigger price, price2 = triggered limit price)
            /// </summary>
            [Description("stop-loss-limit")]
            StopLossLimit = 6,
            /// <summary>
            /// (price = take profit trigger price, price2 = triggered limit price)
            /// </summary>
            [Description("take-profit-limit")]
            TakeProfitLimit = 7,
            /// <summary>
            /// (price = trailing stop offset)
            /// </summary>
            [Description("trailing-stop")]
            TrailingStop = 8,
            /// <summary>
            /// (price = trailing stop offset, price2 = triggered limit offset)
            /// </summary>
            [Description("trailing-stop-limit")]
            TrailingStopLimit = 9,
            /// <summary>
            /// (price = stop loss price, price2 = limit price)
            /// </summary>
            [Description("stop-loss-and-limit")]
            StopLossAndLimit = 10
        }


        /// <summary>
        /// Waring Can be comma delimited, eg: VolumeInQuoteCurrency | FeeInBaseCurrency | FeeInQuoteCurrency
        /// </summary>
        public enum OrderFlags : int
        {
            /// <summary>
            /// (not available for leveraged orders)
            /// </summary>
            [Description("viqc")]
            VolumeInQuoteCurrency = 1,
            [Description("fcib")]
            FeeInBaseCurrency = 2,
            [Description("fciq")]
            FeeInQuoteCurrency = 4,
            [Description("nompp")]
            NoMarketPriceProtection = 8
        }


    }
}
