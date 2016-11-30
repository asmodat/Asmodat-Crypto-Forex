using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using Asmodat.Types;

using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;
using Asmodat.Extensions.Objects;

namespace Asmodat.BitfinexV1.API
{
    public class ObjLendbookBid
    {
        /// <summary>
        /// [rate in % per 365 days]
        /// </summary>
        public double rate { get; set; }
        public decimal amount { get; set; }
        /// <summary>
        /// minimum period for the loan in days
        /// </summary>
        public int period { get; set; }

        public double timestamp { get; set; }

        /// <summary>
        /// "Yes" if the offer is at Flash Return Rate, "No" if the offer is at fixed rate
        /// </summary>
        public string frr { get; set; }

        [JsonIgnore]
        public bool IsAtFlashReturnRate
        {
            get
            {
                if (frr.IsNullOrWhiteSpace())
                    return false;

                if (frr.ToLower() == "yes")
                    return true;

                return false;
            }
        }

        [JsonIgnore]
        public bool IsAtFixedRate
        {
            get
            {
                if (frr.IsNullOrWhiteSpace())
                    return false;

                if (frr.ToLower() == "no")
                    return true;

                return false;
            }
        }

        [JsonIgnore]
        public TickTime TickTime
        {
            get { return TickTime.FromUnixTimeStamp(timestamp); }
        }
    }
}
