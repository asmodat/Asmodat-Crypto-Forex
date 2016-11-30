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
        /// $address The bitcoin address to archive
        /// https://blockchain.info/merchant/$guid/archive_address?password=$main_password&second_password=$second_password&address=$address
        /// </summary>
        public string GetRequestURL_ArchiveAddress(string address = null)
        {
            string fsecondpass;
            string faddress;

            if (!PasswordSecond.IsNullOrWhiteSpace())
                fsecondpass = string.Format(@"&second_password={0}", PasswordSecond);
            else fsecondpass = null;

            if (!address.IsNullOrWhiteSpace())
                faddress = string.Format(@"&address={0}", address);
            else faddress = null;

            string result = string.Format(@"https://blockchain.info/merchant/{0}/archive_address?password={1}{2}{3}", 
            GUID, 
            PasswordMain,
            fsecondpass,
            faddress);

            return result;
        }


        /// <summary>
        /// To improve wallet performance addresses which have not been used recently should be moved to an archived state. They will still be held in the wallet but will no longer be included in the "list" or "list-transactions" calls.
        /// For example if an invoice is generated for a user once that invoice is paid the address should be archived.
        /// Or if a unique bitcoin address is generated for each user, users who have not logged in recently (~30 days) their addresses should be archived.
        /// Response: {"archived" : "18fyqiZzndTxdVo7g9ouRogB4uFj86JJiy"}
        /// https://blockchain.info/merchant/$guid/archive_address?password=$main_password&second_password=$second_password&address=$address
        /// </summary>
        public ObjAddressArchived ArchiveAddress(string address = null)
        {
            try
            {
                
                string url = GetRequestURL_ArchiveAddress();
                string data = this.Request(url);
                ObjAddressArchived obj = JsonConvert.DeserializeObject<ObjAddressArchived>(data);

                return obj;
            }
            catch(Exception ex)
            {
                ex.ToOutput();
                return new ObjAddressArchived() { error = ex.Message };
            }

        }

    }
}
