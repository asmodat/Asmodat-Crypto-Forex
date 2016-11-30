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
    public class ObjTotalActiveSwaps
    {
        /// <summary>
        /// Pair of the position
        /// </summary>
        public string position_pair { get; set; }
        /// <summary>
        /// Sum of the active swaps backing this position
        /// </summary>
        public decimal total_swaps { get; set; }

    }
}
