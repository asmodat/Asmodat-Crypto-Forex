using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Abbreviate;
using Asmodat.Types;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Asmodat.Debugging;
using System.ComponentModel;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{
    public static class OrderInfoEx
    {
        /* public static void GetOpenTicker()
         {
             public bool Equals(OrderInfo x, OrderInfo y)
         {
             if (x == null || x.ID == null || y == null || y.ID == null)
                 return false;

             return x == y;
         }

         public int GetHashCode(OrderInfo obj)
         {
             if (obj == null || obj.ID == null)
                 return 0;

             return ((OrderInfo)obj).ID.GetHashCode();
         }
         }*/
    }


    public class OrderInfo : IEquatable<OrderInfo>
    {
        public bool Equals(OrderInfo other)
        {
            if (other == null || other.ID == null || this.ID == null)
                return false;

            else return this.ID == other.ID;
        }



        /// <summary>
        /// status of order
        /// </summary>
        public enum StatusType
        {
            /// <summary>
            /// order pending book entry
            /// </summary>
            [Description("pending")]
            Pending = 0,
            /// <summary>
            /// open order
            /// </summary>
            [Description("open")]
            Open,
            /// <summary>
            /// closed order
            /// </summary>
            [Description("closed")]
            Closed,
            /// <summary>
            /// order canceled
            /// </summary>
            [Description("canceled")]
            Canceled,
            /// <summary>
            /// order expired
            /// </summary>
            [Description("expired")]
            Expired
        }


        /// <summary>
        /// Transaction ID
        /// </summary>
        [JsonProperty(PropertyName = "ID")]
        public string ID { get; set; }


        /// <summary>
        /// Referral order transaction id that created this order
        /// </summary>
        [JsonProperty(PropertyName = "refid")]
        public string ReferralTransactionID { get; set; }


        /// <summary>
        /// user reference id
        /// </summary>
        [JsonProperty(PropertyName = "userref")]
        public string UserReferenceID { get; set; }

        /// <summary>
        /// status of order
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// unix timestamp of when order was placed
        /// </summary>
        [JsonProperty(PropertyName = "opentm")]
        public double OpenTime { get; set; }

        /// <summary>
        /// unix timestamp of order start time (or 0 if not set)
        /// </summary>
        [JsonProperty(PropertyName = "starttm")]
        public double StartTime { get; set; }

        /// <summary>
        /// unix timestamp of order end time (or 0 if not set)
        /// </summary>
        [JsonProperty(PropertyName = "expiretm")]
        public double EndTime { get; set; }

        /// <summary>
        /// order description info
        /// </summary>
        [JsonProperty(PropertyName = "descr")]
        public OrderDescriptionInfo Description { get; set; }

        /// <summary>
        /// vol = volume of order (base currency unless viqc set in oflags)
        /// </summary>
        [JsonProperty(PropertyName = "vol")]
        public string Volume { get; set; }

        /// <summary>
        /// vol_exec = volume executed (base currency unless viqc set in oflags)
        /// </summary>
        [JsonProperty(PropertyName = "vol_exec")]
        public string VolumeExecuted { get; set; }


        /// <summary>
        /// cost = total cost (quote currency unless unless viqc set in oflags)
        /// </summary>
        [JsonProperty(PropertyName = "cost")]
        public string Cost { get; set; }

        /// <summary>
        /// fee = total fee (quote currency)
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public string Fee { get; set; }

        /// <summary>
        /// price = average price (quote currency unless viqc set in oflags)
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        /// <summary>
        /// stopprice = stop price (quote currency, for trailing stops)
        /// </summary>
        [JsonProperty(PropertyName = "stopprice")]
        public string StopPrice { get; set; }

        /// <summary>
        /// limitprice = triggered limit price (quote currency, when limit based order type triggered)
        /// </summary>
        [JsonProperty(PropertyName = "limitprice")]
        public string LimitPrice { get; set; }

        /// <summary>
        /// misc = comma delimited list of miscellaneous info
        /// </summary>
        [JsonProperty(PropertyName = "misc")]
        public string MiscellaneousInfo { get; set; }

        /// <summary>
        /// oflags = comma delimited list of order flags
        /// </summary>
        [JsonProperty(PropertyName = "oflags")]
        public string Flags { get; set; }

        /// <summary>
        /// trades = array of trade ids related to order (if trades info requested and data available)
        /// </summary>
        [JsonProperty(PropertyName = "trades")]
        public string[] Trades { get; set; }

        
    }

}
