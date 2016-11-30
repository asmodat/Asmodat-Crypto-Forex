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
using Asmodat.Extensions.Objects;
using Asmodat.Types;
using Asmodat.Debugging;
//using PennedObjects.RateLimiting;

using Asmodat.Extensions.Collections.Generic;
using Asmodat.Extensions;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {


        public bool IsBase(Kraken.Asset asset)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                throw new Exception("AssetPairs are not loaded.");

            for(int i = 0; i < AssetPairs.Length; i++)
            {
                var abase = AssetPairs[i].AssetBase;

                if (abase != null && abase.HasValue && abase.Value == asset)
                    return true;
            }

            return false;
        }

        public bool IsQuote(Kraken.Asset asset)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                throw new Exception("AssetPairs are not loaded.");

            for (int i = 0; i < AssetPairs.Length; i++)
            {
                var aquote = AssetPairs[i].AssetQuote;

                if (aquote != null && aquote.HasValue && aquote.Value == asset)
                    return true;
            }

            return false;
        }


        public string[] AssetPairsNames
        {
            get
            {
                try
                {
                    if (AssetPairs != null && AssetPairs.Length > 0)
                        return AssetPairs.NamesArray();
                }
                catch
                {

                }

                return null;
            }
        }

        public AssetPair[] AssetPairs { get; private set; }

        /// <summary>
        /// Searches and returns asset pair by name
        /// </summary>
        /// <param name="pairName"></param>
        /// <returns></returns>
        public AssetPair GetAssetPair(string pairName)
        {
            if (AssetPairs.IsNullOrEmpty())
                return null;

            for(int i = 0; i < AssetPairs.Length; i++)
            {
                AssetPair pair = AssetPairs[i];
                if (pair != null && pair.Name == pairName)
                    return pair;
            }

            return null;
        }


        public AssetPair GetAssetPairAny(Kraken.Asset? _assetFirst, Kraken.Asset? _assetSecond)
        {
            if (_assetFirst.IsNull() || _assetSecond.IsNull() || _assetFirst.ValueEquals(_assetSecond))
                return null;

            string pairFirst = Kraken.ToPairString(_assetFirst.Value, _assetSecond.Value);
            string pairSecond = Kraken.ToPairString(_assetSecond.Value, _assetFirst.Value);


            var resultFirs = this.GetAssetPair(pairFirst);
            if (resultFirs != null)
                return resultFirs;

            var resultSecond = this.GetAssetPair(pairSecond);
            if (resultSecond != null)
                return resultSecond;

            return null;
        }



        public TickTimeout TimeoutAssetPairs { get; private set; } = new TickTimeout(12, TickTime.Unit.h, TickTime.Default);
        

        public void InitializeAssetPairs()
        {
            if (!Timers.Contains("UpdateAssetPairs"))
                Timers.Run(() => TimrAssetPairs(), 5000, "UpdateAssetPairs", true, false);
        }


        public void TimrAssetPairs()
        {
            
            if (!TimeoutAssetPairs.IsTriggered)
                return;

            TimeoutAssetPairs.Forced = true;

            AssetPair[] pairs = null;

            try
            {
                pairs = this.GetAssetPairs();
            }
            catch (Exception ex)
            {
                ex.ToOutput();
                return;
            }

            if (pairs.IsNullOrEmpty())
                return;

            AssetPairs = pairs;
            TimeoutAssetPairs.Reset();
        }




    }
}
