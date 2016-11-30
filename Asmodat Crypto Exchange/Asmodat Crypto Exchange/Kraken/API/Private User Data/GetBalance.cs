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

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {

        public Balance[] GetBalance()
        {
            string response = null;
            try
            {

                response = this.QueryPrivate("Balance");
            }
            catch(Exception ex)
            {
                ex.ToOutput();
                response = null;
            }

            if (response == null)
                return null;

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);

            if (result.Error == null || result.Error.Count > 0)
                return null;

             List<Balance> values = new List<Balance>();
             foreach (JProperty property in result.Result.Children())
             {
                try
                {
                    Balance value = new Balance();
                    value.AssetName = property.Name;
                    value.BalanceAmount = decimal.Parse(property.Value.ToString());
                    values.Add(value);
                }
                catch (Exception ex)
                {
                    ex.ToOutput();
                    continue;
                }
             }
             
            return values.ToArray();
        }

    }


    public class Balance
    {
        [JsonIgnore]
        public Kraken.Asset Asset
        {
            get
            {
                return Kraken.ToAsset(AssetName).Value;
            }
        }

        /// <summary>
        ///  Asset name Z(Currency) X(Cryptocurrency)
        /// </summary>
        [JsonIgnore]
        public string AssetName { get; set; }

        /// <summary>
        /// Balance amount of specified asset
        /// </summary>
        [JsonIgnore]
        public decimal BalanceAmount { get; set; }


        

    }
}
