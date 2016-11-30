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
        public AccountBalance GetAccountWalletBalances()
        {
            ObjRequestWalletBalances variable = new ObjRequestWalletBalances(Nonce);
            string response = this.Request(variable, "GET");
            

            AccountBalance balance = AccountBalance.FromJson(response);

            return balance;
        }

        public AccountBalance GetAccountWalletBalanceRests()
        {
            ObjRequestWalletBalances variable = new ObjRequestWalletBalances(Nonce);
            string response = this.RestRequest(variable);
            AccountBalance balance = AccountBalance.FromJson(response);

            return balance;
        }

    }
}
