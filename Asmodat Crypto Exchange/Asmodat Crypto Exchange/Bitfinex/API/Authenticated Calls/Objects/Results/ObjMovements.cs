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
    public class ObjMovements
    {
      
        public string currency { get; set; }
        public string method { get; set; }
        public string type { get; set; }
        /// <summary>
        /// Absolute value of the movement
        /// </summary>
        public decimal amount { get; set; }
        /// <summary>
        /// Description of the movement (txid, destination address,,,,)
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// Status of the movement
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Timestamp of the movement
        /// </summary>
        public double timestamp { get; set; }

        [JsonIgnore]
        public TickTime TickTime
        {
            get { return TickTime.FromUnixTimeStamp(timestamp); }
        }
    }
}
