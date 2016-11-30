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

    public class OHLCEntry
    {
        [JsonIgnore]
        public TickTime Time { get { return TickTime.FromUnixTimeStamp((double)Entry[0]); } }
        [JsonIgnore]
        public decimal Open { get { return Entry[1]; } }
        [JsonIgnore]
        public decimal High { get { return Entry[2]; } }
        [JsonIgnore]
        public decimal Low { get { return Entry[3]; } }
        [JsonIgnore]
        public decimal Close { get { return Entry[4]; } }
        /// <summary>
        /// Volume Weighted Average Price
        /// Is calculated by adding up the dollars traded for every transaction 
        /// (price multiplied by number of shares traded) 
        /// and then dividing by the total shares traded for the day.
        /// </summary>
        [JsonIgnore]
        public decimal VWAP { get { return Entry[5]; } }
        [JsonIgnore]
        public decimal Volume { get { return Entry[6]; } }
        [JsonIgnore]
        public decimal Count { get { return Entry[7]; } }


        [JsonProperty(PropertyName = "entry")]
        public decimal[] Entry { get; set; }
    }

    /*
    entry.Time = TickTime.FromUnixTimeStamp((double)array[0]);
                        entry.Open = array[1];
                        entry.High = array[2];
                        entry.Low = array[3];
                        entry.Close = array[4];
                        entry.VWAP = array[5];
                        entry.Volume = array[6];
                        entry.Count = array[7];
    */


}
