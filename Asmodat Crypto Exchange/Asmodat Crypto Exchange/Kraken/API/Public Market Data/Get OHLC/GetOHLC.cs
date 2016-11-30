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

using Asmodat.Extensions.Collections.Generic;

namespace Asmodat.Kraken
{
    public partial class KrakenManager
    {

        public OHLC GetOHLC(string pair, OHLC.Interval interval, TickTime since)
        {
            return this.GetOHLC(pair, interval, ((long)since.ToUnixTimeStamp()) + "");
        }
        /// <summary>
        /// Default interval = 1
        /// since = return committed OHLC data since given id (optional.  exclusive)
        /// 
        /// The last entry in the OHLC array is for the current, not-yet-committed frame and will always be present, regardless of the value of "since".
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="interval"></param>
        /// <param name="since"></param>
        /// <returns></returns>
        public OHLC GetOHLC(string pair, OHLC.Interval interval = OHLC.Interval._1m, string since = null)
        {

            string props = string.Format("pair={0}", pair);
            props += string.Format("&interval={0}", (int)interval);


            if (since != null)
                props += string.Format("&since={0}", since);

            string response = QueryPublic("OHLC", props);

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;

            OHLC ohlc = JsonConvert.DeserializeObject<OHLC>(result.Result.ToString());

            //OHLC ohlc = new OHLC();
             foreach (JProperty property in result.Result.Children())
             {
                try
                {
                    if (property.Name != pair)
                        continue;

                    ohlc.PairName = pair;

                    if (property.Value == null)
                        continue;

                    decimal[][] value = JsonConvert.DeserializeObject<decimal[][]>(property.Value.ToString());

                    List<OHLCEntry> entries = new List<OHLCEntry>();
                    foreach (decimal[] array in value)
                    {
                        if (array.IsNullOrEmpty())
                            continue;

                        OHLCEntry entry = new OHLCEntry();
                        entry.Entry = array;
                        entries.Add(entry);
                    }

                    
                    ohlc.Entries = entries.ToArray();

                    break;
                }
                catch (Exception ex)
                {
                    ex.ToOutput();
                    continue;
                }
             }
             

            return ohlc;

        }

    }
}
