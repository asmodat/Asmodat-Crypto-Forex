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
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{



    public static class AssetSEx
    {
        public static int GetDisplayDecimals(this Asset asset, int min = 2)
        {
            int decimals = min;

            
            if (asset != null && asset.DisplayDecimals > min)
                decimals = asset.DisplayDecimals;

            return decimals;
        }
    }


}
