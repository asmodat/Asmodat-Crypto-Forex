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
using Asmodat.Debugging;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {


        /// <summary>
        /// Get public server time
        /// This is to aid in approximatig the skew time between the server and client
        /// </summary>
        /// <returns></returns>
        public TickTime GetServerTime()
        {
            string response = null;
            try
            {
                response = QueryPublic("Time");
            }
            catch(Exception ex)
            {
                ex.ToOutput();
                return TickTime.Default;
            }

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);
            ObjServerTime servertime = JsonConvert.DeserializeObject<ObjServerTime>(result.Result.ToString());

            return servertime.TickTime;
        }


    }

    public class ObjServerTimeResult
    {
        [JsonProperty(PropertyName = "error")]
        public ArrayList error { get; set; }

        [JsonProperty(PropertyName = "result")]
        public ObjServerTime result { get; set; }
    }

    public class ObjServerTime
    {
        [JsonProperty(PropertyName = "unixtime")]
        public double unixtime { get; set; }

        [JsonProperty(PropertyName = "rfc1123")]
        public string rfc1123 { get; set; }


        [JsonIgnore]
        public TickTime TickTime
        {
            get
            {
                if (unixtime <= 0) return TickTime.Default;

                return TickTime.FromUnixTimeStamp(unixtime);
            }
        }
    }
}
