using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Abbreviate;
using Asmodat.Types;
using System.ComponentModel;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{
    
    public partial class ApiProperties
    {
        public enum Pairs : int
        {
            [Description("XXBTZUSD")]
            BTCUSD = 0,
            [Description("XXBTZEUR")]
            BTCEUR,
            [Description("XLTCZUSD")]
            LTCUSD,
            [Description("XLTCZEUR")]
            LTCEUR,
        }

    }
}
