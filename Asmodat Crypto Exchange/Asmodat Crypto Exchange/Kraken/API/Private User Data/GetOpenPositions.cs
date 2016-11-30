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
        
        public void GetOpenPositions(string txid = null , bool trades = false)
        {
            string props = string.Format("&txid={0}&trades={1}", txid, trades);

            string response = this.QueryPrivate("OpenPositions", props);

            if (response == null)
                return ;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return ;
            
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
            return;
        }

    }


  
}
