using Asmodat.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmodat.Blockchain.API
{

    public class ObjOutgoingPayment
    {
        public string message { get; set; }
        public string tx_hash { get; set; }
        public string notice { get; set; }
        public string error { get; set; }
    }



}
