using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmodat.Blockchain
{
    public partial class BlockchainManager
    {
        /// <summary>
        /// Whis is API base url to send requeststothe server: @"https://blockchain.info/merchant/"
        /// </summary>
        public string BaseURL { get; private set; } = @"https://blockchain.info/merchant/";

        /// <summary>
        /// My Wallet identifier, from login page
        /// </summary>
        public string GUID { get; private set; } = null;

        /// <summary>
        /// Your Main My wallet password
        /// </summary>
        public string PasswordMain { get; private set; } = null;

        /// <summary>
        /// Your second My Wallet password if double encryption is enabled.
        /// </summary>
        public string PasswordSecond { get; private set; } = null;


        /// <summary>
        /// Proxy used to send request to the server, set null to use default
        /// </summary>
        public string Proxy { get; private set; } = null;
        public string ProxyUsername { get; private set; } = null;
        public string ProxyPassword { get; private set; } = null;
        public bool UseProxy { get; private set; } = false;
        public bool UseProxyDefaultCredentials { get; private set; } = true;
    }
}
