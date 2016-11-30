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

using Asmodat.Extensions.Objects;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {

        public TradeBalance GetTradeBalance(string aclass = "currency", string asset = "ZUSD")
        {
            string props = "";

            if (!aclass.IsNullOrEmpty())
                props += string.Format("&aclass={0}", aclass);

            if (!asset.IsNullOrEmpty())
                props += string.Format("&asset={0}", asset);

            

            string response = this.QueryPrivate("TradeBalance", props);

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;
            
           /* List<Ticker> values = new List<Ticker>();
            foreach (JProperty property in result.Result.Children())
            {
                try
                {
                    Ticker value = JsonConvert.DeserializeObject<Ticker>(property.Value.ToString());
                    value.Name = property.Name;
                    values.Add(value);
                }
                catch(Exception ex)
                {
                    ex.ToOutput();
                    continue;
                }
            }
            */
            return null;
        }

    }


    public class TradeBalance
    {
        /// <summary>
        ///  asset class (optional): currency(default)
        /// </summary>
        [JsonIgnore]
        public string AssetClass { get; set; } = "currency";

        /// <summary>
        ///  base asset used to determine balance (default = ZUSD)
        /// </summary>
        [JsonIgnore]
        public string BaseAsset { get; set; } = "ZUSD";

        /// <summary>
        /// equivalent balance (combined balance of all currencies)
        /// </summary>
        [JsonProperty(PropertyName = "eb")]
        public decimal EquivalentBalance { get; set; }

        
    }
}
