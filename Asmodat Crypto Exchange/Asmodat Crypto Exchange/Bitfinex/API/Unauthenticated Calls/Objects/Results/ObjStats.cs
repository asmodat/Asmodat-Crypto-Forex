using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Asmodat.BitfinexV1.API
{
    public class ObjStats
    {
        /// <summary>
        /// period covered in days
        /// </summary>
        public int period { get; set; }

        public decimal volume { get; set; }
    }
}
