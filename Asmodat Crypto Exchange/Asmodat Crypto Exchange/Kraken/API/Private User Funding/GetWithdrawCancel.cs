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

        public WithdrawCancel GetWithdrawCancel(string asset, string refid, string aclass = "currency")
        {

            string props = string.Format("&asset={0}&refid={1}", asset, refid);

            if (!aclass.IsNullOrWhiteSpace())
                props = string.Format("&aclass={0}{1}", aclass, props);

            string response = this.QueryPrivate("WithdrawCancel", props);

            if (response == null)
                return null;

            ObjResultArray result = JsonConvert.DeserializeObject<ObjResultArray>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;

            /*List<WithdrawStatus> statusinfos = new List<WithdrawStatus>();
            foreach (JObject obj in result.Result)
            {
                try
                {
                    WithdrawStatus info = JsonConvert.DeserializeObject<WithdrawStatus>(obj.ToString());
                    statusinfos.Add(info);
                }
                catch (Exception ex)
                {
                    ex.ToOutput();
                    continue;
                }
            }

            return statusinfos.ToArray();*/
            return null;
        }

    }

    public class WithdrawCancel
    {
        /// <summary>
        /// Result: true on success
        /// </summary>
        [JsonProperty(PropertyName = "result")]
        public bool Success { get; set; } = false;

        
    }

}
