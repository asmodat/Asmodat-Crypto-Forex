using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Asmodat.BitfinexV1
{
    public partial class BitfinexManager
    {
        public BitfinexManager(string APIKey, string Secret)
        {
            this.APIKey = APIKey;
            this.Secret = Secret;
            this.HashProvider = new HMACSHA384(Encoding.UTF8.GetBytes(this.Secret));

            ServicePointManager.DefaultConnectionLimit = 1000;
        }

        

    }
}
