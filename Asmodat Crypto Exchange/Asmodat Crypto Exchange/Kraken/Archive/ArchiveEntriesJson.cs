using Asmodat.Kraken;
using Asmodat.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Asmodat.IO;
using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;

namespace Asmodat.Kraken
{

    public static class ArchiveEntriesJsonEx
    {
        public static string GetKey(this ArchiveEntriesJson json)
        {
            if (json == null)  return null;
            return json.PairName + (int)json.Interval;
        }
    }

    public class ArchiveEntriesJson
    {
        [JsonProperty(PropertyName = "pair_name")]
        public string PairName { get; set; }

        /// <summary>
        /// Interval in minutes span between entries
        /// </summary>
        [JsonProperty(PropertyName = "interval")]
        public OHLC.Interval Interval { get; set; }

        [JsonProperty(PropertyName = "entries")]
        public OHLCEntry[] Entries { get; set; }

        [JsonProperty(PropertyName = "last")]
        public TickTime Last { get; set; } = new TickTime(0);
    }

   
}


/*while (pairs == null || pairs.Length <= 0)
            {
                if(Manager.Kraken != null)
                    pairs = Manager.Kraken.GetAssetPairs();
                Thread.Sleep(1000);
            }*/
