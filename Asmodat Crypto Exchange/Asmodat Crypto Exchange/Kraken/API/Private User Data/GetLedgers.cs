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
        
        public void GetLedgers(string aclass = "currency", string asset = "all", string type = "all", string start = null, string end = null, string ofs = null)
        {
            string props = "";
            if (!ofs.IsNullOrEmpty())
                props += string.Format("&ofs={0}", ofs);
            if (!aclass.IsNullOrEmpty())
                props += string.Format("&aclass={0}", aclass);
            if (!type.IsNullOrEmpty())
                props += string.Format("&type={0}", type);
            if (!start.IsNullOrEmpty())
                props += string.Format("&start={0}", start);
            if (!end.IsNullOrEmpty())
                props += string.Format("&end={0}", end);

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
