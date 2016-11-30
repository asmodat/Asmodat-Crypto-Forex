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

using Asmodat.Extensions;
using Asmodat.Extensions.Objects;
using Asmodat.Extensions.Collections.Generic;

namespace Asmodat.Kraken
{
    
    public partial class Kraken
    {
        /// <summary>
        /// this pair must be confirmed with ticker or assetpairs to be valid
        /// </summary>
        /// <param name="_base"></param>
        /// <param name="_quote"></param>
        /// <returns></returns>
        public static string ToPairString(Kraken.Asset _base, Kraken.Asset _quote)
        {
            string sbase = _base.GetEnumName();
            string squote = _quote.GetEnumName();

            if (sbase.IsNullOrEmpty() || squote.IsNullOrEmpty())
                return null;

            if (Kraken.IsCurrency(_base))
                sbase = "Z" + sbase;
            else if (Kraken.IsCryptocurrency(_base))
                sbase = "X" + sbase;

            if (Kraken.IsCurrency(_quote))
                squote = "Z" + squote;
            else if (Kraken.IsCryptocurrency(_quote))
                squote = "X" + squote;

            return sbase + squote;
        }

        public static string ToPairString(Kraken.Asset? _base, Kraken.Asset? _quote)
        {
            return ToPairString(_base.TryGetValue(), _quote.TryGetValue());
        }

        public static string ToPairString(AssetPair pair)
        {
            if (pair == null)
                return null;

            return ToPairString(pair.AssetBase, pair.AssetQuote);
        }


        public enum Asset : int
        {
            [Description("Euro")]
            EUR = 0,
            [Description("US Dollar")]
            USD,
            [Description("Pound Sterling")]
            GBP,
            [Description("Canadian Dollar")]
            CAD,
            [Description("Yen")]
            JPY,
            [Description("Bitcoin")]
            XBT,
            [Description("Ripple")]
            XRP,
            [Description("Stellar")]
            STR,
            [Description("Litecoin")]
            LTC,
            [Description("Namecoin")]
            NMC,
            [Description("Ven")]
            XVN,
            [Description("Dogecoin")]
            XDG,
            [Description("Ether")]
            ETH,
        }


        public static bool IsAsset(string value)
        {

            if (Kraken.IsCryptocurrency(value) || Kraken.IsCurrency(value))
                return true;

            return false;
        }

        public static Asset? ToAsset(string value)
        {
            if (value == null)
                return null;

            value = value.ToLower().Replace(" ", "");

            foreach (Asset a in Enums.ToArray<Asset>())
            {
                string name = a.GetEnumName();
                string currency = "Z" + a.GetEnumName();
                string cryptocurrency = "X" + a.GetEnumName();
                string description = a.GetEnumDescription();

                name = name.ToLower().Replace(" ", "");
                currency = currency.ToLower().Replace(" ", "");
                cryptocurrency = cryptocurrency.ToLower().Replace(" ", "");
                description = description.ToLower().Replace(" ", "");

                if (value == name || value == currency || value == cryptocurrency || value == description)
                    return a;
            }

            return null;
        }


        public static Asset[] ToAsset(string[] values)
        {
            if (values.IsNullOrEmpty())
                return null;

            List<Asset> list = new List<Asset>();
            foreach(string s in values)
            {
                var a = Kraken.ToAsset(s);
                list.AddValueDistinct(a);
            }
            
            return list.ToArray();
        }

        public static Asset ToAsset( Currency value)
        {
            return Kraken.ToAsset(value.GetEnumName()).Value;
        }

        public static Asset ToAsset( Cryptocurrency value)
        {
            return Kraken.ToAsset(value.GetEnumName()).Value;
        }


        public static Asset[] ToAsset( Currency[] values)
        {
            if (values == null)
                return null;

            List<Asset> results = new List<Asset>();
            foreach (Currency c in values)
            {
                var asset = Kraken.ToAsset(c.GetEnumName());
                if (asset != null && asset.HasValue)
                    results.Add(asset.Value);
            }

            return results.ToArray();
        }

        public static Asset[] ToAsset( Cryptocurrency[] values)
        {
            if (values == null)
                return null;

            List<Asset> results = new List<Asset>();
            foreach (Cryptocurrency cc in values)
            {
                var asset = Kraken.ToAsset(cc.GetEnumName());
                if (asset != null && asset.HasValue)
                    results.Add(asset.Value);
            }

            return results.ToArray();
        }


        public static string ToString(Asset? value)
        {
            if (value.IsNull())
                return null;
            else return value.Value.GetEnumName();
        }

        public static string[] ToString(Asset[] values)
        {
            if (values == null)
                return null;

            List<string> list = new List<string>();
            foreach(var a in values)
                list.AddIfValueIsNotNull(Kraken.ToString(a));
            
            return list.ToArray();
        }
    }
}
