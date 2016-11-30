using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Asmodat.Types;

using System.Web;
using Newtonsoft.Json;

namespace Asmodat.BitfinexV1.API
{
    public class ObjResponse : ObjResult
    {
        
        public string response { get; set; }

    }
}
