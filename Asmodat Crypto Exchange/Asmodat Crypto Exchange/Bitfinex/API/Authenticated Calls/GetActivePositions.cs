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



        /// <summary>
        /// View your active positions.
        /// </summary>
        /// <returns>An array of your active positions.</returns>
        public int[] GetActivePositions()
        {

            ObjRequestActivePositions variable = new ObjRequestActivePositions(Nonce);
            string response = this.Request(variable, "POST");


            int[] result = JsonConvert.DeserializeObject<int[]>(response);
            return result;
        }

       

    }
}
