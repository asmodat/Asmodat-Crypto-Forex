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
using System.Collections.ObjectModel;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {
        
        public Ticker[] GetTickers(AssetPair[] pairs)
        {
            if (pairs == null)
            {
                return null;
            }
            if (pairs.Count() == 0)
            {
                return null;
            }

            StringBuilder pairString = new StringBuilder("pair=");
            foreach (var item in pairs)
            {
                pairString.Append(item.Name + ",");
            }
            pairString.Length--; //disregard trailing comma

            

            string response = QueryPublic("Ticker", pairString.ToString());

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;
            
            List<Ticker> values = new List<Ticker>();
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

            return values.ToArray();
        }

    }
    /*
    public Ticker Tickersx[ApiProperties.Pairs pair]
        {
            get
            {
            return null;
            }
        }
        */

    

    
}
