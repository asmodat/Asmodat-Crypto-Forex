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
        /// <summary>
        /// Withdraw funds
        /// </summary>
        /// <param name="asset">asset being withdrawn</param>
        /// <param name="key">withdrawal key name, as set up on your account</param>
        /// <param name="amount">amount to withdraw, including fees</param>
        /// <param name="aclass">asset class (optional): currency(default)</param>
        /// <returns></returns>
        public Withdraw GetWithdraw(string asset, string key, decimal amount, string aclass = "currency")
        {
            string props = string.Format("&asset={0}&key={1}&amount={2}&aclass={3}", asset, key, amount, aclass);

            string response = this.QueryPrivate("Withdraw", props);

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;


            Withdraw withdraw = JsonConvert.DeserializeObject<Withdraw>(result.Result.ToString());
           
            
            return withdraw;
        }

    }

    public class Withdraw
    {
        /// <summary>
        /// reference id
        /// </summary>
        [JsonProperty(PropertyName = "refid")]
        public string ReferenceID { get; set; }
    }



}
