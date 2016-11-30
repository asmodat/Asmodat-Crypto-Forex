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
        
        public WithdrawStatus[] GetWithdrawStatus(string asset, string method, string aclass = "currency")
        {

            string props = string.Format("&asset={0}&method={1}", asset, method);

            if(!aclass.IsNullOrWhiteSpace())
                props = string.Format("&aclass={0}{1}", aclass, props);

            string response = this.QueryPrivate("WithdrawStatus", props);

            if (response == null)
                return null;

            ObjResultArray result = JsonConvert.DeserializeObject<ObjResultArray>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;

            List<WithdrawStatus> statusinfos = new List<WithdrawStatus>();
            foreach (JObject obj in result.Result)
            {
                try
                {
                    WithdrawStatus info = JsonConvert.DeserializeObject<WithdrawStatus>(obj.ToString());
                    statusinfos.Add(info);
                }
                catch(Exception ex)
                {
                    ex.ToOutput();
                    continue;
                }
            }
            
            return statusinfos.ToArray();
        }

    }

    public class WithdrawStatus
    {
        /// <summary>
        /// name of the withdrawal method used
        /// </summary>
        [JsonProperty(PropertyName = "method")]
        public string Name { get; set; }

        /// <summary>
        /// asset class
        /// </summary>
        [JsonProperty(PropertyName = "aclass")]
        public string AssetClass { get; set; }

        /// <summary>
        /// asset X-ISO4217-A3 code
        /// </summary>
        [JsonProperty(PropertyName = "asset")]
        public string Asset { get; set; }

        /// <summary>
        /// reference id
        /// </summary>
        [JsonProperty(PropertyName = "refid")]
        public string ReferenceID { get; set; }

        /// <summary>
        /// method transaction id
        /// </summary>
        [JsonProperty(PropertyName = "txid")]
        public string TransactionID { get; set; }

        /// <summary>
        /// method transaction information
        /// </summary>
        [JsonProperty(PropertyName = "info")]
        public string Info { get; set; }

        /// <summary>
        /// amount withdrawn
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public string Amount { get; set; }

        /// <summary>
        /// fees paid
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public string Fee { get; set; }

        /// <summary>
        /// unix timestamp when request was made
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public double time { get; set; }

        [JsonIgnore]
        public TickTime TickTime
        {
            get
            {
                if (time <= 0) return TickTime.Default;

                return TickTime.FromUnixTimeStamp(time);
            }
        }

        /// <summary>
        /// status of deposit
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// additional status properties (if available)
        /// </summary>
        [JsonProperty(PropertyName = "status-prop")]
        public WithdrawStatusProperties StatusProperties { get; set; }
    }

    /// <summary>
    /// status-prop = additional status properties (if available)
    /// </summary>
    public class WithdrawStatusProperties
    {
        /// <summary>
        /// cancelation requested
        /// </summary>
        [JsonProperty(PropertyName = "cancel-pending")]
        public string CancelPending { get; set; }

        /// <summary>
        /// canceled
        /// </summary>
        [JsonProperty(PropertyName = "canceled")]
        public string Canceled { get; set; }

        /// <summary>
        /// cancelation requested but was denied
        /// </summary>
        [JsonProperty(PropertyName = "cancel-denied")]
        public string CancelDenied { get; set; }

        /// <summary>
        /// a return transaction initiated by Kraken
        /// </summary>
        [JsonProperty(PropertyName = "return")]
        public string Return { get; set; }

        /// <summary>
        /// deposit is on hold pending review
        /// </summary>
        [JsonProperty(PropertyName = "onhold")]
        public string OnHold { get; set; }
    }

    /*
     = 
 = 
 = 
 = 
 = additional status properties (if available)
     = 
     = 
    */

}
