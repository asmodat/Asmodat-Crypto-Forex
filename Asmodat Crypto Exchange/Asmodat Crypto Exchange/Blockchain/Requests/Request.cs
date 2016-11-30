using Asmodat.Debugging;
using Asmodat.Networking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asmodat.Abbreviate;

namespace Asmodat.Blockchain
{
    public partial class BlockchainManager
    {
       
        public string Request(string url)
        {
            string data;
            if (!UseProxy)
                data = WebClients.DownloadString(url);
            else
                data = WebClients.DownloadString(url, Proxy, ProxyUsername, ProxyPassword, UseProxyDefaultCredentials, null);

            return data;
        }


        

    }
}
