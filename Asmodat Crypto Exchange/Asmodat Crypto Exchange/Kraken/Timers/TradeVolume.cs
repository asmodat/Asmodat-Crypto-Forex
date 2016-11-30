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

using Asmodat.Extensions.Objects;
using Asmodat.Extensions;
using Asmodat.Extensions.Collections.Generic;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {
        public TradeVolume TradeVolume { get; private set; } = null;

        /// <summary>
        /// The taker fee applies when you remove liquidity from the book by placing a market or limit order 
        /// that executes immediately against a limit order already on the book.
        /// </summary>
        /// <param name="PairName"></param>
        /// <returns></returns>
        public decimal GetFee(string PairName)
        {
            if (TradeVolume == null || TradeVolume.Fees.IsNullOrEmpty())
                throw new Exception("TradeVolume Fees are not loaded.");


            foreach (var fees in TradeVolume.Fees)
                if (fees.PairName == PairName)
                    return fees.Fee;

            throw new Exception("Taker or dark pool fee could not be foud.");
        }

        /// <summary>
        /// The maker fee applies when you add liquidity to the order book by placing a limit buy below market price or a limit sell above market price. 
        /// The maker fee is paid only when such orders are taken by new incoming orders.
        /// </summary>
        /// <param name="PairName"></param>
        /// <returns></returns>
        public decimal GetFeeMaker(string PairName)
        {
            if (TradeVolume == null || TradeVolume.Fees.IsNullOrEmpty())
                throw new Exception("TradeVolume Fees are not loaded.");


            foreach (var fees in TradeVolume.FeesMaker)
                if (fees.PairName == PairName)
                    return fees.Fee;

            throw new Exception("Maker fee could not be foud.");
        }

        public TickTimeout TimeoutTradeVolume { get; private set; } = new TickTimeout(5000, TickTime.Unit.ms, TickTime.Default);

        public void InitializeTradeVolume()
        {
            if (!Timers.Contains("TimrTradeVolume"))
                Timers.Run(() => TimrTradeVolume(), 2500, "TimrTradeVolume", true, false);
        }

        public void TimrTradeVolume()
        {
            if (AssetPairsNames.IsNullOrEmpty() || !TimeoutTradeVolume.IsTriggered)
                return;

            TimeoutTradeVolume.Forced = true;

            TradeVolume tradevolume = this.GetTradeVolume(this.AssetPairsNames.ToList(), true);

            if (tradevolume == null)
                return;

            this.TradeVolume = tradevolume;

            TimeoutTradeVolume.Reset();
        }

        

    }
}
