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
using System.ComponentModel;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{





    public class OHLC
    {
        [JsonIgnore]
        public static Interval[] Intervals { get { return Enums.ToArray<Interval>(); } }


        /// <summary>
        /// time frame interval in minutes
        /// </summary>
        public enum Interval : int
        {
            [Description("1 minute")]
            _1m = 1,
            [Description("5 minutes")]
            _5m = 5,
            [Description("15 minutes")]
            _15m = 15,
            [Description("30 minutes")]
            _30m = 30,
            [Description("1 hour")]
            _1h = 60,
            [Description("14 hours")]
            _4h = 240,
            [Description("1 day")]
            _1d = 1440,
            [Description("7 days")]
            _7d = 10080,
            [Description("15 days")]
            _15d = 21600,
        }


        /// <summary>
        /// pair name
        /// </summary>
        [JsonProperty(PropertyName = "pair_name")]
        public string PairName { get; set; }

        /// <summary>
        /// array of array entries(<time>, <open>, <high>, <low>, <close>, <vwap>, <volume>, <count>)
        /// </summary>
        [JsonProperty(PropertyName = "entries")]
        public OHLCEntry[] Entries { get; set; }

        /// <summary>
        /// return committed OHLC data since given id (optional.  exclusive)
        /// </summary>
        [JsonProperty(PropertyName = "last")]
        public string Last { get; set; }

       
    }
}
