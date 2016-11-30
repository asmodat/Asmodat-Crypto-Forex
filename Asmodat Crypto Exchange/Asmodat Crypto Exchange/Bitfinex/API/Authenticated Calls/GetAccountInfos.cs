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
        
        public ObjAccountInfos GetAccountInfos()
        {

            ObjRequestAccountInfos variable = new ObjRequestAccountInfos(Nonce);
            string response = this.Request(variable, "POST");


           ObjAccountInfos result = JsonConvert.DeserializeObject<List<ObjAccountInfos>>(response)[0];
            
            return result;
        }

       

    }
}
