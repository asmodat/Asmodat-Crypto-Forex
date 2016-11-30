using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Asmodat.Abbreviate;

namespace Asmodat.BitfinexV1.API
{
    public class ObjRequestTicker : ObjRequest
    {
        public ObjRequestTicker(
            string nonce, 
            ApiProperties.Symbols symbol)
        {
            this.nonce = nonce;
            this.request = ApiProperties.TickerRequestUrl + @"/" + symbol.GetEnumName(); 
        }
    }
}
