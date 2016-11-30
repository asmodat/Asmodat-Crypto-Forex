using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;
using Asmodat.Types;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{



    public class Asset
    {
       /* [JsonIgnore]
        public Kraken.Asset? AssetName
        {
            get
            {
                return Kraken.ToAsset(Name);
            }
        }
        */
        [JsonIgnore]
        public string Name { get; set; }

        /// <summary>
        /// asset class
        /// </summary>
        [JsonProperty(PropertyName = "aclass")]
        public string Class { get; set; }

        /// <summary>
        /// alternate name
        /// </summary>
        [JsonProperty(PropertyName = "altname")]
        public string AlternateName { get; set; }


        /// <summary>
        /// scaling decimal places for record keeping
        /// </summary>
        [JsonProperty(PropertyName = "decimals")]
        public int Decimals { get; set; }

        /// <summary>
        /// scaling decimal places for output display
        /// </summary>
        [JsonProperty(PropertyName = "display_decimals")]
        public int DisplayDecimals { get; set; }
    }


}
