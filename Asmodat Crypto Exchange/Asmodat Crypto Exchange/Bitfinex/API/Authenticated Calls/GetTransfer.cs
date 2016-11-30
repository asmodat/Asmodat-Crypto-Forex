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

        // TODO: NOT TESTED

        /// <summary>
        /// Allow you to move available balances between your wallets.
        /// </summary>
        /// <param name="amount">Amount to transfer.</param>
        /// <param name="currency">Currency of funds to transfer.</param>
        /// <param name="walletfrom">Wallet to transfer from.</param>
        /// <param name="walletto">Wallet to transfer to.</param>
        /// <returns></returns>
        public ObjTransfer GetTransfer(decimal amount, ApiProperties.Currency currency, ApiProperties.WalletName walletfrom, ApiProperties.WalletName walletto)
        {
            return this.GetTransfer(amount, currency.GetEnumName(), walletfrom.GetEnumName(), walletto.GetEnumName());
        }

        /// <summary>
        /// Allow you to move available balances between your wallets.
        /// </summary>
        /// <param name="amount">Amount to transfer.</param>
        /// <param name="currency">Currency of funds to transfer.</param>
        /// <param name="walletfrom">Wallet to transfer from.</param>
        /// <param name="walletto">Wallet to transfer to.</param>
        /// <returns></returns>
        public ObjTransfer GetTransfer(decimal amount, string currency, string walletfrom, string walletto)
        {
            
            ObjRequestTransfer variable = new ObjRequestTransfer(Nonce, amount, currency, walletfrom, walletto);
            string response = this.Request(variable, "POST");

            ObjTransfer result = JsonConvert.DeserializeObject<ObjTransfer>(response);
            return result;
        }

       

    }
}
