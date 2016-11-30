using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Types;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Asmodat.Debugging;
using System.Collections.ObjectModel;
using Asmodat.Extensions.Objects;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{
    [Serializable]
    public class Ticker : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Ticker Copy()
        {
            return Asmodat.Abbreviate.Objects.Clone(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="asset"></param>
        /// <param name="amount"></param>
        /// <param name="feeLinear">Fee/Maker Fee/Taker Fee - are linear fees in percentages example: 0.25% == 0.25m</param>
        /// <returns></returns>
        public decimal BuyPrice(Kraken.Asset asset, decimal amount, decimal feeLinear)
        {
            if (this.IsBase(asset))
            {
                decimal result = AskPrice * amount;
                return result.AddPercentage(feeLinear);
            }
            else if (this.IsQuote(asset))
            {
                decimal taxfree = amount.FindValueByPercentages(100m + feeLinear, 100m);
                return amount / AskPrice;
            }

            throw new Exception("Specified assed is not falid for this ticker.");
        }



        public decimal SellPrice(Kraken.Asset asset, decimal amount, decimal feeLinear)
        {
            if (this.IsBase(asset))
            {
                decimal result = BidPrice * amount;
                return result.AddPercentage(-feeLinear);
            }
            else if (this.IsQuote(asset))
            {
                decimal taxfree = amount.FindValueByPercentages(100m - feeLinear, 100m);
                return taxfree / BidPrice;
            }

            throw new Exception("Specified assed is not falid for this ticker.");

        }


    


        [JsonIgnore]
        public Kraken.Asset? AssetBase
        {
            get
            {
                if(Name.IsNullOrWhiteSpace())
                    return null;
                
                return Kraken.ToAsset(Name.Substring(0, 4));
            }
        }

        [JsonIgnore]
        public Kraken.Asset? AssetQuote
        {
            get
            {
                if (Name.IsNullOrWhiteSpace())
                    return null;

                return Kraken.ToAsset(Name.Substring(4, 4));
            }
        }

        [JsonIgnore]
        public decimal AskPrice
        {
            get
            {
                return Ask[0];
            }
            set
            {
                Ask[0] = value;
            }
        }

        [JsonIgnore]
        public decimal BidPrice
        {
            get
            {
                return Bid[0];
            }
            set
            {
                Bid[0] = value;
            }
        }

        /// <summary>
        /// pair name
        /// </summary>
        [JsonIgnore]
        public string Name { get; set; }

        /// <summary>
        /// ask array(<price>, <whole lot volume>, <lot volume>),
        /// </summary>
        [JsonProperty(PropertyName = "a")]
        public decimal[] Ask { get; set; }

        /// <summary>
        /// bid array(<price>, <whole lot volume>, <lot volume>),
        /// </summary>
        [JsonProperty(PropertyName = "b")]
        public decimal[] Bid { get; set; }

        /// <summary>
        /// last trade closed array(<price>, <lot volume>),
        /// </summary>
        [JsonProperty(PropertyName = "c")]
        public decimal[] Close { get; set; }

        /// <summary>
        /// volume array(<today>, <last 24 hours>),
        /// </summary>
        [JsonProperty(PropertyName = "v")]
        public decimal[] Volume { get; set; }


        /// <summary>
        /// volume weighted average price array(<today>, <last 24 hours>),
        /// </summary>
        [JsonProperty(PropertyName = "p")]
        public decimal[] AveragePrice { get; set; }

        /// <summary>
        /// number of trades array(<today>, <last 24 hours>),
        /// </summary>
        [JsonProperty(PropertyName = "t")]
        public decimal[] TradesNumber { get; set; }

        /// <summary>
        /// low array(<today>, <last 24 hours>),
        /// </summary>
        [JsonProperty(PropertyName = "l")]
        public decimal[] Low { get; set; }

        /// <summary>
        /// high array(<today>, <last 24 hours>),
        /// </summary>
        [JsonProperty(PropertyName = "h")]
        public decimal[] High { get; set; }

        /// <summary>
        /// today's opening price
        /// </summary>
        [JsonProperty(PropertyName = "o")]
        public decimal Open { get; set; }
    }

}


/*

     public decimal BuyPrice(Kraken.Asset asset, decimal amount, decimal feeLinear)
        {
            if (this.IsBase(asset))
            {
                decimal result = (decimal)(AskPrice * amount);
                return result.AddPercentage(feeLinear);
            }
            else if (this.IsQuote(asset))
            {
                decimal test = 0, testlast = 0;
                decimal min = 0, mid = 0, max = 100000000000000;// amount * AskPrice;

                do
                {
                    mid = (min + max) / (decimal)2;
                    test = SellPrice(AssetBase.Value, mid, feeLinear);

                    if (test > amount)
                        max = mid;
                    else if (test < amount)
                        min = mid;
                    else break;

                    if (testlast == test)
                        return 0;
                    else
                        testlast = test;

                } while (!test.EqualsRound(amount, 8));

                return mid;
            }


            return decimal.MaxValue;
        }



        public decimal SellPrice(Kraken.Asset asset, decimal amount, decimal feeLinear)
        {
            decimal result = 0;

            if (this.IsBase(asset))
            {
                result = (decimal)(BidPrice * amount);
                return result.AddPercentage(-feeLinear);
            }
            else if (this.IsQuote(asset))
            {
                decimal test = 0, testlast = 0;
                decimal min = 0, mid = 0, max = 100000000000000;// amount * AskPrice;

                do
                {
                    mid = (min + max) / (decimal)2;
                    test = BuyPrice(AssetBase.Value, mid, feeLinear);

                    if (test > amount)
                        max = mid;
                    else if (test < amount)
                        min = mid;
                    else break;

                    if (testlast == test)
                        return 0;
                    else
                        testlast = test;

                } while (!test.EqualsRound(amount, 8));

                result = mid;

                //decimal ask = BuyPrice(AssetBase.Value, 1);
               //return amount / ask;

            }

            if (result < 0) return 0;

            return result;
        }

*/
