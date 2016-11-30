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
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Asmodat.Debugging;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{

    

    public class AssetPair
    {
        [JsonIgnore]
        public Kraken.Asset? AssetBase
        {
            get
            {
                return Kraken.ToAsset(Base);
            }
        }

        [JsonIgnore]
        public Kraken.Asset? AssetQuote
        {
            get
            {
                return Kraken.ToAsset(Quote);
            }
        }

        /// <summary>
        /// Returns maximum Fee (taker)
        /// </summary>
        public decimal MaxFee
        {
            get
            {
                if (Fees == null || Fees.Length <= 0)
                    return 0;

                decimal max = 0;
                foreach(decimal[] d2d in Fees)
                {
                    if (d2d == null || d2d.Length < 2)
                        continue;

                    decimal fee = d2d[1];
                    if (fee > max)  max = fee;
                }

                return max;
            }
        }

        /// <summary>
        /// Returns maximum maker fee
        /// </summary>
        public decimal MaxFeeMaker
        {
            get
            {
                if (FeesMaker == null || FeesMaker.Length <= 0)
                    return 0;

                decimal max = 0;
                foreach (decimal[] d2d in FeesMaker)
                {
                    if (d2d == null || d2d.Length < 2)
                        continue;

                    decimal fee = d2d[1];
                    if (fee > max) max = fee;
                }

                return max;
            }
        }

        /// <summary>
        /// Returns highest possible fee
        /// </summary>
        public decimal MaxFeeAny
        {
            get
            {
                return Math.Max(MaxFee, MaxFeeMaker);
            }
        }


        /// <summary>
        /// pair name
        /// </summary>
        [JsonIgnore]
        public string Name { get; set; }

        /// <summary>
        /// alternate name
        /// </summary>
        [JsonProperty(PropertyName = "altname")]
        public string AlternateName { get; set; }

        /// <summary>
        /// asset class of base component
        /// </summary>
        [JsonProperty(PropertyName = "aclass_base")]
        public string BaseClass { get; set; }

        /// <summary>
        /// asset id of base component
        /// </summary>
        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }

        /// <summary>
        /// asset class of quote component
        /// </summary>
        [JsonProperty(PropertyName = "aclass_quote")]
        public string QuoteClass { get; set; }

        /// <summary>
        /// asset id of quote component
        /// </summary>
        [JsonProperty(PropertyName = "quote")]
        public string Quote { get; set; }

        /// <summary>
        /// volume lot size
        /// </summary>
        [JsonProperty(PropertyName = "lot")]
        public string Lot { get; set; }

        /// <summary>
        /// scaling decimal places for pair
        /// </summary>
        [JsonProperty(PropertyName = "pair_decimals")]
        public string PairDecimals { get; set; }

        /// <summary>
        /// scaling decimal places for volume
        /// </summary>
        [JsonProperty(PropertyName = "lot_decimals")]
        public decimal LotDecimals { get; set; }

        /// <summary>
        /// amount to multiply lot volume by to get currency volume
        /// </summary>
        [JsonProperty(PropertyName = "lot_multiplier")]
        public decimal LotMultiplayer { get; set; }

        /// <summary>
        /// array of leverage amounts available when buying
        /// </summary>
        [JsonProperty(PropertyName = "leverage_buy")]
        public decimal[] LeverageBuy { get; set; }

        /// <summary>
        /// array of leverage amounts available when selling
        /// </summary>
        [JsonProperty(PropertyName = "leverage_sell")]
        public decimal[] LeverageSell { get; set; }

        /// <summary>
        /// fee schedule array in [volume, percent fee] tuples
        /// </summary>
        [JsonProperty(PropertyName = "fees")]
        public decimal[][] Fees { get; set; }

        /// <summary>
        /// maker fee schedule array in [volume, percent fee] tuples (if on maker/taker)
        /// </summary>
        [JsonProperty(PropertyName = "fees_maker")]
        public decimal[][] FeesMaker { get; set; }

        /// <summary>
        /// volume discount currency
        /// </summary>
        [JsonProperty(PropertyName = "fee_volume_currency")]
        public string FeeVolumeCurrency { get; set; }

        /// <summary>
        /// margin call level
        /// </summary>
        [JsonProperty(PropertyName = "margin_call")]
        public decimal MarginCall { get; set; }

        /// <summary>
        /// stop-out/liquidation margin level
        /// </summary>
        [JsonProperty(PropertyName = "margin_stop")]
        public decimal MarginStop { get; set; }

    }
}
