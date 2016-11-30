using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Asmodat.BitfinexV1.API;
using Newtonsoft.Json;

using Asmodat.Abbreviate;
using Asmodat.Debugging;
using System.IO;

namespace Asmodat.BitfinexV1
{
    public partial class BitfinexManager
    {
        /// <summary>
        /// Return your deposit address to make a new deposit.
        /// </summary>
        /// <param name="method">Method of deposit (methods accepted: "bitcoin", "litecoin", "darkcoin", "mastercoin" (tethers)).</param>
        /// <param name="wallet_name">Wallet to deposit in (accepted: "trading", "exchange", "deposit"). Your wallet needs to already exist</param>
        /// <param name="renew">(optional) Default is false. If set to true, will return a new unused deposit address</param>
        /// <returns></returns>
        public ObjNewDeposit GetNewDeposit(
            ApiProperties.CurrencyName method, 
            ApiProperties.WalletName wallet_name, 
            bool renew = false)
        {

            int irenew = renew ? 1 : 0;

            ObjRequestNewDeposit variable = new ObjRequestNewDeposit(Nonce, method.GetEnumName(), wallet_name.GetEnumName(), irenew);
            string response = this.Request(variable, "POST");


            ObjNewDeposit result = JsonConvert.DeserializeObject<ObjNewDeposit>(response);
            
            return result;
        }

       

    }
}
