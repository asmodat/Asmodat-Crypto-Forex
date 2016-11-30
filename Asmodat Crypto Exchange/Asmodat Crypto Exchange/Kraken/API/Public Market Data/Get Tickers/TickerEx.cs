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
using System.Collections.ObjectModel;
using Asmodat.Extensions.Objects;
using Asmodat.Extensions.Collections.Generic;
using Asmodat.Extensions;
//using PennedObjects.RateLimiting;
using Asmodat.Extensions.Collections;
namespace Asmodat.Kraken
{

    public static class TickerEx
    {
        /* /// <summary>
         /// Returns second asset amount
         /// </summary>
         /// <param name="tickers"></param>
         /// <param name="asset"></param>
         /// <param name="amount"></param>
         /// <returns></returns>
         public static Ticker GetAmount(this Ticker[] tickers, Kraken.Asset _base, Kraken.Asset _quote)
         {
             if (tickers == null || tickers.Length <= 0)
                 return null;

             foreach (Ticker ticker in tickers)
                 if (ticker.Name == pair.GetEnumDescription())
                     return ticker;

             return null;
         }*/



        public static bool IsBase(this Ticker ticker, Kraken.Asset? asset)
        {
            if (ticker != null && !ticker.AssetBase.IsNull() && ticker.AssetBase.ValueEquals(asset))
                return true;
            else return false;
        }

        public static bool IsQuote(this Ticker ticker, Kraken.Asset? asset)
        {
            if (ticker != null && !ticker.AssetQuote.IsNull() && ticker.AssetQuote.ValueEquals(asset))
                return true;
            else return false;
        }

        public static bool IsPair(this Ticker ticker, Kraken.Asset _base, Kraken.Asset _quote)
        {
            if (ticker.IsBase(_base) && ticker.IsQuote(_quote))
                return true;
            else return false;
        }

        public static bool IsAssets(this Ticker ticker, Kraken.Asset _assetFirst, Kraken.Asset _assetSecond)
        {
            if (ticker.IsPair(_assetFirst, _assetSecond) || ticker.IsPair(_assetSecond, _assetFirst))
                return true;
            else return false;
        }

        public static Ticker Get(this Ticker[] tickers, ApiProperties.Pairs pair)
        {
            if (tickers == null || tickers.Length <= 0)
                return null;

            foreach (Ticker ticker in tickers)
                if (ticker.Name == pair.GetEnumDescription())
                    return ticker;

            return null;
        }

        public static Ticker Get(this Ticker[] tickers, Kraken.Asset _base, Kraken.Asset _quote)
        {
            if (tickers == null || tickers.Length <= 0)
                return null;

            string pair = Kraken.ToPairString(_base, _quote);

            foreach (Ticker ticker in tickers)
            {
                if (ticker.Name == pair)
                    return ticker;
            }

            return null;
        }

        /// <summary>
        /// Returns first pair that matches any combination of first and second asset
        /// </summary>
        /// <param name="tickers"></param>
        /// <param name="_assetFirst"></param>
        /// <param name="_assetSecond"></param>
        /// <returns></returns>
        public static Ticker GetAny(this Ticker[] tickers, Kraken.Asset? _assetFirst, Kraken.Asset? _assetSecond)
        {
            if (tickers.IsNullOrEmpty() || _assetFirst.IsNull() || _assetSecond.IsNull() || _assetFirst.ValueEquals(_assetSecond))
                return null;

            string pairFirst = Kraken.ToPairString(_assetFirst.Value, _assetSecond.Value);
            string pairSecond = Kraken.ToPairString(_assetSecond.Value, _assetFirst.Value);

            foreach (Ticker ticker in tickers)
            {
                if (ticker.Name == pairFirst || ticker.Name == pairSecond)
                    return ticker;
            }

            return null;
        }

        /// <summary>
        /// returns unit value (ask) of asset in units of specified currency
        /// </summary>
        /// <param name="tickers"></param>
        /// <param name="_asset"></param>
        /// <param name="_currency"></param>
        /// <returns></returns>
        public static decimal? GetValueInCurrency(this Ticker[] tickers, Kraken.Asset _asset, Kraken.Currency _currency, decimal assetAmount = 1)
        {
            if (tickers == null || tickers.Length <= 0)
                return null;

            if (_asset == Kraken.ToAsset(_currency))
                return 1;

            if(Kraken.IsCurrency(_asset))
            {
                decimal? ask1 = tickers.GetValueInCurrency(Kraken.Asset.XBT, Kraken.ToCurrency(_asset), 1);
                decimal? ask2 = tickers.GetValueInCurrency(Kraken.Asset.XBT, _currency, 1);
                if (ask1.IsNull() || ask2.IsNull())
                    return null;

                return (decimal)ask2.Value / ask1.Value;
            }

            Kraken.Asset acurrency = Kraken.ToAsset(_currency);
            Ticker ticker = tickers.GetAny(_asset, acurrency);

            if (ticker == null)
                return null;

            if(ticker.IsBase(_asset) && ticker.IsQuote(acurrency))
            {
                return ticker.Ask[0] * assetAmount;
            }
            else if(ticker.IsBase(acurrency) && ticker.IsQuote(_asset))
            {
                return ((decimal)1 / ticker.Ask[0]) * assetAmount;
            }

            return null;
        }



      
    }

}


/*
public static decimal? GetValueInCurrency(this Ticker[] tickers, Kraken.Asset _asset, Kraken.Currency _currency, decimal assetAmount = 1)
        {
            
            if (_asset == Kraken.ToAsset(_currency))
                return 1;

            if(Kraken.IsCurrency(_asset))
            {
                decimal? ask1 = tickers.GetValueInCurrency(Kraken.Asset.XBT, Kraken.ToCurrency(_asset), 1);
                decimal? ask2 = tickers.GetValueInCurrency(Kraken.Asset.XBT, _currency, 1);
                if (ask1.IsNull() || ask2.IsNull())
                    return null;

                return (decimal)ask2.Value / ask1.Value;

                //return tickers.GetValueInCurrency(Kraken.Asset.XBT, _currency, ask.Value);
            }

            if (tickers == null || tickers.Length <= 0)
                return null;

            Kraken.Asset acurrency = Kraken.ToAsset(_currency);

            Ticker tickerBase = tickers.Get(_asset, acurrency);
            Ticker tickerQuote = tickers.Get(acurrency, _asset);

            if (tickerBase == null && tickerQuote == null)
                return null;

            if (tickerBase != null)
            {
                return tickerBase.Ask[0] * assetAmount;
            }
            else if(tickerQuote != null)
            {
                return ((decimal)1 / tickerQuote.Ask[0]) * assetAmount;
            }

            return null;
        }
*/
