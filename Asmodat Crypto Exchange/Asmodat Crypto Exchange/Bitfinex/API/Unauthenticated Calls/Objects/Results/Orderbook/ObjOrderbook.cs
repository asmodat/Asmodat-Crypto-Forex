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
    public class ObjOrderbook
    {

        public ObjOrderbookBid[] bids { get; set; }
        

        public ObjOrderbookAsk[] asks { get; set; }

        
    }
}
