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
        
        public DepositMethod[] GetDepositMethods(string asset, string aclass = "currency")
        {
            string props = string.Format("&asset={0}&aclass={1}", asset, aclass);

            string response = this.QueryPrivate("DepositMethods", props);

            if (response == null)
                return null;

            ObjResultArray result = JsonConvert.DeserializeObject<ObjResultArray>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;

            List<DepositMethod> methods = new List<DepositMethod>();
            foreach (JObject obj in result.Result)
            {
                try
                {
                    DepositMethod method = JsonConvert.DeserializeObject<DepositMethod>(obj.ToString());
                    methods.Add(method);
                }
                catch(Exception ex)
                {
                    ex.ToOutput();
                    continue;
                }
            }
            
            return methods.ToArray();
        }

    }

    public class DepositMethod
    {
        /// <summary>
        /// name of deposit method
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        public string Name { get; set; }

        /// <summary>
        /// maximum net amount that can be deposited right now, or false if no limit
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public string limit { get; set; }

        /// <summary>
        /// amount of fees that will be paid
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public string fee { get; set; }

        /// <summary>
        /// whether or not method has an address setup fee (optional)
        /// </summary>
        [JsonProperty(PropertyName = "address-setup-fee")]
        public string address_setup_fee { get; set; }
    }



}
