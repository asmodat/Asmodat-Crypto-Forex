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
        /// https://blockchain.info/merchant/$guid/list?password=$main_password
        /// </summary>
        public string GetRequestURL_ListingAdresses()
        {
            string result = string.Format(@"https://blockchain.info/merchant/{0}/list?password={1}", 
            GUID, 
            PasswordMain);

            return result;
        }


        /// <summary>
        /// Fetch the balance of a wallet. 
        /// This should be used as an estimate only and will include unconfirmed transactions and possibly double spends.
        /// https://blockchain.info/merchant/$guid/list?password=$main_password
        /// </summary>
        public ObjListingAddresses ListAdresses()
        {
            try
            {
                string url = GetRequestURL_ListingAdresses();
                string data = this.Request(url);
                ObjListingAddresses obj = JsonConvert.DeserializeObject<ObjListingAddresses>(data);

                return obj;
            }
            catch(Exception ex)
            {
                ex.ToOutput();
                return new ObjListingAddresses() { error = ex.Message };
            }

        }

    }
}
