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
    
    public partial class Kraken
    {
        public enum Cryptocurrency : int
        {
            [Description("Bitcoin")]
            XBT = 0,
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

        public static bool IsCryptocurrency(Asset? asset)
        {
            if (asset == null) return false;
            return IsCryptocurrency(asset.Value.GetEnumName());
        }

        public static bool IsCryptocurrency(string value)
        {
            var result = ToCryptocurrency(value);
            if (result != null && result.HasValue && !result.Value.GetEnumName().IsNullOrWhiteSpace())
                return true;
            return false;
        }

        public static Cryptocurrency ToCryptocurrency( Asset value)
        {
            return Kraken.ToCryptocurrency(value.GetEnumName()).Value;
        }

        public static Cryptocurrency? ToCryptocurrency(string value)
        {
            if (value == null)
                return null;

            value = value.ToLower().Replace(" ", "");

            foreach (Cryptocurrency c in Enums.ToArray<Cryptocurrency>())
            {
                string name = c.GetEnumName();
                string asset = "X" + c.GetEnumName();
                string description = c.GetEnumDescription();

                name = name.ToLower().Replace(" ", "");
                asset = asset.ToLower().Replace(" ", "");
                description = description.ToLower().Replace(" ", "");

                if (value == name || value == asset || value == description)
                    return c;
            }

            return null;
        }

        public static Cryptocurrency[] ToCryptocurrency( Asset[] values)
        {
            if (values == null)
                return null;

            List<Cryptocurrency> results = new List<Cryptocurrency>();
            foreach (Asset a in values)
            {
                string name = a.GetEnumName();

                if (Kraken.IsCryptocurrency(a))
                    results.Add(Kraken.ToCryptocurrency(a));
            }

            return results.ToArray();
        }

        public static string ToString( Cryptocurrency? value)
        {
            if (value == null || !value.HasValue)
                return null;
            else return value.Value.GetEnumName();
        }

    }
}
