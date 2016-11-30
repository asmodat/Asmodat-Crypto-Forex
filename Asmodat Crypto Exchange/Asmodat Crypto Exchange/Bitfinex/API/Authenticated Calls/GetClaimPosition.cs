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
        /// Claim a position.
        /// A position can be claimed if:
        /// It is a long position: 
        /// 
        /// The amount in the last unit of the position pair that you have in your trading wallet 
        /// AND/OR the realized profit of the position is greater or equal to the purchase amount 
        /// of the position(base price* position amount) and the pending swap.
        /// For example, for a long BTCUSD position, you can claim the position if the amount of USD 
        /// you have in the trading wallet is greater than the base price* the position amount and the unrealized swap.
        /// 
        /// It is a short position: 
        /// The amount in the first unit of the position pair that you have in your trading wallet 
        /// is greater or equal to the amount of the position and the pending swap.
        /// </summary>
        /// <returns>The position ID given by `/positions`.</returns>
        public ObjClaimPosition GetClaimPosition(int position_id)
        {

            ObjRequestClaimPosition variable = new ObjRequestClaimPosition(Nonce, position_id);
            string response = this.Request(variable, "POST");


            ObjClaimPosition result = JsonConvert.DeserializeObject<ObjClaimPosition>(response);
            
            return result;
        }

       

    }
}
