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
        /// Get the status of an offer. Is it active? Was it cancelled? To what extent has it been executed? etc.
        /// </summary>
        /// <param name="offer_id">The offer ID given by `/offer/new`.</param>
        /// <returns></returns>
        public ObjOfferStatus GetOfferStatus(int offer_id)
        {

            ObjRequestOfferStatus variable = new ObjRequestOfferStatus(Nonce, offer_id);
            string response = this.Request(variable, "POST");

            ObjOfferStatus result = JsonConvert.DeserializeObject<ObjOfferStatus>(response);
            return result;
        }

       

    }
}
