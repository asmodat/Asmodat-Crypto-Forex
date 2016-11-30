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
using System.ComponentModel;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {

        /// <summary>
        /// Cancel open order
        /// </summary>
        /// <param name="txid">txid = transaction id</param>
        /// <returns></returns>
        public CancelOrderInfo CancelOrder(string txid)
        {
           
            string props = string.Format("&txid={0}", txid);
            

            string response = this.QueryPrivate("CancelOrder", props);

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;

            CancelOrderInfo info = JsonConvert.DeserializeObject<CancelOrderInfo>(result.Result.ToString());

            return info;
        }


        
    }



    public class CancelOrderInfo
    {
        /// <summary>
        /// number of orders canceled
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        /// <summary>
        /// if set, order(s) is/are pending cancellation
        /// </summary>
        [JsonProperty(PropertyName = "pending")]
        public bool IsPending { get; set; }
    }




    }
