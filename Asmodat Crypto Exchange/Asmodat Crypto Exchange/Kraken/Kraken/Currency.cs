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

using Asmodat.Extensions.Objects;

namespace Asmodat.Kraken
{
    public static partial class KrakenEx
    {
        public static bool IsCurrency(this Kraken.Asset? asset)
        {
            if (asset == null) return false;
            return Kraken.IsCurrency(asset.GetEnumName());
        }

        public static bool IsCurrency(this Asset asset)
        {
            if (asset == null) return false;
            return Kraken.IsCurrency(asset.GetEnumName());
        }
    }


    public partial class Kraken
    {
        public enum Currency : int
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
        }

        public static bool IsCurrency(Asset? asset)
        {
            if (asset == null) return false;
            return IsCurrency(asset.Value.GetEnumName());
        }

        public static bool IsCurrency(string value)
        {
            var result = ToCurrency(value);
            if (result != null && result.HasValue && !result.Value.GetEnumName().IsNullOrWhiteSpace())
                return true;
            return false;
        }

        public static Currency? ToCurrency(Asset? value)
        {
            if (value == null || !value.HasValue)
                return null;

            return Kraken.ToCurrency(value.GetEnumName());
        }

        public static Currency ToCurrency(Asset value)
        {
            return Kraken.ToCurrency(value.GetEnumName()).Value;
        }

        public static Currency? ToCurrency(string value)
        {
            if (value == null)
                return null;

            value = value.ToLower().Replace(" ", "");

            foreach (Currency c in Enums.ToArray<Currency>())
            {
                string name = c.GetEnumName();
                string asset = "Z" + c.GetEnumName();
                string description = c.GetEnumDescription();

                name = name.ToLower().Replace(" ", "");
                asset = asset.ToLower().Replace(" ", "");
                description = description.ToLower().Replace(" ", "");

                if (value == name || value == asset || value == description)
                    return c;
            }

            return null;
        }

        public static Currency[] ToCurrency( Asset[] values)
        {
            if (values == null)
                return null;

            List<Currency> results = new List<Currency>();
            foreach (Asset a in values)
            {
                string name = a.GetEnumName();

                if (Kraken.IsCurrency(a))
                    results.Add(Kraken.ToCurrency(a));
            }

            return results.ToArray();
        }

        public static string ToString( Currency? value)
        {
            if (value == null || !value.HasValue)
                return null;
            else return value.Value.GetEnumName();
        }


    }
}
