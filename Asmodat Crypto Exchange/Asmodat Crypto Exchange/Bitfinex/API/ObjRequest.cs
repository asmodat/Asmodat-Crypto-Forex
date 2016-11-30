using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;

namespace Asmodat.BitfinexV1.API
{
    public class ObjRequest
    {
        public string request { get; set; }

        /// <summary>
        /// The nonce provided must be strictly increasing.
        /// </summary>
        [JsonProperty("nonce")]
        public string nonce { get; set; }

        [JsonProperty("options")]
        public ArrayList options { get; set; } = new ArrayList();

    }
}
