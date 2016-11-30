using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Types;
using System.ComponentModel;
//using PennedObjects.RateLimiting;

using Asmodat.Extensions;
using Asmodat.Extensions.Collections.Generic;
using Asmodat.Extensions.Objects;

using Asmodat.Abbreviate;

namespace Asmodat.Kraken
{

    public partial class Kraken
    {


        /// <summary>
        /// Returns Base,Quote asset touple
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Tuple<Asset, Asset> ToAssetTouple(string value)
        {
            if (value.IsNullOrWhiteSpace())
                return null;

            value = value.Trim();

            if (value.Length < 6)
                return null;

            string _base = null;
            string _quote = null;


            if (value.CountChars(' ') == 1)
            {
                string[] split = value.Split(' ');
                if (split.IsNullOrEmpty() || split.Length != 2)
                    return null;

                _base = split[0];
                _quote = split[1];
            }
            else if (value.Length == 6)
            {
                _base = value.GetFirst(3);
                _quote = value.GetLast(3);
            }
            else if (value.Length == 8)
            {
                _base = value.GetFirst(4);
                _quote = value.GetLast(4);
            }

            var ab = Kraken.ToAsset(_base);
            var aq = Kraken.ToAsset(_quote);

            if (!ab.IsNull() && !aq.IsNull())
                return new Tuple<Asset, Asset>(ab.Value, aq.Value);

            return null;
        }

        /// <summary>
        /// Returns Base,Quote asset touples
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Tuple<Asset, Asset>[] ToAssetTouple(string[] values)
        {
            if (values.IsNullOrEmpty())
                return null;

            List<Tuple<Asset, Asset>> list = new List<Tuple<Asset, Asset>>();
            foreach (string s in values)
                list.AddIfValueIsNotNull(Kraken.ToAssetTouple(s));
            
            return list.ToArray();
        }

        public enum AssetToupleFormat
        {
            /// <summary>
            /// BASQUO
            /// </summary>
            Names = 0,
            /// <summary>
            /// BAS QUO
            /// </summary>
            NamesSeparated = 1,
            /// <summary>
            /// BaseQuote
            /// </summary>
            Descriptions = 2,
            /// <summary>
            /// Base Quote
            /// </summary>
            DescriptionsSeparated = 3,
            /// <summary>
            /// (X/Z)BAS(X/Z)QUO
            /// </summary>
            CurrencyNames = 4,
            /// <summary>
            /// (X/Z)BAS (X/Z)QUO
            /// </summary>
            CurrencyNamesSeparated = 5,
        }

        public static string ToString(Tuple<Asset, Asset> values, AssetToupleFormat format = AssetToupleFormat.NamesSeparated)
        {
            if (values == null) return null;

            Asset _base = values.Item1;
            Asset _quote = values.Item2;
            string sb = _base.GetEnumName();
            string sq = _quote.GetEnumName();
            string sbd = _base.GetEnumDescription();
            string sqd = _quote.GetEnumDescription();
            string sbc = IsCurrency(_base) ? "Z" + sb : "X" + sb;
            string sqc = IsCurrency(_quote) ? "Z" + sq : "X" + sq;

            if (format == AssetToupleFormat.Names)
                return (string.Format("{0}{1}", sb, sq));
            else if (format == AssetToupleFormat.NamesSeparated)
                return (string.Format("{0} {1}", sb, sq));
            else if (format == AssetToupleFormat.Descriptions)
                return (string.Format("{0}{1}", sbd, sqd));
            else if (format == AssetToupleFormat.DescriptionsSeparated)
                return (string.Format("{0} {1}", sbd, sqd));
            else if(format == AssetToupleFormat.CurrencyNames)
                return (string.Format("{0}{1}", sbc, sqc));
            else if (format == AssetToupleFormat.CurrencyNamesSeparated)
                return (string.Format("{0} {1}", sbc, sqc));
            else return null;
            
        }

        public static string[] ToString(Tuple<Asset, Asset>[] values, AssetToupleFormat format = AssetToupleFormat.NamesSeparated)
        {
            if (values.IsNullOrEmpty())
                return null;

            List<string> list = new List<string>();
            foreach (var v in values)
                list.AddIfValueIsNotNull(Kraken.ToString(v, format));
            
            return list.ToArray();
        }


    }
}
