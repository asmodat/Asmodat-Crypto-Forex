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



    public class OrderResultDescriptionInfo
    {
        /// <summary>
        /// order description
        /// </summary>
        [JsonProperty(PropertyName = "order")]
        public string OrderDescription { get; set; }


        /// <summary>
        /// conditional close order description (if conditional close set)
        /// </summary>
        [JsonProperty(PropertyName = "close")]
        public string CloseOrderDescription { get; set; }
    }


    public class TransactionOrder
    {

        /// <summary>
        /// error
        /// </summary>
        [JsonIgnore]
        public string Error { get; set; }

        /// <summary>
        /// order description info
        /// </summary>
        [JsonProperty(PropertyName = "descr")]
        public OrderResultDescriptionInfo Info { get; set; }

        /// <summary>
        /// array of transaction ids for order (if order was added successfully)
        /// </summary>
        [JsonProperty(PropertyName = "txid")]
        public ArrayList Transactions { get; set; }
    }





}
