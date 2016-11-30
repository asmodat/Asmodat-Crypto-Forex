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
        
        public void GetQueryLedgers(List<string> ids)
        {
            if (ids.Count > 20)
                throw new Exception("Ledgers amount max is 20.");


            string props = string.Format("&id={0}", ids[0]);


            for (int i = 1; i < ids.Count; i++)
                props += "," + ids[i];

            string response = this.QueryPrivate("Ledgers", props);

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
