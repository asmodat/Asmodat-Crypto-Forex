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
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{

    public class ObjResult
    {
        [JsonProperty(PropertyName = "error")]
        public ArrayList Error { get; set; }

        [JsonProperty(PropertyName = "result")]
        public JObject Result { get; set; }
    }

    public class ObjResultArray
    {
        [JsonProperty(PropertyName = "error")]
        public ArrayList Error { get; set; }

        [JsonProperty(PropertyName = "result")]
        public JArray Result { get; set; }
    }
}
