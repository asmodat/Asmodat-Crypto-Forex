using Asmodat.Debugging;
using Asmodat.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asmodat.Abbreviate;
using Asmodat.Extensions.Objects;
using Asmodat.Blockchain.API;

namespace Asmodat.Blockchain
{
    public partial class BlockchainManager
    {


        /// <summary>
        /// $main_password Your Main My wallet password
        /// $second_password Your second My Wallet password if double encryption is enabled.
        /// $address The bitcoin address to unarchive
        /// https://blockchain.info/merchant/$guid/unarchive_address?password=$main_password&second_password=$second_password&address=$address
        /// </summary>
        public string GetRequestURL_UnarchiveAddress(string address = null)
        {
            string fsecondpass;
            string faddress;

            if (!PasswordSecond.IsNullOrWhiteSpace())
                fsecondpass = string.Format(@"&second_password={0}", PasswordSecond);
            else fsecondpass = null;

            if (!address.IsNullOrWhiteSpace())
                faddress = string.Format(@"&address={0}", address);
            else faddress = null;

            string result = string.Format(@"https://blockchain.info/merchant/{0}/unarchive_address?password={1}{2}{3}", 
            GUID, 
            PasswordMain,
            fsecondpass,
            faddress);

            return result;
        }


        /// <summary>
        /// Unarchive an address. Will also restore consolidated addresses (see below).
        /// Response: {"active" : "18fyqiZzndTxdVo7g9ouRogB4uFj86JJiy"}
        /// https://blockchain.info/merchant/$guid/unarchive_address?password=$main_password&second_password=$second_password&address=$address
        /// </summary>
        public ObjAddressUnarchived UnarchiveAddress(string address = null)
        {
            try
            {
                
                string url = GetRequestURL_UnarchiveAddress();
                string data = this.Request(url);
                ObjAddressUnarchived obj = JsonConvert.DeserializeObject<ObjAddressUnarchived>(data);

                return obj;
            }
            catch(Exception ex)
            {
                ex.ToOutput();
                return new ObjAddressUnarchived() { error = ex.Message };
            }

        }

    }
}
