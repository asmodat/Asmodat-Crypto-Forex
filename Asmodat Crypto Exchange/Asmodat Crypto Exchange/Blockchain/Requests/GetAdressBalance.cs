using Asmodat.Debugging;
using Asmodat.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;
using Asmodat.Extensions.Objects;
using Asmodat.Blockchain.API;

namespace Asmodat.Blockchain
{
    public partial class BlockchainManager
    {

        /// <summary>
        /// $main_password Your Main My wallet password
        /// $address The bitcoin address to lookup
        /// $confirmations Minimum number of confirmations required. 0 for unconfirmed.
        /// https://blockchain.info/merchant/$guid/address_balance?password=$main_password&address=$address&confirmations=$confirmations
        /// </summary>
        public string GetRequestURL_GetAdressBalance(string adress, int confirmations = 0)
        {
            if (adress.IsNullOrWhiteSpace() || confirmations < 0)
                throw new ArgumentException(string.Format("GetAdressBalance: Inavlid adress: {0}, or insufficient confirmations {1}", adress, confirmations));

            string result = string.Format(@"https://blockchain.info/merchant/{0}/address_balance?password={1}&address={2}&confirmations={3}", 
            GUID, 
            PasswordMain,
            adress,
            confirmations);

            return result;
        }


        /// <summary>
        /// Retrieve the balance of a bitcoin address. Querying the balance of an address by label is depreciated.
        /// {"balance" : Balance in Satoshi ,"address": "Bitcoin Address", "total_received" : Total Satoshi Received}
        /// https://blockchain.info/merchant/$guid/address_balance?password=$main_password&address=$address&confirmations=$confirmations
        /// </summary>
        public ObjAddress GetAdressBalance(string adress, int confirmations = 0)
        {
            try
            {
                string url = GetRequestURL_GetAdressBalance(adress, confirmations);
                string data = this.Request(url);
                ObjAddress obj = JsonConvert.DeserializeObject<ObjAddress>(data);

                return obj;
            }
            catch(Exception ex)
            {
                ex.ToOutput();
                return new ObjAddress() { error = ex.Message };
            }

        }

    }
}
