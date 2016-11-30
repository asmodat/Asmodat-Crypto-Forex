using Asmodat.Debugging;
using Asmodat.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asmodat.Abbreviate;
using Asmodat.Blockchain.API;

namespace Asmodat.Blockchain
{
    public partial class BlockchainManager
    {

        /// <summary>
        /// Unconfirmed Wallet Balance in Satoshi
        /// </summary>
        public long UnconfirmedWalletBalance { get; private set; } = 0;



        /// <summary>
        /// https://blockchain.info/merchant/$guid/balance?password=$main_password
        /// </summary>
        public string GetRequestURL_FetchWalletBalance()
        {
            string result = string.Format(@"https://blockchain.info/merchant/{0}/balance?password={1}", 
            GUID, 
            PasswordMain);

            return result;
        }


        /// <summary>
        /// Fetch the balance of a wallet. 
        /// This should be used as an estimate only and will include unconfirmed transactions and possibly double spends.
        /// Response: { "balance": Wallet Balance in Satoshi }
        /// https://blockchain.info/merchant/$guid/balance?password=$main_password
        /// </summary>
        public ObjWalletBalance FetchWalletBalance()
        {
            try
            {
                string url = GetRequestURL_FetchWalletBalance();
                string data = this.Request(url);
                ObjWalletBalance obj = JsonConvert.DeserializeObject<ObjWalletBalance>(data);

                return obj;
            }
            catch(Exception ex)
            {
                ex.ToOutput();
                return new ObjWalletBalance() { balance = 0, error = ex.Message };
            }

        }

    }
}
