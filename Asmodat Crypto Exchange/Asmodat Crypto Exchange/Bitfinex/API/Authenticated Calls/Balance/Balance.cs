using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Asmodat.BitfinexV1.API
{
    public class Balance
    {
        public decimal AvailableBTC { get; set; }
        public decimal AvailableUSD { get; set; }
        public decimal BTC { get; set; }
        public decimal USD { get; set; }
    }



}
