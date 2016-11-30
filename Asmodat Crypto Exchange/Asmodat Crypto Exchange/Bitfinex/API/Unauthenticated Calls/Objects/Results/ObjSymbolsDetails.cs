using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using Asmodat.Types;

using Asmodat.Abbreviate;

namespace Asmodat.BitfinexV1.API
{
    public class ObjSymbolsDetails
    {
        /// <summary>
        /// the pair code
        /// </summary>
        public string pair { get; set; }
        /// <summary>
        /// Maximum number of significant digits for price in this pair
        /// </summary>
        public int price_precision { get; set; }
        /// <summary>
        /// Initial margin required to open a position in this pair
        /// </summary>
        public decimal initial_margin { get; set; }
        /// <summary>
        /// Minimal margin to maintain (in %)
        /// </summary>
        public decimal minimum_margin { get; set; }
        /// <summary>
        /// Maximum order size of the pair
        /// </summary>
        public decimal maximum_order_size { get; set; }
        /// <summary>
        /// Expiration date for limited contracts/pairs
        /// </summary>
        public string expiration { get; set; }


        
    }
}
