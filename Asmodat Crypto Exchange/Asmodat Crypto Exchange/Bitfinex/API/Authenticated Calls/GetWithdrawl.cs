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
        /// Allow you to request a withdrawal from one of your wallet.
        /// </summary>
        /// <param name="withdraw_type">can be "bitcoin", "litecoin" or "darkcoin" or "tether".</param>
        /// <param name="walletselected">The wallet to withdraw from, can be "trading", "exchange", or "deposit".</param>
        /// <param name="amount">Amount to withdraw.</param>
        /// <param name="address">Destination address for withdrawal.</param>
        /// <returns></returns>
        public ObjWithdrawl GetWithdrawl(ApiProperties.WithdrawType withdraw_type, ApiProperties.WalletName walletselected, decimal amount, string address)
        {
            return this.GetWithdrawl(withdraw_type.GetEnumName(), walletselected.GetEnumName(), amount.ToString(), address);
        }

        /// <summary>
        /// Allow you to request a withdrawal from one of your wallet.
        /// </summary>
        /// <param name="withdraw_type">can be "bitcoin", "litecoin" or "darkcoin" or "tether".</param>
        /// <param name="walletselected">The wallet to withdraw from, can be "trading", "exchange", or "deposit".</param>
        /// <param name="amount">Amount to withdraw.</param>
        /// <param name="address">Destination address for withdrawal.</param>
        /// <returns></returns>
        public ObjWithdrawl GetWithdrawl(string withdraw_type, string walletselected, string amount, string address)
        {

            ObjRequestWithdrawl variable = new ObjRequestWithdrawl(Nonce, withdraw_type, walletselected, amount, address);
            string response = this.Request(variable, "POST");

            ObjWithdrawl result = JsonConvert.DeserializeObject<ObjWithdrawl[]>(response)[0];
            return result;
        }

       

    }
}
