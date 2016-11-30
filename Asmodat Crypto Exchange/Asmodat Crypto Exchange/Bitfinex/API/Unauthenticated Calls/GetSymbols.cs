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

        public List<string> GetSymbols()
        {

            ObjRequestSymbols variable = new ObjRequestSymbols(Nonce);
            string response = this.Request(variable, "GET");

            List<string> result = JsonConvert.DeserializeObject<List<string>>(response);

            return result;
        }

       

    }
}
