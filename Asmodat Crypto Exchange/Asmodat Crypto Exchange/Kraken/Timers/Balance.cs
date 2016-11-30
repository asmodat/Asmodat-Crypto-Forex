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
        public ThreadedDictionary<string, Balance> Balances = new ThreadedDictionary<string, Balance>();

        public decimal BalanceAmount(string name)
        {
            if (Balances == null || name.IsNullOrWhiteSpace())
                return 0;

            if (!Balances.ContainsKey(name))
                return 0;

            return Balances[name].BalanceAmount;
        }

        public decimal BalanceAmount(Kraken.Currency currency)
        {
            return BalanceAmount("Z" + currency.GetEnumName());
        }

        public decimal BalanceAmount(Kraken.Cryptocurrency cryptocurrency)
        {
            return BalanceAmount("X" + cryptocurrency.GetEnumName());
        }


        public TickTimeout TimeoutBalance { get; private set; } = new TickTimeout(5000, TickTime.Unit.ms, TickTime.Default);
        

        public void InitializeBalance()
        {
            if (!Timers.Contains("TimrBalance"))
                Timers.Run(() => TimrBalance(), 3000, "TimrBalance", true, false);
        }


        public void TimrBalance()
        {
            if (!TimeoutBalance.IsTriggered)
                return;

            TimeoutBalance.Forced = true;

            Balance[] balances = this.GetBalance();

            if (balances == null)
                return;

            //set balance of missing assets to 0
            foreach(string key in Balances.Keys)
            {
                if (balances.Length <= 0)
                {
                    Balances[key].BalanceAmount = 0;
                    continue;
                }

                if (!balances.Any(balance => balance.AssetName == key))
                {
                    Balances[key].BalanceAmount = 0;
                    continue;
                }
            }

            //set current assets balances
            foreach (Balance balance in balances)
            {
                if (Balances.ContainsKey(balance.AssetName))
                {
                    Balances.Add(balance.AssetName, balance);
                }
                else
                {
                    Balances[balance.AssetName] = balance;
                }
            }

            TimeoutBalance.Reset();
        }

        /// <summary>
        /// Returns balances thats available amount more then zero
        /// </summary>
        /// <returns></returns>
        public Balance[] AvailableBalances()
        {
            if (Balances == null)
                return null;

            string[] keys = Balances.Keys.ToArray();
            List<Balance> result = new List<Balance>();
            foreach (string key in keys)
            {
                var balance = Balances[key];
                if (balance != null && balance.BalanceAmount > 0)
                    result.Add(balance);
            }

            return result.ToArray();
        }


        public Kraken.Asset[] AvailableAssets()
        {
            var balances = this.AvailableBalances();

            if (balances.IsNullOrEmpty())
                return null;

            string[] keys = Balances.Keys.ToArray();
            List<Kraken.Asset> result = new List<Kraken.Asset>();
            foreach (var b in balances)
                result.AddIfValueIsNotNull(Kraken.ToAsset(b.AssetName));

            return result.ToArray();
        }


        public Kraken.Currency[] AvailableCurrency()
        {
            var balances = this.AvailableBalances();

            if (balances.IsNullOrEmpty())
                return null;

            string[] keys = Balances.Keys.ToArray();
            List<Kraken.Currency> result = new List<Kraken.Currency>();
            foreach(var b in balances)
                result.AddIfValueIsNotNull(Kraken.ToCurrency(b.AssetName));
            
            return result.ToArray();
        }

        public Kraken.Cryptocurrency[] AvailableCryptocurrency()
        {
            var balances = this.AvailableBalances();

            if (balances.IsNullOrEmpty())
                return null;

            string[] keys = Balances.Keys.ToArray();
            List<Kraken.Cryptocurrency> result = new List<Kraken.Cryptocurrency>();
            foreach (var b in balances)
                result.AddIfValueIsNotNull(Kraken.ToCryptocurrency(b.AssetName));

            return result.ToArray();
        }


    }
}
