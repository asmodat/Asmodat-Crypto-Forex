using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Abbreviate;
using Asmodat.Types;
using Asmodat.Debugging;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {

        public Asset AssetInfo(string sasset)
        {
            return AssetInfo(Kraken.ToAsset(sasset));
        }

        public Asset AssetInfo(Kraken.Asset? asset)
        {
            if (asset == null || !asset.HasValue || AssetInfos == null || AssetInfos.Length <= 0)
                return null;
            
            for(int i = 0; i < AssetInfos.Length; i++)
            {
                Kraken.Asset? name = Kraken.ToAsset(AssetInfos[i].Name);

                if (name == null || !name.HasValue || name.Value != asset.Value)
                    continue;

                return AssetInfos[i];
            }

            return null;
        }

        public Asset[] AssetInfos { get; private set; }


        public TickTimeout TimeoutAssetInfos { get; private set; } = new TickTimeout(12, TickTime.Unit.h, TickTime.Default);
        

        public void InitializeAssetInfos()
        {
            if (!Timers.Contains("UpdateAssetInfos"))
                Timers.Run(() => TimrAssetInfos(), 5000, "UpdateAssetInfos", true, false);
        }


        public void TimrAssetInfos()
        {
            
            if (!TimeoutAssetInfos.IsTriggered)
                return;

            TimeoutAssetInfos.Forced = true;

            Asset[] assets = null;

            try
            {
                assets = this.GetAssets();
            }
            catch (Exception ex)
            {
                ex.ToOutput();
                return;
            }

            if (assets == null || assets.Length <= 0)
                return;

            AssetInfos = assets;
            TimeoutAssetInfos.Reset();
        }




    }
}
