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
using Asmodat.Debugging;
//using PennedObjects.RateLimiting;

using Asmodat.Extensions;
using Asmodat.Extensions.Collections.Generic;

namespace Asmodat.Kraken
{
    public static class AssetPairEx
    {
        /// <summary>
        /// Returns all assets that are complementary for specified asset
        /// </summary>
        /// <param name="pairs"></param>
        /// <param name="asset"></param>
        /// <returns></returns>
        public static Kraken.Asset[] GetComplementaryAssets(this AssetPair[] pairs, Kraken.Asset? asset)
        {
            if (pairs == null || asset.IsNull())
                return null;

            List<Kraken.Asset> assets = new List<Kraken.Asset>();
            foreach (var pair in pairs)
                assets.AddIfValueIsNotNull(pair.GetComplementaryAsset(asset));

            return assets.ToArray();
        }

        /// <summary>
        /// Returns complementary asset: 
        /// If asset is base then quote is returned, if asset is quote, then base is returnet
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="asset"></param>
        /// <returns></returns>
        public static Kraken.Asset? GetComplementaryAsset(this AssetPair pair, Kraken.Asset? asset)
        {
            if (pair == null || pair.AssetQuote.IsNull() || pair.AssetBase.IsNull() || asset.IsNull())
                return null;

            if (pair.IsBase(asset.Value))
                return pair.AssetQuote.Value;
            else if (pair.IsQuote(asset.Value))
                return pair.AssetBase.Value;

            return null;
        }




        /// <summary>
        /// Checks if asset is a base asset of assetpair
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="asset"></param>
        /// <returns></returns>
        public static bool IsBase(this AssetPair pair, Kraken.Asset? asset)
        {
            if (pair != null && pair.AssetBase.ValueEquals(asset))
                return true;
            else return false;
        }

        public static bool IsQuote(this AssetPair pair, Kraken.Asset? asset)
        {
            if (pair != null && pair.AssetQuote.ValueEquals(asset))
                return true;
            else return false;
        }

        public static bool IsPair(this AssetPair pair, Kraken.Asset _base, Kraken.Asset _quote)
        {
            if (pair.IsBase(_base) && pair.IsQuote(_quote))
                return true;
            else return false;
        }

        public static bool IsAssets(this AssetPair pair, Kraken.Asset _assetFirst, Kraken.Asset _assetSecond)
        {
            if (pair.IsPair(_assetFirst, _assetSecond) || pair.IsPair(_assetSecond, _assetFirst))
                return true;
            else return false;
        }

        public static List<string> NamesList(this List<AssetPair> pairs)
        {
            if (pairs == null)
                return null;

            List<string> result = new List<string>();
            foreach (AssetPair pair in pairs)
                result.Add(pair.Name);

            return result;
        }

        public static string[] NamesArray(this AssetPair[] pairs)
        {
            if (pairs == null)
                return null;

            List<string> result = new List<string>();
            foreach (AssetPair pair in pairs)
                result.Add(pair.Name);

            return result.ToArray();
        }

        public static List<string> NamesList(this AssetPair[] pairs)
        {
            if (pairs == null)
                return null;

            return AssetPairEx.NamesList(pairs.ToList());
        }

        public static string[] NamesArray(this List<AssetPair> pairs)
        {
            if (pairs == null)
                return null;

            return AssetPairEx.NamesArray(pairs.ToArray());
        }


        public static AssetPair GetAny(this AssetPair[] pairs, Kraken.Asset _assetFirst, Kraken.Asset _assetSecond)
        {
            if (pairs == null || pairs.Length <= 0)
                return null;

            foreach (AssetPair pair in pairs)
            {
                if (pair == null)
                    continue;

                if (pair.IsAssets(_assetFirst, _assetSecond))
                    return pair;
            }

            return null;
        }

        public static AssetPair Get(this AssetPair[] pairs, Kraken.Asset _base, Kraken.Asset _quote)
        {
            if (pairs == null || pairs.Length <= 0)
                return null;

            foreach (AssetPair pair in pairs)
            {
                if (pair == null)
                    continue;

                if (pair.IsPair(_base, _quote))
                    return pair;
            }

            return null;
        }

        public static AssetPair Get(this AssetPair[] pairs, Ticker ticker)
        {
            if (pairs == null || pairs.Length <= 0 || ticker == null || ticker.AssetBase == null || ticker.AssetQuote == null)
                return null;

            return pairs.Get(ticker.AssetBase.Value, ticker.AssetQuote.Value);
        }

    }
}
