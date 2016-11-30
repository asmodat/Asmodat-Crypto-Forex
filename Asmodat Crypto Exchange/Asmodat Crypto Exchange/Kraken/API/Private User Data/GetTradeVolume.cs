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
//using PennedObjects.RateLimiting;

using Asmodat.Extensions.Objects;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {
        

        public TradeVolume GetTradeVolume(List<string> pairs = null, bool feeinfo = false)
        {
            
            string props = "";

            if(pairs != null)
            {
                props = string.Format("&pair={0}", pairs[0]);


                for (int i = 1; i < pairs.Count; i++)
                    props += "," + pairs[i];
            }

            if(feeinfo)
                props += string.Format("&fee-info={0}", feeinfo);


            string response = this.QueryPrivate("TradeVolume", props);

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;

            

             TradeVolume volume = JsonConvert.DeserializeObject<TradeVolume>(result.Result.ToString());

            List<TradeFees> tradefees = new List<TradeFees>();
            foreach (JProperty property in volume.fees.Children())
            {
                if (property == null || property.Value == null)
                    continue;
                try
                {
                    TradeFees tradefee = JsonConvert.DeserializeObject<TradeFees>(property.Value.ToString());
                    tradefee.PairName = property.Name;
                    tradefees.Add(tradefee);
                }
                catch
                {
                    continue;
                }
            }

            volume.Fees = tradefees.ToArray();


            List<TradeFees> tradefees_maker = new List<TradeFees>();
            foreach (JProperty property in volume.fees_maker.Children())
            {
                if (property == null || property.Value == null)
                    continue;

                try
                {
                    TradeFees tradefee = JsonConvert.DeserializeObject<TradeFees>(property.Value.ToString());
                    tradefee.PairName = property.Name;
                    tradefees_maker.Add(tradefee);
                }
                catch
                {
                    continue;
                }
            }


            volume.FeesMaker = tradefees_maker.ToArray();

            return volume;
        }

    }

    public class TradeVolume
    {
        /// <summary>
        /// volume currency
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// current discount volume
        /// </summary>
        [JsonProperty(PropertyName = "volume")]
        public string Volume { get; set; }

        /// <summary>
        /// array of asset pairs and fee tier info (if requested)
        /// </summary>
        [JsonProperty(PropertyName = "fees")]
        public JObject fees { get; set; }

        /// <summary>
        /// array of asset pairs and maker fee tier info (if requested) for any pairs on maker/taker schedule
        /// </summary>
        [JsonProperty(PropertyName = "fees_maker")]
        public JObject fees_maker { get; set; }
        
        [JsonIgnore]
        public TradeFees[] Fees { get; set; }
        
        [JsonIgnore]
        public TradeFees[] FeesMaker { get; set; }
    }

    public class TradeFees
    {

        [JsonIgnore]
        public decimal Fee
        {
            get
            {
                if (!fee.IsNullOrWhiteSpace())
                    return decimal.Parse(fee);

                throw new Exception("Undefined fee percentage !");
            }
        }
        [JsonIgnore]
        public decimal MinFee
        {
            get
            {

                if (!minfee.IsNullOrWhiteSpace())
                    return decimal.Parse(minfee);
                throw new Exception("Undefined fee percentage !");
            }
        }
        [JsonIgnore]
        public decimal MaxFee
        {
            get
            {
                    if (!maxfee.IsNullOrWhiteSpace())
                        return decimal.Parse(maxfee);
                    throw new Exception("Undefined fee percentage !");
                }
        }
        [JsonIgnore]
        public decimal NextFee
        {
            get
            {

                if (!nextfee.IsNullOrWhiteSpace())
                    return decimal.Parse(nextfee);
                throw new Exception("Undefined fee percentage !");
            }
        }
        [JsonIgnore]
        public decimal NextVolume
        {
            get
            {

                if (!nextvolume.IsNullOrWhiteSpace())
                    return decimal.Parse(nextvolume);
                throw new Exception("Undefined fee percentage !");
            }
        }
        [JsonIgnore]
        public decimal TierVolume
        {
            get
            {

                if (!tiervolume.IsNullOrWhiteSpace())
                    return decimal.Parse(tiervolume);
                throw new Exception("Undefined fee percentage !");
            }
        }

        [JsonIgnore]
        public string PairName { get; set; }


        /// <summary>
        /// current fee in percent
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public string fee { get; set; }

        /// <summary>
        /// minimum fee for pair (if not fixed fee)
        /// </summary>
        [JsonProperty(PropertyName = "minfee")]
        public string minfee { get; set; }

        /// <summary>
        /// maximum fee for pair (if not fixed fee)
        /// </summary>
        [JsonProperty(PropertyName = "maxfee")]
        public string maxfee { get; set; }

        /// <summary>
        /// next tier's fee for pair (if not fixed fee.  nil if at lowest fee tier)
        /// </summary>
        [JsonProperty(PropertyName = "nextfee")]
        public string nextfee { get; set; }

        /// <summary>
        /// volume level of next tier (if not fixed fee.  nil if at lowest fee tier)
        /// </summary>
        [JsonProperty(PropertyName = "nextvolume")]
        public string nextvolume { get; set; }

        /// <summary>
        /// volume level of current tier (if not fixed fee.  nil if at lowest fee tier)
        /// </summary>
        [JsonProperty(PropertyName = "tiervolume")]
        public string tiervolume { get; set; }
    }



}
