using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using Asmodat.Abbreviate;using Asmodat.Extensions.Objects;
using Asmodat.Types;
using System.ComponentModel;
//using PennedObjects.RateLimiting;

namespace Asmodat.Kraken
{
    
    public partial class KrakenManager
    {
        public string Version { get; private set; } = @"0";
        public string BaseURL { get; private set; } = @"https://api.kraken.com";
        public string APIKey { get; private set; }
        public string PrivateKey { get; private set; }

        public ThreadedAntiFlood AntiFlood { get; private set; }

/*
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

        public static bool IsCryptocurrency(string value)
        {
            
            foreach(Currency c in Enums.ToArray<Cryptocurrency>())
            {
                string name = c.GetEnumName();
                string asset = "X" + c.GetEnumName();
                string description = c.GetEnumDescription();
                if (value == name || value == asset || value == description)
                    return true;
            }

            return false;
        }

        public static bool IsCurrency(string value)
        {

            foreach (Currency c in Enums.ToArray<Currency>())
            {
                string name = c.GetEnumName();
                string asset = "Z" + c.GetEnumName();
                string description = c.GetEnumDescription();
                if (value == name || value == asset || value == description)
                    return true;
            }

            return false;
        }
        */
    }
}
