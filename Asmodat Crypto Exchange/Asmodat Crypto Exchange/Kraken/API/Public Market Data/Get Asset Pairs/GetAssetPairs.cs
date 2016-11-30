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
using Asmodat.Extensions.Objects;
using Asmodat.Types;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Asmodat.Debugging;
using System.Threading;
using Asmodat.Extensions;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {
       public string[] GetAssetPairsNames()
        {
            AssetPair[] pairs = this.AssetPairs;
            if (pairs == null || pairs.Length <= 0)
            {
                pairs = this.GetAssetPairs();
            }

            if (pairs == null)  return null;
            List<string> list = new List<string>();

            foreach (var pair in pairs)
            {
                string name = Asmodat.Kraken.Kraken.ToPairString(pair.AssetBase, pair.AssetQuote);
                
                if (name.IsNullOrEmpty())
                    continue;

                if (!list.Contains(name))
                    list.Add(name);
            }

            return list.ToArray();
        }

    /// <summary>
    /// Get tradable asset pairs
    /// </summary>
    /// <returns></returns>
    public AssetPair[] GetAssetPairs()
        {

            string response = QueryPublic("AssetPairs");

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;
            
            List<AssetPair> values = new List<AssetPair>();
            foreach (JProperty property in result.Result.Children())
            {
                try
                {
                    AssetPair value = JsonConvert.DeserializeObject<AssetPair>(property.Value.ToString());
                    value.Name = property.Name;
                    values.Add(value);
                }
                catch(Exception ex)
                {
                    ex.ToOutput();
                    continue;
                }
            }

            return values.ToArray();
        }

    }



}
