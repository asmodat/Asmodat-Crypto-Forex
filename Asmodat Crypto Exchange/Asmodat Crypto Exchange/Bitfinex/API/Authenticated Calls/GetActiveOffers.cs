using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Asmodat.BitfinexV1.API;
using Newtonsoft.Json;

using Asmodat.Abbreviate;
using Asmodat.Debugging;
using System.IO;

namespace Asmodat.BitfinexV1
{
    public partial class BitfinexManager
    {
        // TODO: NOT TESTED

        /// <summary>
        /// View your active offers.
        /// </summary>
        /// <returns>An array of the results of `/offer/status` for all your live offers (lending or borrowing)</returns>
        public ObjOfferStatus[] GetActiveOffers()
        {

            ObjRequestActiveOffers variable = new ObjRequestActiveOffers(Nonce);
            string response = this.Request(variable, "POST");

            ObjOfferStatus[] result = JsonConvert.DeserializeObject<ObjOfferStatus[]>(response);
            return result;
        }

       

    }
}
