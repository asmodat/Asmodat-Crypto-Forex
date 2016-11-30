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
        /// $second_password Your second My Wallet password if double encryption is enabled.
        /// $days Addresses which have not received any transactions in at least this many days will be consolidated.
        /// https://blockchain.info/merchant/$guid/auto_consolidate?password=$main_password&second_password=$second_password&days=$days
        /// </summary>
        public string GetRequestURL_ConsolidateAddress(int days)
        {
            if (days < 0)
                throw new ArgumentException(string.Format("ConsolidateAddress: Inavlid consolidation days count {0}", days));


            string fsecondpass;

            if (!PasswordSecond.IsNullOrWhiteSpace())
                fsecondpass = string.Format(@"&second_password={0}", PasswordSecond);
            else fsecondpass = null;


            string result = string.Format(@"https://blockchain.info/merchant/{0}/auto_consolidate?password={1}{2}&days={3}", 
            GUID, 
            PasswordMain,
            fsecondpass,
            days);

            return result;
        }


        /// <summary>
        /// Queries to wallets with over 10 thousand addresses will become sluggish especially in the web interface. 
        /// The auto_consolidate command will remove some inactive archived addresses from the wallet and insert them as forwarding addresses (see receive payments API). 
        /// You will still receive callback notifications for these addresses however they will no longer be part of the main wallet and will be stored server side.
        /// If generating a lot of addresses it is a recommended to call this method at least every 48 hours.
        /// A good value for days is 60 i.e.addresses which have not received transactions in the last 60 days will be consolidated.
        /// Response: { "consolidated" : ["18fyqiZzndTxdVo7g9ouRogB4uFj86JJiy"]}
        /// https://blockchain.info/merchant/$guid/auto_consolidate?password=$main_password&second_password=$second_password&days=$days
        /// </summary>
        public ObjAddressConsolidated ConsolidateAddress(int days)
        {
            try
            {
                string url = GetRequestURL_ConsolidateAddress(days);
                string data = this.Request(url);
                ObjAddressConsolidated obj = JsonConvert.DeserializeObject<ObjAddressConsolidated>(data);

                return obj;
            }
            catch(Exception ex)
            {
                ex.ToOutput();
                return new ObjAddressConsolidated() { error = ex.Message };
            }

        }

    }
}
