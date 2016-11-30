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
    /// <summary>
    /// order description info
    /// </summary>
    public class OrderDescriptionInfo
    {
        /// <summary>
        /// pair = asset pair
        /// </summary>
        [JsonProperty(PropertyName = "pair")]
        public string Pair { get; set; }

        /// <summary>
        /// type = type of order (buy/sell)
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// ordertype = order type
        /// </summary>
        [JsonProperty(PropertyName = "ordertype")]
        public string OrderType { get; set; }

        /// <summary>
        /// price = primary price
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public string PrimaryPrice { get; set; }

        /// <summary>
        /// price2 = secondary price
        /// </summary>
        [JsonProperty(PropertyName = "price2")]
        public string SecondaryPrice { get; set; }

        /// <summary>
        /// leverage = amount of leverage
        /// </summary>
        [JsonProperty(PropertyName = "leverage")]
        public string Leverage { get; set; }

        /// <summary>
        /// order = order description
        /// </summary>
        [JsonProperty(PropertyName = "order")]
        public string Description { get; set; }

        /// <summary>
        /// close = conditional close order description (if conditional close set)
        /// </summary>
        [JsonProperty(PropertyName = "close")]
        public string Close { get; set; }
    }


}
