using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using Asmodat.Types;

namespace Asmodat.BitfinexV1.API
{
    public class ObjLendbook
    {
        /// <summary>
        /// [array of loan demands]
        /// </summary>
        public ObjLendbookBid[] bids { get; set; }
        
        /// <summary>
        /// [array of loan offers]
        /// </summary>
        public ObjLendbookAsk[] asks { get; set; }

        
    }
}
