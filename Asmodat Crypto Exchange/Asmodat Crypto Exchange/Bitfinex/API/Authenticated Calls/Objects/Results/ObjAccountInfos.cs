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
    public class ObjAccountInfos
    {
        

        /// <summary>
        /// Your current fees for maker orders (limit orders not marketable, in percent)
        /// </summary>
        public decimal maker_fees { get; set; }

        /// <summary>
        /// Your current fees for taker orders (marketable order, in percent)
        /// </summary>
        public decimal taker_fees { get; set; }

        public ObjAccountInfo[] fees { get; set; }

    }
}
