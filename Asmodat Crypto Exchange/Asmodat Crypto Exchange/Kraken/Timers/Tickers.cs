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


        


        public Ticker[] Tickers { get; private set; }


        public TickTimeout TimeoutTickers { get; private set; } = new TickTimeout(4000, TickTime.Unit.ms, TickTime.Default);

        

        public void InitializeTickers()
        {
            if (!Timers.Contains("TimrTickers"))
                Timers.Run(() => TimrTickers(), 1000, "TimrTickers", true, false);
        }


        public void TimrTickers()
        {
            if (!TimeoutTickers.IsTriggered)
                return;

            TimeoutTickers.Forced = true;

            AssetPair[] pairs = AssetPairs;
            Ticker[] tickers = null;

            if (pairs == null || pairs.Length < 0)
                return;

            try
            {
                tickers = this.GetTickers(pairs);
            }
            catch (Exception ex)
            {
                ex.ToOutput();
                return;
            }

            if (tickers == null || tickers.Length <= 0)
                return;

            Tickers = tickers;
            TimeoutTickers.Reset();
        }




    }
}
