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
        
        public WithdrawInfo GetWithdrawlInfo(string asset, string key, decimal amount, string aclass = "currency")
        {
            string props = string.Format("&asset={0}&key={1}&amount={2}&aclass={3}", asset, key, amount, aclass);

            string response = this.QueryPrivate("WithdrawInfo", props);

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;


            WithdrawInfo info = JsonConvert.DeserializeObject<WithdrawInfo>(result.Result.ToString());
           
            
            return info;
        }

    }

    public class WithdrawInfo
    {
        /// <summary>
        /// name of deposit method
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

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
    }



}
