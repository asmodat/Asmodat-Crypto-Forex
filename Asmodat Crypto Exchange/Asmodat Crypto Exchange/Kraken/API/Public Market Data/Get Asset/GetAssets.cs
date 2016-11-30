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

    public partial class KrakenManager
    {


        
        public Asset[] GetAssets()
        {
            string response = QueryPublic("Assets");
            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            
            List<Asset> assets = new List<Asset>();
            foreach(JProperty property in result.Result.Children())
            {
                try
                {
                    Asset asset = JsonConvert.DeserializeObject<Asset>(property.Value.ToString());
                    asset.Name = property.Name;
                    assets.Add(asset);
                }
                catch
                {
                    continue;
                }
            }

            if (assets == null || assets.Count <= 0)
                return null;

            return assets.ToArray();
        }
    }




}
