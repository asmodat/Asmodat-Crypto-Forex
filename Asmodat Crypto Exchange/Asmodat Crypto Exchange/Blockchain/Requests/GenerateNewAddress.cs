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
        /// $label An optional label to attach to this address.It is recommended this is a human readable string e.g. "Order No : 1234". You May use this as a reference to check balance of an order (documented later)
        /// https://blockchain.info/merchant/$guid/new_address?password=$main_password&second_password=$second_password&label=$label
        /// </summary>
        public string GetRequestURL_GenerateNewAddress(string label = null)
        {
            string fsecondpass;
            string flabel;

            if (!PasswordSecond.IsNullOrWhiteSpace())
                fsecondpass = string.Format(@"&second_password={0}", PasswordSecond);
            else fsecondpass = null;

            if (!label.IsNullOrWhiteSpace())
                flabel = string.Format(@"&label={0}", label);
            else flabel = null;

            string result = string.Format(@"https://blockchain.info/merchant/{0}/new_address?password={1}{2}{3}", 
            GUID, 
            PasswordMain,
            fsecondpass,
            flabel);

            return result;
        }


        /// <summary>
        /// Result: { "address" : "The Bitcoin Address Generated" , "label" : "The Address Label"}
        /// https://blockchain.info/merchant/$guid/new_address?password=$main_password&second_password=$second_password&label=$label
        /// </summary>
        public ObjAddressGenerated GenerateNewAddress(string label = null)
        {
            try
            {
                string url = GetRequestURL_GenerateNewAddress();
                string data = this.Request(url);
                ObjAddressGenerated obj = JsonConvert.DeserializeObject<ObjAddressGenerated>(data);

                return obj;
            }
            catch(Exception ex)
            {
                ex.ToOutput();
                return new ObjAddressGenerated() { error = ex.Message };
            }

        }

    }
}
