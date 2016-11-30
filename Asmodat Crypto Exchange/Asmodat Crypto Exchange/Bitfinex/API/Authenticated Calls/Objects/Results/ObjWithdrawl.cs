using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Asmodat.BitfinexV1.API
{
    public class ObjWithdrawl
    {
        /// <summary>
        /// "success" or "error".
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Success or error message
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// ID of the withdrawal (0 if unsuccessful)
        /// </summary>
        public int withdrawal_id { get; set; }
    }
}
