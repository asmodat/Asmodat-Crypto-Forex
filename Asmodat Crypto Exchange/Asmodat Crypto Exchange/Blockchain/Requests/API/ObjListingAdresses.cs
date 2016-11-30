using Asmodat.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmodat.Blockchain.API
{
    public class ObjAddress
    {
        public string balance { get; set; }
        public string address { get; set; }
        public string label { get; set; }
        public long total_received { get; set; }
        public string error { get; set; }
    }

    public class ObjListingAddresses
    {
        public ObjAddress[] addresses { get; set; }
        public string error { get; set; }
    }

}
