using Asmodat.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmodat.Blockchain.API
{

    public class CommonResponses
    {
        public List<string> ErrorList
        {
            get
            {
                return new List<string>()
                {
                    "Error Decrypting Wallet",
                    "Error decoding private key for address",
                    "Second password incorrect",
                    "You must provide an address and amount",
                    "Wallet Checksum did not validate. Serious error: Restore a backup if necessary.",
                    "Two factor authentication currently not enabled in the Merchant API",
                    "Label must be between 0 & 255 characters",
                    "Wallets are currently restricted to 5000 transactions",
                    "Wallet identifier not found",
                    "Uknown method"
                };
            }
        }

       
    }

}
