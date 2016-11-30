using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace Asmodat.BitfinexV1
{
    public partial class BitfinexManager
    {

        /// <summary>
        /// The number of requests per second that is limited
        /// </summary>
        public int RequestLimit { get; private set; } = 60;

        public decimal OrderMinimumBTCUSD { get; private set; } = 0.01M;
        public decimal OrderMinimumLTCBTC { get; private set; } = 0.1M;
        public decimal OrderMinimumLTCUSD { get; private set; } = 0.1M;

        public decimal OrderMaximumTCUSD { get; private set; } = 2000.0M;
        public decimal OrderMaximumLTCBTC { get; private set; } = 5000.0M;
        public decimal OrderMaximumLTCUSD { get; private set; } = 5000.0M;

        private HMACSHA384 HashProvider { get; set; }
        

        private string APIKey { get; set; }
        private string Secret { get; set; }
        

        private int nonce { get; set; } = 0;

        private string Nonce
        {
            get
            {
                if (nonce == 0)
                {
                    nonce = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                }

                return (nonce++).ToString();
            }
        }
    }
}
