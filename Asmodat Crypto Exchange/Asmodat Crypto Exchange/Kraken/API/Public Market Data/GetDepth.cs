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
        
        public OrderBook GetOrderBook(AssetPair pair, int? count = null)
        {
            string props = string.Format("pair={0}", pair.Name);

            if (count != null)
                props += string.Format("&count={0}", count.Value);

            string response = QueryPublic("Depth", props);

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;

            List<OrderBook> values = new List<OrderBook>();
            foreach (JProperty property in result.Result.Children())
            {

                OrderBook book = JsonConvert.DeserializeObject<OrderBook>(property.Value.ToString());
                book.Name = property.Name;

                book.Asks = new OrderBookEntry[book.asks.Length];
                book.Bids = new OrderBookEntry[book.bids.Length];

                for (int i = 0; i < book.asks.Length; i++)
                {
                    book.Asks[i] = new OrderBookEntry(book.asks[i]);
                }

                for (int i = 0; i < book.bids.Length; i++)
                {
                    book.Bids[i] = new OrderBookEntry(book.bids[i]);
                }

                values.Add(book);
            }
            
            return values[0];

        }

    }




    public class OrderBook
    {
        /// <summary>
        /// pair name
        /// </summary>
        [JsonIgnore]
        public string Name { get; set; }

        /// <summary>
        /// ask side array of array entries(<price>, <volume>, <timestamp>)
        /// </summary>
        [JsonProperty(PropertyName = "asks")]
        public object[][] asks { get; set; }

        /// <summary>
        /// bid side array of array entries(<price>, <volume>, <timestamp>)
        /// </summary>
        [JsonProperty(PropertyName = "bids")]
        public object[][] bids { get; set; }


        [JsonIgnore]
        public OrderBookEntry[] Asks { get; set; }

        [JsonIgnore]
        public OrderBookEntry[] Bids { get; set; }
    }


    public class OrderBookEntry
    {
        public OrderBookEntry(object[] entry)
        {
            this.Price = decimal.Parse((string)entry[0]);
            this.Volume = decimal.Parse((string)entry[1]);
            this.Ticks = TickTime.FromUnixTimeStamp(double.Parse(entry[2].ToString()));
        }

        public decimal  Price { get; private set; }

        public decimal Volume { get; private set; }

        public TickTime  Ticks { get; private set; }
    }

}
