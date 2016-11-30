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
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {
        
        public Spread GetSpread(AssetPair pair, string since = null)
        {
            string props = string.Format("pair={0}", pair.Name);

            if (since != null)
                props += string.Format("&since={0}", since);

            string response = QueryPublic("Spread", props);

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;

            
            JToken[] tokens = result.Result.Children().ToArray();
            JProperty jpair = (JProperty)tokens[0];
            JProperty jlast = (JProperty)tokens[1];
            object[][] records = JsonConvert.DeserializeObject<object[][]>(jpair.Value.ToString());

            Spread spreads = new Spread();
            spreads.Name = jpair.Name;
            spreads.Last = jlast.Value.ToString();

            List<SpreadEntry> entries = new List<SpreadEntry>();
            foreach (object[] record in records)
                entries.Add(new SpreadEntry(record));

            spreads.Entries = entries.ToArray();

            return spreads;

        }

    }




    public class Spread
    {
        /// <summary>
        /// pair name
        /// </summary>
        [JsonIgnore]
        public string Name { get; set; }


        [JsonIgnore]
        public SpreadEntry[] Entries { get; set; }


        /// <summary>
        /// id to be used as since when polling for new spread data
        /// </summary>
        [JsonProperty(PropertyName = "last")]
        public string Last { get; set; }
    }

    
    public class SpreadEntry
    {
        public SpreadEntry(object[] entry)
        {
            this.Ticks = TickTime.FromUnixTimeStamp(double.Parse(entry[0].ToString()));
            this.Bid = decimal.Parse((string)entry[1]);
            this.Ask = decimal.Parse((string)entry[2]);
        }
        
        public decimal  Bid { get; private set; }

        public decimal Ask { get; private set; }

        public TickTime  Ticks { get; private set; }

      
    }
    
}
