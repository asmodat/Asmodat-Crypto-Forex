using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Asmodat.BitfinexV1.API
{
    public class ObjRequestWalletBalances : ObjRequest
    {
        public ObjRequestWalletBalances(string nonce)
        {
            this.nonce = nonce;
            this.request = ApiProperties.WalletBalanceRequestUrl; 
        }
    }
}
