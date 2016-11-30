using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Asmodat.Types;

using System.Web;
using Newtonsoft.Json;

namespace Asmodat.BitfinexV1.API
{
    public class ObjNewDeposit
    {
        /// <summary>
        /// "success" or "error"
        /// </summary>
        public string result { get; set; }
        public string method { get; set; }
        public string currency { get; set; }
        /// <summary>
        /// The deposit address (or error message if result = "error")
        /// </summary>
        public string address { get; set; }

    }
}
