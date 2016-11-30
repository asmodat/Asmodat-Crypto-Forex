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
        /// Returns all available assets, if _sasset is defined, only complementary assets are returned
        /// </summary>
        /// <param name="_sasset"></param>
        /// <returns></returns>
        public Kraken.Asset[] TradableAsset(string _sasset)
        {
            if (AssetPairs == null || AssetPairs.Length <= 0)
                return null;

            var _asset = Kraken.ToAsset(_sasset);

            List<Kraken.Asset> result = new List<Kraken.Asset>();
            for (int i = 0; i < AssetPairs.Length; i++)
            {
                string sbase = AssetPairs[i].Base;
                string squote = AssetPairs[i].Quote;
                var abase = Kraken.ToAsset(sbase);
                var aquote = Kraken.ToAsset(squote);

                if (abase == null || aquote == null)
                    continue;



                if (_asset != null && _asset.HasValue)
                {
                    if (_asset.Value == abase.Value)
                        result.Add(aquote.Value); //add quote if base is specified asset
                    else if (_asset.Value == aquote.Value)
                        result.Add(abase.Value); //add base if quote is specified asset
                }
                else
                {
                    result.Add(abase.Value); //add base
                    result.Add(aquote.Value); //add quote
                }
            }

            return result.Distinct().ToArray();
        }


        public Kraken.Currency[] TradableCurrency(string _sasset)
        {
            return Kraken.ToCurrency(TradableAsset(_sasset));
        }

        public Kraken.Cryptocurrency[] TradableCryptocurrency(string _sasset)
        {
            return Kraken.ToCryptocurrency(TradableAsset(_sasset));
        }

        public Kraken.Asset[] TradableAsset(Kraken.Asset? asset = null)
        {
             return TradableAsset(Kraken.ToString(asset));
        }

        public Kraken.Currency[] TradableCurrency(Kraken.Asset? asset = null)
        {
            return TradableCurrency(Kraken.ToString(asset));
        }

        public Kraken.Cryptocurrency[] TradableCryptocurrency(Kraken.Asset? asset = null)
        {
            return TradableCryptocurrency(Kraken.ToString(asset));
        }

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
