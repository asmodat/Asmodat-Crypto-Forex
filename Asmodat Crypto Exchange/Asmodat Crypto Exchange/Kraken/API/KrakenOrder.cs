using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmodat.Kraken
{
    
 
    public enum KrakenOrderStatus
    { 
        pending=1, // order pending book entry
        open = 2, // open order
        closed = 3, //cosed order
        canceled = 4, // order canceled
        expired =5 // order expired
    }


}
