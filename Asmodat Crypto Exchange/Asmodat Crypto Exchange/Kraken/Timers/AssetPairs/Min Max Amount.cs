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

        public decimal MinimumBaseAmount { get; private set; } = 0.01m;

        public decimal MaximumAmount { get; private set; } = UInt32.MaxValue;

        public decimal MaxExchangeAmountInUSD { get; private set; } = 20000;

        /*&
        public decimal[] MinAmount(Kraken.Asset first, Kraken.Asset second)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                throw new Exception("AssetPairs are not loaded.");

            decimal[] result = new decimal[2];

            var _ticker = Tickers.GetAny(first, second);


            Ticker ticker = this.CalculateExchangeTicker(_ticker);

            if (ticker == null)
                return null;
            
            if (ticker.IsPair(first,second))
            {
                result[0] = MinimumBaseAmount * 2;
                result[1] = ticker.BuyPrice(first, result[0]);
            }
            else if (ticker.IsPair(second, first))
            {
                result[1] = MinimumBaseAmount * 2;
                result[0] = ticker.BuyPrice(second, result[0]);
            }
            else return null;



            return result;
        }

        public decimal[] MaxAmount(Kraken.Asset first, Kraken.Asset second)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                throw new Exception("AssetPairs are not loaded.");

            decimal[] result = new decimal[2];


            if (Kraken.IsCryptocurrency(first) && Kraken.IsCryptocurrency(second))
                return new decimal[2] { MaximumAmount, MaximumAmount };


            decimal? valueFirst = Tickers.GetValueInCurrency(first, Kraken.Currency.USD);
            decimal? valueSecond = Tickers.GetValueInCurrency(second, Kraken.Currency.USD);

            if (valueFirst == null || !valueFirst.HasValue || valueSecond == null || !valueSecond.HasValue)
                return null;

            decimal maxFirst = (decimal)MaxExchangeAmountInUSD / valueFirst.Value;
            decimal maxSecond = (decimal)MaxExchangeAmountInUSD / valueSecond.Value;

            //if (maxFirst > MaximumAmount) maxFirst = MaximumAmount; else if (maxSecond > MaximumAmount) maxSecond = MaximumAmount;

            return new decimal[2] { (decimal)maxFirst/10, (decimal)maxSecond/10 };
        }
    */


    }
}


/*
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


        /// <summary>
        /// Returns tradable base currency,if quote is defined then method returns only base with specified quote
        /// </summary>
        /// <param name="_squote"></param>
        /// <returns></returns>
        public Kraken.Currency[] TradableBaseCurrency(string _squote = null)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                return null;

            var _asset = Kraken.ToAsset(_squote);

            List<Kraken.Currency> result = new List<Kraken.Currency>();
            for (int i = 0; i < AssetPairs.Length; i++)
            {
                string sbase = AssetPairs[i].Base;
                string squote = AssetPairs[i].Quote;
                var cbase = Kraken.ToCurrency(sbase);
                var aquote = Kraken.ToAsset(squote);

                if (_asset != null && _asset.HasValue && aquote.HasValue && _asset.Value != aquote.Value)
                    continue;

                if (cbase != null && cbase.HasValue)
                    result.Add(cbase.Value);
            }

            return result.Distinct().ToArray();
        }

        /// <summary>
        /// Returns tradable quote currency,if base is defined then method returns only quotes with specified base
        /// </summary>
        /// <param name="_sbase"></param>
        /// <returns></returns>
        public Kraken.Currency[] TradableQuoteCurrency(string _sbase = null)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                return null;

            var _asset = Kraken.ToAsset(_sbase);

            List<Kraken.Currency> result = new List<Kraken.Currency>();
            for (int i = 0; i < AssetPairs.Length; i++)
            {
                string sbase = AssetPairs[i].Base;
                string squote = AssetPairs[i].Quote;
                var cquote = Kraken.ToCurrency(squote);
                var abase = Kraken.ToAsset(sbase);

                if (_asset != null && _asset.HasValue && abase.HasValue && _asset.Value != abase.Value)
                    continue;

                if (cquote != null && cquote.HasValue)
                    result.Add(cquote.Value);
            }

            return result.Distinct().ToArray();
        }

        /// <summary>
        /// Returns tradable base cryptocurrencies ,if quote is defined then method returns only base with specified quote
        /// </summary>
        /// <param name="_squote"></param>
        /// <returns></returns>
        public Kraken.Cryptocurrency[] TradableBaseCryptocurrency(string _squote = null)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                return null;

            var _asset = Kraken.ToAsset(_squote);

            List<Kraken.Cryptocurrency> result = new List<Kraken.Cryptocurrency>();
            for (int i = 0; i < AssetPairs.Length; i++)
            {
                string sbase = AssetPairs[i].Base;
                string squote = AssetPairs[i].Quote;
                var ccbase = Kraken.ToCryptocurrency(sbase);
                var aquote = Kraken.ToAsset(squote);

                if (_asset != null && _asset.HasValue && aquote.HasValue && _asset.Value != aquote.Value)
                    continue;

                if (ccbase != null && ccbase.HasValue)
                    result.Add(ccbase.Value);
            }

            return result.Distinct().ToArray();
        }

        /// <summary>
        /// Returns tradable quote cryptocurrency, if base is defined then method returns only quotes with specified base
        /// </summary>
        /// <param name="_sbase"></param>
        /// <returns></returns>
        public Kraken.Cryptocurrency[] TradableQuoteCryptocurrency(string _sbase = null)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                return null;

            var _asset = Kraken.ToAsset(_sbase);

            List<Kraken.Cryptocurrency> result = new List<Kraken.Cryptocurrency>();
            for (int i = 0; i < AssetPairs.Length; i++)
            {
                string sbase = AssetPairs[i].Base;
                string squote = AssetPairs[i].Quote;
                var ccquote = Kraken.ToCryptocurrency(squote);
                var abase = Kraken.ToAsset(sbase);

                if (_asset != null && _asset.HasValue && abase.HasValue && _asset.Value != abase.Value)
                    continue;

                if (ccquote != null && ccquote.HasValue)
                    result.Add(ccquote.Value);
            }

            return result.Distinct().Distinct().ToArray();
        }

        public Kraken.Currency[] TradableCurrency(string _sbase = null, string _squote = null)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                return null;

            List<Kraken.Currency> result = new List<Kraken.Currency>();

            result.AddRange(TradableBaseCurrency(_squote));
            result.AddRange(TradableQuoteCurrency(_sbase));

            return result.Distinct().ToArray();
        }
        public Kraken.Cryptocurrency[] TradableCryptocurrency(string _sbase = null, string _squote = null)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                return null;

            List<Kraken.Cryptocurrency> result = new List<Kraken.Cryptocurrency>();

            result.AddRange(TradableBaseCryptocurrency(_squote));
            result.AddRange(TradableQuoteCryptocurrency(_sbase));

            return result.Distinct().ToArray();
        }


        public Kraken.Asset[] TradableAsset(string _sbase = null, string _squote = null)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                return null;

            List<Kraken.Asset> result = new List<Kraken.Asset>();

            var bc = Kraken.ToAsset(TradableBaseCurrency(_squote));
            var qc = Kraken.ToAsset(TradableQuoteCurrency(_sbase));
            var bcc = Kraken.ToAsset(TradableBaseCryptocurrency(_squote));
            var qcc = Kraken.ToAsset(TradableQuoteCryptocurrency(_sbase));

            if (bc != null && bc.Length > 0) result.AddRange(bc);
            if (qc != null && qc.Length > 0) result.AddRange(qc);
            if (bcc != null && bcc.Length > 0) result.AddRange(bcc);
            if (qcc != null && qcc.Length > 0) result.AddRange(qcc);

            return result.Distinct().ToArray();
        }

        public Kraken.Asset[] TradableAssetBase(string _squote = null)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                return null;

            List<Kraken.Asset> result = new List<Kraken.Asset>();

            var bc = Kraken.ToAsset(TradableBaseCurrency(_squote));
            var bcc = Kraken.ToAsset(TradableBaseCryptocurrency(_squote));

            if (bc != null && bc.Length > 0) result.AddRange(bc);
            if (bcc != null && bcc.Length > 0) result.AddRange(bcc);

            return result.Distinct().ToArray();
        }

        public Kraken.Asset[] TradableAssetQuote(string _sbase = null)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                return null;

            List<Kraken.Asset> result = new List<Kraken.Asset>();

            var qc = Kraken.ToAsset(TradableQuoteCurrency(_sbase));
            var qcc = Kraken.ToAsset(TradableQuoteCryptocurrency(_sbase));

            if (qc != null && qc.Length > 0) result.AddRange(qc);
            if (qcc != null && qcc.Length > 0) result.AddRange(qcc);

            return result.Distinct().ToArray();
        }

        public Kraken.Asset[] TradableAssetBase(Kraken.Asset? _aquote = null)
        {
            string _squote = null;
            if (_aquote != null && _aquote.HasValue)
                _squote = _aquote.Value.ToString();

            return TradableAssetBase(_squote);
        }

        public Kraken.Asset[] TradableAssetQuote(Kraken.Asset? _abase = null)
        {
            string _sbase = null;
            if (_abase != null && _abase.HasValue)
                _sbase = _abase.Value.ToString();

            return TradableAssetQuote(_sbase);
        }

        
    }
}

*/
