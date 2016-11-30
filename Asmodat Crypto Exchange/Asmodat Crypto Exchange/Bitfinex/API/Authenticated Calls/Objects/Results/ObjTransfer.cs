using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Asmodat.BitfinexV1.API
{
    public class ObjTransfer
    {
        /// <summary>
        /// "success" or "error".
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Success or error message
        /// </summary>
        public string message { get; set; }
    }
}
