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
using System.ComponentModel;
//using PennedObjects.RateLimiting;

using Asmodat.Extensions.Collections.Generic;
using Asmodat.Extensions.Collections;
using Asmodat.Extensions.Objects;

namespace Asmodat.Kraken
{

    public partial class KrakenManager
    {

        public TransactionOrder AddMarketOrder(
            string pair,
            Kraken.OrderKind type,
            decimal volume,
            string leverage = "none",
            Kraken.OrderFlags[] oflags = null
            )
        {

            return this.AddOrder(pair, type, Kraken.OrderType.Market , volume, null, null, leverage, oflags);
        }

        public TransactionOrder AddOrder(
            string pair,
            Kraken.OrderKind type,
            Kraken.OrderType ordertype,
            decimal volume,
            decimal? price,
            decimal? price2,
            string leverage = "none",
            Kraken.OrderFlags[] oflags = null,
            string starttm = null,
            string expiretm = null,
            string userref = null,
            bool validate = false,
            Dictionary<string, string> close = null
            )
        {

            string flags = null;
            if(!oflags.IsNullOrEmpty())
            {
                foreach (var f in oflags)
                    flags += f.GetEnumDescription() + ",";

                flags = flags.RemoveLast(1);
            }


            return this.AddOrder(pair, type.GetEnumDescription(), ordertype.GetEnumDescription(), volume, price, price2, leverage, flags, starttm, expiretm,userref,validate,close);
        }

        public TransactionOrder AddOrder(
            string pair, 
            string type, 
            string ordertype, 
            decimal volume,
            decimal? price,
            decimal? price2,
            string leverage = "none",
            string oflags = null,
            string starttm = null,
            string expiretm = null,
            string userref = null,
            bool validate = false,
            Dictionary<string,string> close = null
            )
        {
           
            string props = string.Format("&pair={0}&type={1}&ordertype={2}&volume={3}&leverage={4}", pair, type, ordertype, volume, leverage);
            if (price.HasValue)
                props += string.Format("&price={0}", price.Value);
            if (price2.HasValue)
                props += string.Format("&price2={0}", price2.Value);
            if (!string.IsNullOrEmpty(oflags))
                props += string.Format("&oflags={0}", oflags);
            if (!string.IsNullOrEmpty(starttm))
                props += string.Format("&starttm={0}", starttm);
            if (!string.IsNullOrEmpty(expiretm))
                props += string.Format("&expiretm={0}", expiretm);
            if (!string.IsNullOrEmpty(userref))
                props += string.Format("&userref={0}", userref);
            if (validate)
                props += "&validate=true";

            if (close != null)
            {
                string closeString = string.Format("&close[ordertype]={0}&close[price]={1}&close[price2]={2}", close["ordertype"], close["price"], close["price2"]);
                props += closeString;
            }


            string response = this.QueryPrivate("AddOrder", props);
            TransactionOrder order;

            if (response.IsNullOrEmpty())
            {
                order = new TransactionOrder();
                order.Error = "Could not recognize order result, or server havn't responded in due time.";
                return order;
            }

            ObjResult result = JsonConvert.DeserializeObject<ObjResult>(response);
            
            if (!result.Error.IsNullOrEmpty())
            {
                order = new TransactionOrder();
                order.Error = result.Error.ToArray()[0].ToString();
                return order;

            }

             order = JsonConvert.DeserializeObject<TransactionOrder>(result.Result.ToString());

            return order;
        }



        
    }


    








}
