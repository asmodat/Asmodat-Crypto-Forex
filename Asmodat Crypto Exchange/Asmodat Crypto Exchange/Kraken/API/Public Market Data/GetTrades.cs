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
        
        public Trades GetTrades(AssetPair pair, string since = null)
        {
            string props = string.Format("pair={0}", pair.Name);

            if (since != null)
                props += string.Format("&since={0}", since);

            string response = QueryPublic("Trades", props);

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;

            
            JToken[] tokens = result.Result.Children().ToArray();
            JProperty jpair = (JProperty)tokens[0];
            JProperty jlast = (JProperty)tokens[1];
            object[][] records = JsonConvert.DeserializeObject<object[][]>(jpair.Value.ToString());

            Trades trades = new Trades();
            trades.Name = jpair.Name;
            trades.Last = jlast.Value.ToString();

            List<TradeEntry> entries = new List<TradeEntry>();
            foreach (object[] record in records)
                entries.Add(new TradeEntry(record));

            trades.Entries = entries.ToArray();

            return trades;

        }

    }




    public class Trades
    {
        /// <summary>
        /// pair name
        /// </summary>
        [JsonIgnore]
        public string Name { get; set; }


        [JsonIgnore]
        public TradeEntry[] Entries { get; set; }


        /// <summary>
        /// id to be used as since when polling for new trade data
        /// </summary>
        [JsonProperty(PropertyName = "last")]
        public string Last { get; set; }
    }

    
    public class TradeEntry
    {
        public TradeEntry(object[] entry)
        {
            this.Price = decimal.Parse((string)entry[0]);
            this.Volume = decimal.Parse((string)entry[1]);
            this.Ticks = TickTime.FromUnixTimeStamp(double.Parse(entry[2].ToString()));
            this.buy_sell = (string)entry[3];
            this.market_limit = (string)entry[4];
            this.miscellaneous = (string)entry[5];
        }
        
        public decimal  Price { get; private set; }

        public decimal Volume { get; private set; }

        public TickTime  Ticks { get; private set; }

        public bool IsBuy
        {
            get
            {
                if (buy_sell.ToLower() == "b")
                    return true;

                return false;
            }
        }

        public bool IsSell
        {
            get
            {
                if (buy_sell.ToLower() == "s")
                    return true;

                return false;
            }
        }

        public bool IsMarket
        {
            get
            {
                if (market_limit.ToLower() == "m")
                    return true;

                return false;
            }
        }

        public bool IsLimit
        {
            get
            {
                if (market_limit.ToLower() == "l")
                    return true;

                return false;
            }
        }

        public string buy_sell { get; private set; }

        public string market_limit { get; private set; }

        public string miscellaneous { get; private set; }
    }
    
}
